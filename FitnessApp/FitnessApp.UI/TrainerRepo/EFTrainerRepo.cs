using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Models.Models;

namespace FitnessApp.UI.TrainerRepo
{
    public class EFTrainerRepo : ITrainerRepo
    {
        public void AddTrainer(Trainer trainer)
        {
            using (var db = new FitnessDBContext())
            {
                db.Trainers.Add(trainer);
                db.SaveChanges();
            }
        }

        public void DeleteTrainer(int TrainerID)
        {
            using (var db = new FitnessDBContext())
            {
                var trainerToRemove = db.Trainers.SingleOrDefault(t => t.TrainerID == TrainerID);
                if (trainerToRemove != null)
                {
                    db.Trainers.Remove(trainerToRemove);
                }
                db.SaveChanges();
            }
        }

        public void EditTrainer(Trainer trainer)
        {
            using (var db = new FitnessDBContext())
            {
                var toEdit = db.Trainers.SingleOrDefault(t => t.TrainerID == trainer.TrainerID);

                if (toEdit != null)
                {
                    toEdit.TrainerName = trainer.TrainerName;
                    toEdit.StartDate = trainer.StartDate;
                    toEdit.HourlyRate = trainer.HourlyRate;
                    toEdit.Clientelle = trainer.Clientelle;                    
                }
                db.SaveChanges();
            }
        }

        public IEnumerable<Trainer> GetAllTrainers()
        {
            using (var db = new FitnessDBContext())
            {
                var trainers = from t in db.Trainers
                               select t;
                return trainers.ToList();

            }
        }

        public Trainer GetTrainerById(int TrainerID)
        {
            using (var context = new FitnessDBContext())
            {
                return context.Trainers.Where(t => t.TrainerID == TrainerID).FirstOrDefault();
            }
        }
    }
}
