using Superhero.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Superhero.Models
{
    public class OrgVM
    {
        public string OrganizationName { get; set; }
        public int OrganizationID { get; set; }
        public string OganizationAddress { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Hero> OrganizationHeroes { get; set; }
        public Location OrganizationLocation { get; set; }

        public OrgVM()
        {
            OrganizationHeroes = new HashSet<Hero>();
        }
    }
}