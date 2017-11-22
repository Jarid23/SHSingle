using Superhero.Data;
using Superhero.Data.HeroRepository;
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
        // GET: Admin
        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult AddHero()
        {
            return View(new Hero());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddHero(HeroVM h)
        {
            return View();
            //var repo = HeroRepoFactory.Create();
            //var context = new SuperheroDBContext();
            //if (ModelState.IsValid)
            //{
            //    Hero hero = new Hero();
            //    {
            //        hero = new Hero
            //        {
            //            HeroID = h.HeroID,
            //            HeroName = h.HeroName,
            //            Description = h.Description,
            //            //do these need to be list ?
            //            Organizations = h.Organizations,
            //            Sightings = h.Sightings,
            //            Superpower = h.Superpower,
            //        };
            //    }

            //    return View(hero);
            //}


        }

        public ActionResult EditHero()
        {
            return View();
        }

        public ActionResult DeleteHero()
        {
            return View();
        }

        public ActionResult AddLocation()
        {
            return View();
        }

        public ActionResult EditLocation()
        {
            return View();
        }

        public ActionResult DeleteLocation()
        {
            return View();
        }

        public ActionResult AddOrganization()
        {
            return View();
        }

        public ActionResult EditOrganization()
        {
            return View();
        }

        public ActionResult DeleteOrganization()
        {
            return View();
        }

        public ActionResult DeleteSighting()
        {
            return View();
        }

    }
}
