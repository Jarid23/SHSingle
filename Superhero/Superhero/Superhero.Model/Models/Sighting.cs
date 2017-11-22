using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Model.Models
{
    public class Sighting
    {
        public int SightingID { get; set; }
        public virtual ICollection<Hero> SighintgHeroes { get; set; }
        public Location SightingLocation { get; set; }
        public DateTime Date { get; set; }
        public bool Ispublished { get; set; }
        public bool IsDeleted { get; set; }
        

        public Sighting()
        {
            SighintgHeroes = new HashSet<Hero>();
        }

        public string HeroesAsHtml()
        {
            string result = "";
            if (SighintgHeroes != null && SighintgHeroes.Count>0)
            {
                foreach (var hero in SighintgHeroes)
                {
                    result += hero.HeroName;
                }
            }

            return result;
        }

    }
}
