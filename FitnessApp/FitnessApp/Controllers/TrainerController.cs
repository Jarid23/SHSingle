using FitnessApp.Models.Models;
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

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddClient(ClientVM c)
        {
            ITrainerRepo trepo = TrainerRepoFactory.Create();
            IClientRepo repo = ClientRepoFactory.Create();
            if (ModelState.IsValid)
            {
                c.Trainers = new List<Trainer>();

                var client = new Client
                {
                    Trainers = new List<Trainer>(),
                    ClientName = c.ClientName,
                    StartingWeight = c.StartingWeight,
                    CurrentWeight = c.CurrentWeight,
                    FitnessGoals = c.FitnessGoals,                    
                };
                foreach (var trainerID in c.SelectedTrainerID)
                {
                    client.Trainers.Add(trepo.GetTrainerById(trainerID));                       
                }
                repo.AddClient(client);
            }
           
            else
            {
                return View(c);
            }
                return RedirectToAction("ClientList");
            }
        

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult EditClient(int id)
        {
            IClientRepo repo = ClientRepoFactory.Create();
            var client = repo.GetClientById(id);
            var model = new ClientVM
            {
                ClientId = client.ClientID,
                ClientName = client.ClientName,
                StartingWeight = client.StartingWeight,
                CurrentWeight = client.CurrentWeight,
                FitnessGoals = client.FitnessGoals,
                ClientTrainer = client.ClientTrainer
            };           
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditClient(ClientVM c)
        {
            IClientRepo repo = ClientRepoFactory.Create();
            ITrainerRepo trepo = TrainerRepoFactory.Create();
            if (ModelState.IsValid)
            {
                var client = new Client
                {                   
                    Trainers = new List<Trainer>(),
                    ClientID = c.ClientId,
                    ClientName = c.ClientName,
                    StartingWeight = c.StartingWeight,
                    CurrentWeight = c.CurrentWeight,
                    FitnessGoals = c.FitnessGoals,
                };
                foreach (var trainerID in c.SelectedTrainerID)
                {
                    client.Trainers.Add(trepo.GetTrainerById(trainerID));
                }
                repo.EditClient(client);
            }
            return RedirectToAction("ClientList");
        }

        public ActionResult DeleteClient(int ClientId)
        {
            IClientRepo repo = ClientRepoFactory.Create();
            repo.DeleteClient(ClientId);

            return RedirectToAction("ClientList");
        }

        public ActionResult DeleteWorkout(int WorkoutId)
        {
            IWorkoutRepo repo = WorkoutRepoFactory.Create();
            repo.DeleteWorkout(WorkoutId);

            return RedirectToAction("WorkoutList");
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult AddWorkout()
        {
            return View(new WorkoutVM());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddWorkout(WorkoutVM w)
        {
            ITrainerRepo trepo = TrainerRepoFactory.Create();
            IClientRepo repo = ClientRepoFactory.Create();
            IWorkoutRepo wrepo = WorkoutRepoFactory.Create();
            if (ModelState.IsValid)
            {
                w.ClientsOnWorkout = new List<Client>();

                var workout = new Workout
                {
                    TrainerCreator = new List<Trainer>(),
                    ClientsOnWorkout = new List<Client>(),
                    WorkoutName = w.WorkoutName,
                    WorkoutDescription = w.WorkoutDescription,
                    
                    
                };
                foreach (var trainerID in w.SelectedTrainerID)
                {
                    workout.TrainerCreator.Add(trepo.GetTrainerById(trainerID));
                }
                foreach (var clientID in w.SelectedClientID)
                {
                    workout.ClientsOnWorkout.Add(repo.GetClientById(clientID));
                }
                wrepo.AddWorkout(workout);
            }

            else
            {
                return View(w);
            }
            return RedirectToAction("WorkoutList");
        }

        public ActionResult EditWorkout(int id)
        {
            IWorkoutRepo repo = WorkoutRepoFactory.Create();
            var workout = repo.GetWorkoutById(id);
            var model = new WorkoutVM
            {
                WorkoutID = workout.WorkoutID,
                WorkoutName = workout.WorkoutName,
                WorkoutDescription = workout.WorkoutDescription,
                ClientsOnWorkout = workout.ClientsOnWorkout,
                TrainerCreator = workout.TrainerCreator
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditWorkout(WorkoutVM w)
        {
            IWorkoutRepo wrepo = WorkoutRepoFactory.Create();
            IClientRepo repo = ClientRepoFactory.Create();
            ITrainerRepo trepo = TrainerRepoFactory.Create();
            if (ModelState.IsValid)
            {
                var workout = new Workout
                {
                    WorkoutID = w.WorkoutID,
                    WorkoutName = w.WorkoutName,
                    WorkoutDescription = w.WorkoutDescription,                                       
                };
                foreach (var trainerID in w.SelectedTrainerID)
                {
                    workout.TrainerCreator.Add(trepo.GetTrainerById(trainerID));
                }
                foreach (var clientID in w.SelectedClientID)
                {
                    workout.ClientsOnWorkout.Add(repo.GetClientById(clientID));
                }
                wrepo.EditWorkout(workout);
            }
            return RedirectToAction("WorkoutList");
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