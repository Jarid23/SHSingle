using Superhero.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Superhero.Models
{
    public class HeroVM
    {
        public int HeroID { get; set; }
        public string HeroName { get; set; }
        public string Description { get; set; }
        public string Superpower { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Sighting> Sightings { get; set; }

        public HeroVM()
        {
            Organizations = new HashSet<Organization>();
            Sightings = new HashSet<Sighting>();
        }
    }
}