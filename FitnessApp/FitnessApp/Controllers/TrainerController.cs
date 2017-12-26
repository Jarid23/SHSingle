using FitnessApp.Models.ViewModels;
using FitnessApp.UI.ClientRepo;
using FitnessApp.UI.TrainerRepo;
using FitnessApp.UI.WorkoutRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessApp.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult AddClient()
        {
            return View(new ClientVM());
        }

        public ActionResult WorkoutList()
        {
            IWorkoutRepo repo = WorkoutRepoFactory.Create();
            var model = repo.GetAllWorkouts();
            return View(model);
        }

        public ActionResult ClientList()
        {
            IClientRepo repo = ClientRepoFactory.Create();
            var model = repo.GetAllClients();
            return View(model);
        }
    }
}