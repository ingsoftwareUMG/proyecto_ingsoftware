using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using printSmart.Models;
using printSmart.data;

namespace printSmart.Controllers
{
    public class PaymentccsController : Controller
    {
        private readonly AplicationDbContext _context;

        public PaymentccsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Paymentccs
        public async Task<IActionResult> Index()
        {
            var printSmartContext = _context.Paymentccs.Include(p => p.IdCostumerNavigation);
            return View(await printSmartContext.ToListAsync());
        }

        // GET: Paymentccs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paymentccs == null)
            {
                return NotFound();
            }

            var paymentcc = await _context.Paymentccs
                .Include(p => p.IdCostumerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentcc == null)
            {
                return NotFound();
            }

            return View(paymentcc);
        }

        // GET: Paymentccs/Create
        public IActionResult Create()
        {
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "Id", "Name");
            return View();
        }

        // POST: Paymentccs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount,Description,IdCostumer")] Paymentcc paymentcc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentcc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "Id", "Name", paymentcc.IdCostumer);
            return View(paymentcc);
        }

        // GET: Paymentccs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paymentccs == null)
            {
                return NotFound();
            }

            var paymentcc = await _context.Paymentccs.FindAsync(id);
            if (paymentcc == null)
            {
                return NotFound();
            }
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "Id", "Name", paymentcc.IdCostumer);
            return View(paymentcc);
        }

        // POST: Paymentccs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount,Description,IdCostumer")] Paymentcc paymentcc)
        {
            if (id != paymentcc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentcc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentccExists(paymentcc.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "Id", "Name", paymentcc.IdCostumer);
            return View(paymentcc);
        }

        // GET: Paymentccs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paymentccs == null)
            {
                return NotFound();
            }

            var paymentcc = await _context.Paymentccs
                .Include(p => p.IdCostumerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentcc == null)
            {
                return NotFound();
            }

            return View(paymentcc);
        }

        // POST: Paymentccs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paymentccs == null)
            {
                return Problem("Entity set 'printSmartContext.Paymentccs'  is null.");
            }
            var paymentcc = await _context.Paymentccs.FindAsync(id);
            if (paymentcc != null)
            {
                _context.Paymentccs.Remove(paymentcc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentccExists(int id)
        {
          return (_context.Paymentccs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
