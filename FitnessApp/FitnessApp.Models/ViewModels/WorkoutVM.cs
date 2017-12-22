using FitnessApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models.ViewModels
{
   public class WorkoutVM
    {
        public string WorkoutName { get; set; }
        public string WorkoutDescription { get; set; }
        public Trainer TrainerCreator { get; set; }
        public ICollection<Client> ClientsOnWorkout { get; set; }
    }
}
