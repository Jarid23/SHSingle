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
            var context = new SuperheroDBContext();
            if (ModelState.IsValid)
            {
                //s.SightingHeroes = new List<Hero>();

                //foreach (var id in s.SightingObject.SighintgHeroes)
                //s.SightingObject.SighintgHeroes.Add(herorepo.GetHereosByID(id.HeroID));

                //s.SightingObject.SightingLocation = locationrepo.GetLocationById(s.SightingObject.SightingLocation.LocationID);

                //s.SightingObject.SighintgHeroes.Add(s.SightingHeroes);

                repo.AddSighting(s.SightingObject);
               
            }
            else
            {
                return View(s);
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult EditSighting()
        {
            return View();
        }
    }
}