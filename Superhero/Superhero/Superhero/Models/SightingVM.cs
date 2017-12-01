using Superhero.Data.HeroRepository;
using Superhero.Data.LocationRepository;
using Superhero.Data.SightingRepository;
using Superhero.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superhero.Models
{
    public class SightingVM
    {
        ILocationRepo locationrepo = LocationRepoFactory.Create();
        IHeroRepo herorepo = HeroRepoFactory.Create();

        public int SightingID { get; set; }
        public IEnumerable<Hero> SightingHeroes { get; set; }
        public IEnumerable<Location> SightingLocation { get; set; }
        public Sighting SightingObject { get; set; }
        public List<int> SelectedHeroesID { get; set; }
        public IEnumerable<int> SelectedLocationsID { get; set; }
        //public IEnumerable<SelectListItem> HeroProperties { get; set; }
        public DateTime Date { get; set; }
        public bool Ispublished { get; set; }
        public bool IsDeleted { get; set; }
        public List<SelectListItem> HeroList { get; set; }

        public SightingVM()
        {
            SelectedHeroesID = new List<int>();
            HeroList = new List<SelectListItem>();
            SightingHeroes = herorepo.GetAllHeroes();
            SightingLocation = locationrepo.GetAllLocations();
        }

        public void SetHeroItems(IEnumerable<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                HeroList.Add(new SelectListItem()
                {
                    Value = hero.HeroName
                   
                });
            }
        }
    }
}