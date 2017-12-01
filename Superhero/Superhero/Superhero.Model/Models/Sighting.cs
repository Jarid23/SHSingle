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
        public ICollection<Hero> SightingHeroes { get; set; }
        public Location SightingLocation { get; set; }
        public DateTime Date { get; set; }
        public bool Ispublished { get; set; }
        public bool IsDeleted { get; set; }
        public string SightingDescription { get; set; }
        

        public Sighting()
        {
            SightingHeroes = new HashSet<Hero>();
        }

        public string HeroesAsHtml()
        {
            string result = "";
            if (SightingHeroes != null && SightingHeroes.Count > 0)
            {
                foreach (var hero in SightingHeroes)
                {
                    result += hero.HeroName + ',';
                }
                if (!string.IsNullOrEmpty(result))
                {
                    result = result.Substring(0, result.Length - 1);
                }
            }
            return result;
        }
    }
}
