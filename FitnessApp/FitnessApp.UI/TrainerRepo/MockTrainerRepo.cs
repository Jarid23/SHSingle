using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Models.Models;

namespace FitnessApp.UI.TrainerRepo
{
    public class MockTrainerRepo : ITrainerRepo
    {
        private static List<Trainer> _trainers = new List<Trainer>
        {
            new Trainer
            {
                TrainerID = 1,
                TrainerName = "Julie",
                HourlyRate = 30,
                StartDate = DateTime.Today,
                Clients = new List<Client>
                {
                    new Client
                    {
                        ClientName = "Jarid"
                    }                    
                    } }
            };
        public void AddTrainer(Trainer trainer)
        {
            _trainers.Add(trainer);
        }

        public void DeleteTrainer(int TrainerID)
        {
            _trainers.RemoveAll(t => t.TrainerID == TrainerID);
        }

        public void EditTrainer(Trainer trainer)
        {
            var t = new Trainer();
            foreach (var toEdit in _trainers)
            {
                if (toEdit.TrainerID == trainer.TrainerID)
                {
                    toEdit.TrainerName = trainer.TrainerName;
                    toEdit.StartDate = trainer.StartDate;
                    toEdit.HourlyRate = trainer.HourlyRate;
                    toEdit.Clients = trainer.Clients;                    
                }
            }
            t = trainer;
        }

        public IEnumerable<Trainer> GetAllTrainers()
        {
            return _trainers;
        }
    }
}
