using FitnessApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.UI.TrainerRepo
{
    public interface ITrainerRepo
    {
        void AddTrainer(Trainer trainer);
        void EditTrainer(Trainer trainer);
        void DeleteTrainer(int TrainerID);
        IEnumerable<Trainer> GetAllTrainers();

    }
}
