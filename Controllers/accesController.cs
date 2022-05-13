
using Microsoft.AspNetCore.Mvc;
using printSmart.Models;
using printSmart.Data;
using printSmart.Controllers;


namespace printSmart.Controllers
{
    public class accesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List <users> ListaUsuario()
        {

            return new List<users>
            {              

                new users{ Nombre = "Admin", UserName = "admin", Password = "1234" , }
            };
        }

        public users ValidarUser (String _userName , string _password)
        {
            return ListaUsuario().Where(item => item.UserName == _userName && item.Password == _password).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Index( users _users)
        {

            accesController accesController = new accesController();

            var usuario = accesController.ValidarUser(_users.UserName, _users.Password);

            //usersController _usersController = new usersController ();


            //var usuario = _usersController.Details(_users.Id);



            if (usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }

    }
}
