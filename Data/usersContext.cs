using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using printSmart.Models;

namespace printSmart.Data
{
    public class usersContext : DbContext
    {
        public usersContext (DbContextOptions<usersContext> options)
            : base(options)
        {
        }

        public DbSet<printSmart.Models.users>? users { get; set; }
    }
}
