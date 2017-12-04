using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Model.Models
{
    public class Sighting
    {
        
        public int SightingID { get; set; }
        [Required(ErrorMessage = "Sighting Heroes Required")]
        public ICollection<Hero> SightingHeroes { get; set; }
        [Required(ErrorMessage = "Sighting Location Required")]
        public Location SightingLocation { get; set; }
        public DateTime Date { get; set; }
        public bool Ispublished { get; set; }
        public bool IsDeleted { get; set; }
        public List<int> SelectedHeroesID { get; set; }
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
