using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data
{
    public class MovieDBEntity : DbContext
    {
        public MovieDBEntity() : base("MovieDB")
        {

        }
        public DbSet<Dvd> Dvds { get; set; }
    }
}
