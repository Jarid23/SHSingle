using Superhero.Data.OrganizationRepository;
using Superhero.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superhero.Models
{
    public class HeroVM
    {
        IOrgRepo orgrepo = OrgRepoFactory.Create();
        public int HeroID { get; set; }
        [Required(ErrorMessage = "Hero Name Required")]
        public string HeroName { get; set; }
        public string Description { get; set; }
        public string Superpower { get; set; }
        public Organization OrgObject { get; set; }
        public List<int> SelectedOrganizationsID { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Sighting> Sightings { get; set; }
        public List<SelectListItem> Org { get; set; }
        public Hero HeroObject { get; set; }

        public HeroVM()
        {
            Org = new List<SelectListItem>();
            var AllOrgs = orgrepo.GetAllOrganizations();
            Sightings = new HashSet<Sighting>();
            SelectedOrganizationsID = new List<int>();

            foreach (var item in AllOrgs)
            {

                Org.Add(new SelectListItem
                {
                    Value = item.OrganizationID.ToString(),
                    Text = item.OrganizationName
                });
            }
        }
    }
}
