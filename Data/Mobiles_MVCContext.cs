using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mobiles_MVC.Models;

namespace Mobiles_MVC.Data
{
    public class Mobiles_MVCContext : DbContext
    {
        public Mobiles_MVCContext (DbContextOptions<Mobiles_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Mobiles_MVC.Models.Customers> Customers { get; set; }

        public DbSet<Mobiles_MVC.Models.Products> Products { get; set; }

        public DbSet<Mobiles_MVC.Models.Sell> Sell { get; set; }

        public DbSet<Mobiles_MVC.Models.Staffs> Staffs { get; set; }
    }
}
