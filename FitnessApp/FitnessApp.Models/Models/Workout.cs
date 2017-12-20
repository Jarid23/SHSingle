using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models.Models
{
    public class Workout
    {
        public int WorkoutID { get; set; }
        public string WorkoutName { get; set; }
        public string WorkoutDescription { get; set; }
        public Trainer TrainerCreator { get; set; }
        public ICollection<Client> ClientsOnWorkout { get; set; }

    }
}
