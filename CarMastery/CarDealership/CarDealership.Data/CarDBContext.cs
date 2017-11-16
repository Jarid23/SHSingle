using CarDealership.Model;
using CarDealership.Model.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class CarDBContext : IdentityDbContext<AppUser>
    {
        public CarDBContext()
            : base("CarDealership")
        {

        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Sale> Sale { get; set; }
        
    }
}
