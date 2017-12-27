using FitnessApp.Models.Models;
using FitnessApp.UI.ClientRepo;
using FitnessApp.UI.TrainerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FitnessApp.Models.ViewModels
{
    public class WorkoutVM
    {
        IClientRepo crepo = ClientRepoFactory.Create();
        ITrainerRepo repo = TrainerRepoFactory.Create();
        public int WorkoutID { get; set; }
        public string WorkoutName { get; set; }
        public string WorkoutDescription { get; set; }
        public ICollection<Trainer> TrainerCreator { get; set; }
        public ICollection<Client> ClientsOnWorkout { get; set; }
        public List<SelectListItem> TrainerList { get; set; }
        public List<int> SelectedTrainerID { get; set; }
        public List<SelectListItem> ClientList { get; set; }
        public List<int> SelectedClientID { get; set; }

        public WorkoutVM()
        {
            TrainerList = new List<SelectListItem>();
            var AllTrainers = repo.GetAllTrainers();
            SelectedTrainerID = new List<int>();

            ClientList = new List<SelectListItem>();
            var AllClients = crepo.GetAllClients();
            SelectedClientID = new List<int>();

            foreach (var client in AllClients)
            {
                ClientList.Add(new SelectListItem
                {
                    Value = client.ClientID.ToString(),
                    Text = client.ClientName
                });
            }

            foreach (var trainer in AllTrainers)
            {

                TrainerList.Add(new SelectListItem
                {
                    Value = trainer.TrainerID.ToString(),
                    Text = trainer.TrainerName
                });

            }
        }
    }
}

