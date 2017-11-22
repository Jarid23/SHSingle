using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Superhero.Model.Models;
using System.Data.Entity;

namespace Superhero.Data
{
    //A DbContext instance represents a combination of the Unit Of Work and Repository patterns
    //such that it can be used to query from a database 
    //and group together changes that will then be written back to the store as a unit.     
    public class SuperheroDBContext : IdentityDbContext
    {
        //Constructs a new context instance using conventions to create the name of the database 
        //to which a connection will be made. 
        //The by-convention name is the full name (namespace + class name) of the derived context class.        
        public SuperheroDBContext()
            : base("Superhero")
        {

        }
        //DbContext corresponds to your database (or a collection of tables and views in your database)
        //whereas a DbSet corresponds to a table or view in your database. 
        //You will be using a DbContext object to get access to your tables and views(which will be represented by DbSet's)
        //and you will be using your DbSet's to get access, create, update, delete and modify your table data.
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Sighting> Sightings { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
