using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Model.Models
{
    public class Organization
    {
        public string OrganizationName { get; set; }
        public int OrganizationID { get; set; }
        public string OganizationAddress { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Hero> OrganizationHeroes { get; set; }
        public Location OrganizationLocation { get; set; }

        public Organization()
        {
            OrganizationHeroes = new HashSet<Hero>();
        }
    }
}
