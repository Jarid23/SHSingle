using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Model.Models
{
    public class Hero
    {
        public int HeroID { get; set; }
        //[Required(ErrorMessage = "Hero Name Required")]
        public string HeroName { get; set; }
        public string Description { get; set; }
        public string Superpower { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Sighting> Sightings { get; set; }

        public Hero()
        {
            Organizations = new HashSet<Organization>();
            Sightings = new HashSet<Sighting>();
        }
    }
}

 

