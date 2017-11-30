using Superhero.Data;
using Superhero.Data.HeroRepository;
using Superhero.Data.LocationRepository;
using Superhero.Data.SightingRepository;
using Superhero.Model.Models;
using Superhero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Superhero.Controllers
{
    public class UserController : Controller
    {
        ILocationRepo locationrepo = LocationRepoFactory.Create();
        ISightingRepo repo = SightingRepoFactory.Create();
        IHeroRepo herorepo = HeroRepoFactory.Create();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View(new ChangePasswordVM());
        }

        [HttpGet]
        public ActionResult AddSighting()
        {
            return View(new SightingVM());
        }


        [HttpPost]
        public ActionResult AddSighting(SightingVM s)
        {          
            if (ModelState.IsValid)
            {
                s.SightingHeroes = new List<Hero>();

                foreach (var HeroID in s.SelectedHeroesID)
                {
                    s.SightingObject.SightingHeroes.Add(herorepo.GetHereosByID(HeroID));
                }
                repo.AddSighting(s.SightingObject);
            }
            else
            {
                return View(s);
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [ValidateInput(false)]
        public ActionResult EditSighting(int SightingID)
        {
            Sighting s = repo.GetSightingsById(SightingID);
            int locationid = s.SightingLocation.LocationID;

            var model = new SightingVM()
            {
                SightingObject = repo.GetSightingsById(SightingID),              
                Date = s.Date,
                SightingHeroes = herorepo.GetAllHeroes(),
                SightingID = s.SightingID
            };

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditSighting(SightingVM s)
        {
            var context = new SuperheroDBContext();
            if (ModelState.IsValid)
            {                             
                foreach (var hero in s.SightingHeroes)
                {
                    s.SightingObject.SightingHeroes.Remove(hero);
                }

                foreach (var HeroID in s.SelectedHeroesID)
                {
                    s.SightingObject.SightingHeroes.Add(herorepo.GetHereosByID(HeroID));
                }

                // s.SightingObject.SightingLocation = locationrepo.GetLocationById(s.SightingObject.SightingLocation.LocationID);
                // s.SightingLocation = locationrepo.GetLocationById(LocationID));
                // s.SightingObject.SightingLocation.LocationID

                s.SightingObject.SightingLocation = locationrepo.GetLocationById(s.SightingObject.SightingLocation.LocationID);

                Sighting sighting = new Sighting
                {
                    SightingHeroes = s.SightingObject.SightingHeroes,
                    SightingID = s.SightingObject.SightingID,
                    SightingLocation = s.SightingObject.SightingLocation,
                    SightingDescription = s.SightingObject.SightingDescription,
                    Date = s.SightingObject.Date
                };
                repo.EditSighting(sighting);
            }
            else
            {
                return View(s);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

