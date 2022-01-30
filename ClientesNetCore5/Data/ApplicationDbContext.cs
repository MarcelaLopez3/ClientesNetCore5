using ClientesNetCore5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClientesNetCore5.Data
{
    public class ApplicationDbContext :DbContext
    {
        //constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        //instanciar modelo
        public DbSet<Cliente> Cliente { get; set; }
    }
}
