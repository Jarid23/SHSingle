using Superhero.Data;
using Superhero.Data.HeroRepository;
using Superhero.Data.LocationRepository;
using Superhero.Data.OrganizationRepository;
using Superhero.Data.SightingRepository;
using Superhero.Model.Models;
using Superhero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superhero.Controllers
{
    //[Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        ILocationRepo locorepo = LocationRepoFactory.Create();
        IHeroRepo herorepo = HeroRepoFactory.Create();
        IOrgRepo orgrepo = OrgRepoFactory.Create();
        ISightingRepo repo = SightingRepoFactory.Create();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult AddHero()
        {
            return View(new HeroVM());
        }

        [HttpGet]
        public ActionResult AddLocation()
        {
            return View(new LocationVM());
        }

        [HttpGet]
        public ActionResult AddOrganization()
        {
            return View(new OrgVM());
        }

        [HttpPost]
        public ActionResult AddOrganization(OrgVM o)
        {
            if (ModelState.IsValid)
            {
                o.OrganizationHeroes = new List<Hero>();

                var org = new Organization
                {
                    OrganizationID = o.OrganizationID,
                    OrganizationName = o.OrganizationName,
                    OganizationAddress = o.OganizationAddress,
                    OrganizationLocation = o.OrganizationLocation,
                    Phone = o.Phone,
                };
                foreach (var HeroID in o.SelectedHeroesID)
                {
                    org.OrganizationHeroes.Add(herorepo.GetHereosByID(HeroID));
                }
                orgrepo.AddOrganization(org);
            }
            else
            {
                return View(o);
            }
            return RedirectToAction("OrganizationList");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddLocation(LocationVM l)
        {
            if (ModelState.IsValid)
            {
                var model = new Location
                {
                    LocationID = l.LocationID,
                    LocationName = l.LocationName,
                    LocationAddress = l.LocationAddress,
                    LocationDescription = l.LocationDescription,
                    LatitudeCoordinate = l.LatitudeCoordinate,
                    LongitudeCoordinate = l.LongitudeCoordinate,
                };
                locorepo.AddLocation(model);
            }
            else
            {
                return View(l);
            }
            return RedirectToAction("LocationList");
        }
    

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddHero(HeroVM h)
        {
            var repo = HeroRepoFactory.Create();

            if (ModelState.IsValid)
            {
                h.Organizations = new List<Organization>();

                var hero = new Hero
                {
                    HeroID = h.HeroID,
                    HeroName = h.HeroName,
                    Description = h.Description,

                    Sightings = h.Sightings,
                    Superpower = h.Superpower,

                };
                foreach (var OrganizationID in h.SelectedOrganizationsID)
                {
                    hero.Organizations.Add(orgrepo.GetOrganizationById(OrganizationID));
                }
                repo.AddHero(hero);
            }

            else
            {
                return View(h);
            }
            return RedirectToAction("HeroList");
        }

        public ActionResult HeroList()
        {
            var model = herorepo.GetAllHeroes();
            return View(model.ToList());
        }

        public ActionResult OrganizationList()
        {
            var model = orgrepo.GetAllOrganizations();
            return View(model.ToList());
        }

        public ActionResult LocationList()
        {
            var model = locorepo.GetAllLocations();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult EditOrganization(int id)
        {
            var org = orgrepo.GetOrganizationById(id);
            var model = new OrgVM
            {
                OrganizationID = org.OrganizationID,
                OrganizationName = org.OrganizationName,
                OganizationAddress = org.OganizationAddress,
                Phone = org.Phone,
                OrganizationLocation = org.OrganizationLocation,
            };
            foreach (var Hero in org.OrganizationHeroes)
            {
                model.SelectedHeroesID.Add(Hero.HeroID);
            }
            orgrepo.EditOrg(org);
            return View(model);
        }

        [HttpGet]
        public ActionResult EditLocation(int id)
        {
            var location = locorepo.GetLocationById(id);
            var model = new LocationVM
            {
                LocationID = location.LocationID,
                LocationName = location.LocationName,
                LocationAddress = location.LocationAddress,
                LocationDescription = location.LocationDescription,
                LatitudeCoordinate = location.LatitudeCoordinate,
                LongitudeCoordinate = location.LongitudeCoordinate,
            };
            locorepo.EditLocation(location);
            return View(model);
        }

        [HttpGet]
        public ActionResult EditHero(int id)
        {

            var hero = herorepo.GetHereosByID(id);
            var model = new HeroVM
            {
                HeroID = hero.HeroID,
                HeroName = hero.HeroName,
                Description = hero.Description,
                Superpower = hero.Superpower,

            };
            foreach (var Org in hero.Organizations)
            {
                model.SelectedOrganizationsID.Add(Org.OrganizationID);
            }
            herorepo.EditHero(hero);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditOrganization(OrgVM o)
        {
            if (ModelState.IsValid)
            {
                o.OrganizationHeroes = new List<Hero>();

                var orgToEdit = new Organization
                {
                    OrganizationID = o.OrganizationID,
                    OganizationAddress = o.OganizationAddress,
                    OrganizationLocation = locorepo.GetLocationById(o.OrganizationLocation.LocationID),
                    OrganizationName = o.OrganizationName,
                    Phone = o.Phone,                    
                };                
                foreach (var HeroID in o.SelectedHeroesID)
                {
                    orgToEdit.OrganizationHeroes.Add(herorepo.GetHereosByID(HeroID));
                }
                orgrepo.EditOrg(orgToEdit);
            }
            return RedirectToAction("OrganizationList");
        }

        [HttpPost]
        public ActionResult EditLocation(LocationVM l)
        {
            if (ModelState.IsValid)
            {
                var location = new Location
                {
                    LocationID = l.LocationID,
                    LocationName = l.LocationName,
                    LocationAddress = l.LocationAddress,
                    LocationDescription = l.LocationDescription,
                    LatitudeCoordinate = l.LatitudeCoordinate,
                    LongitudeCoordinate = l.LongitudeCoordinate,
                };
                locorepo.EditLocation(location);
            }
            return RedirectToAction("LocationList");
        }

        [HttpPost]
        public ActionResult EditHero(HeroVM h)
        {
            if (ModelState.IsValid)
            {
                h.Organizations = new List<Organization>();

                var hero = new Hero
                {
                    HeroID = h.HeroID,
                    HeroName = h.HeroName,
                    Description = h.Description,

                    Sightings = h.Sightings,
                    Superpower = h.Superpower,

                };
                foreach (var OrganizationID in h.SelectedOrganizationsID)
                {
                    hero.Organizations.Add(orgrepo.GetOrganizationById(OrganizationID));
                }
                herorepo.EditHero(hero);
            }
            return RedirectToAction("HeroList");
        }

        public ActionResult DeleteHero(int HeroID)
        {
            herorepo.DeleteHero(HeroID);

            return RedirectToAction("HeroList");
        }
             
        public ActionResult DeleteLocation(int LocationID)
        {
            locorepo.DeleteLocation(LocationID);
            return RedirectToAction("LocationList");
        }

        public ActionResult DeleteOrganization(int OrganizationID)
        {
            orgrepo.DeleteOrganization(OrganizationID);
            return RedirectToAction("OrganizationList");
        }

        public ActionResult DeleteSighting(int SightingID)
        {
            repo.DeleteSighting(SightingID);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult PendingSightings()
        {
            var repo = SightingRepoFactory.Create();

            var model = repo.GetPendingSightings();

            return View(model);
        }

        public ActionResult PublishSighting(int ID)
        {
            var repo = SightingRepoFactory.Create();

            Sighting sighting = repo.GetSightingsById(ID);

            sighting.Ispublished = true;

            repo.EditSighting(sighting);

            return RedirectToAction("PendingSightings");
        }
    }
}
