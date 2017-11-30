using Superhero.Data.HeroRepository;
using Superhero.Data.LocationRepository;
using Superhero.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superhero.Models
{
    public class OrgVM
    {
        IHeroRepo herorepo = HeroRepoFactory.Create();
        ILocationRepo locationrepo = LocationRepoFactory.Create();
        public string OrganizationName { get; set; }
        public int OrganizationID { get; set; }
        public string OganizationAddress { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Hero> OrganizationHeroes { get; set; }
        public List<int> SelectedHeroesID { get; set; }
        public Location OrganizationLocation { get; set; }
        public List<SelectListItem> HeroList { get; set; }
        public List<SelectListItem> LocationList { get; set; }

        public OrgVM()
        {
            OrganizationHeroes = new HashSet<Hero>();
            HeroList = new List<SelectListItem>();
            var AllHeroes = herorepo.GetAllHeroes();
            LocationList = new List<SelectListItem>();
            var AllLocations = locationrepo.GetAllLocations();
            SelectedHeroesID = new List<int>();

            foreach (var locoitem in AllLocations)
            {

                LocationList.Add(new SelectListItem
                {
                    Value = locoitem.LocationID.ToString(),
                    Text = locoitem.LocationName
                });
            }


            foreach (var item in AllHeroes)
            {
                HeroList.Add(new SelectListItem
                {
                    Value = item.HeroID.ToString(),
                    Text = item.HeroName
                });
               
            }
        }
    }
}
