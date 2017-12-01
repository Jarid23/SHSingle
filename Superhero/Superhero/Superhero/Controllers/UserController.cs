using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View(new ChangePasswordVM());
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordVM password)
        {
            using (var db = new SuperheroDBContext())
            {
                if (password.newPassword == password.newPasswordConfirm)
                {
                    var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(db));

                    userMgr.ChangePassword(User.Identity.GetUserId(), password.oldPassword, password.newPassword);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("newPassword", "Passwords must be the same");
                }
                return View(password);
            }
        }

        [HttpGet]
        public ActionResult AddSighting()
        {
            return View(new SightingVM());
        }


        [HttpPost]
        public ActionResult AddSighting(SightingVM s)
        {
            IHeroRepo herorepo = HeroRepoFactory.Create();
            ISightingRepo repo = SightingRepoFactory.Create();
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
            IHeroRepo herorepo = HeroRepoFactory.Create();
            ISightingRepo repo = SightingRepoFactory.Create();
            Sighting s = repo.GetSightingsById(SightingID);
            //int locationid = s.SightingLocation.LocationID;
            var model = new SightingVM()
            {                                
                SightingObject = repo.GetSightingsById(SightingID),              
                Date = s.Date,
                SightingHeroes = herorepo.GetAllHeroes(),
                SightingID = s.SightingID
            };
            foreach (var hero in s.SightingHeroes)
            {
                model.SelectedHeroesID.Add(hero.HeroID);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditSighting(SightingVM s)
        {
            IHeroRepo herorepo = HeroRepoFactory.Create();
            ISightingRepo repo = SightingRepoFactory.Create();
            ILocationRepo locationrepo = LocationRepoFactory.Create();
           
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

                s.SightingObject.SightingLocation = locationrepo.GetLocationById(s.SightingObject.SightingLocation.LocationID);

                Sighting sighting = new Sighting
                {
                    Ispublished = true,
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

