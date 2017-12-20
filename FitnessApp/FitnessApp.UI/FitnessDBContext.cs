using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using FitnessApp.Models.Models;

namespace FitnessApp.UI
{
    public class FitnessDBContext : IdentityDbContext
    {
        public FitnessDBContext()
            : base("Fitness")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Workout> Workouts { get; set; }
    }
}
