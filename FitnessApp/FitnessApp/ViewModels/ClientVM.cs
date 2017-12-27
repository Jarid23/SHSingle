using FitnessApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.UI.TrainerRepo;
using System.Web.Mvc;

namespace FitnessApp.Models.ViewModels
{
    public class ClientVM
    {
        ITrainerRepo repo = TrainerRepoFactory.Create();
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int StartingWeight { get; set; }
        public int CurrentWeight { get; set; }
        public Trainer ClientTrainer { get; set; }
        public string FitnessGoals { get; set; }
        public List<SelectListItem> TrainerList { get; set; }
        public List<int> SelectedTrainerID { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }

        public ClientVM()
        {
            TrainerList = new List<SelectListItem>();
            var AllTrainers = repo.GetAllTrainers();
            SelectedTrainerID = new List<int>();

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
