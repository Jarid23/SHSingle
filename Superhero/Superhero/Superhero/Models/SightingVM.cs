using Superhero.Data.HeroRepository;
using Superhero.Data.LocationRepository;
using Superhero.Data.SightingRepository;
using Superhero.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public DateTime Date { get; set; }
        public bool Ispublished { get; set; }
        public bool IsDeleted { get; set; }

        public SightingVM()
        {
            SightingHeroes = herorepo.GetAllHeroes();
            SightingLocation = locationrepo.GetAllLocations();
        }        
    }
}