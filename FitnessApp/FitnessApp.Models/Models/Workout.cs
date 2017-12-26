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

        public Workout()
        {
            ClientsOnWorkout = new HashSet<Client>();
        }

        public string WorkoutsAsHtml()
        {
            string result = "";
            if (ClientsOnWorkout != null && ClientsOnWorkout.Count > 0)
            {
                foreach (var client in ClientsOnWorkout)
                {
                    result += client.ClientName + ',';
                }
                if (!string.IsNullOrEmpty(result))
                {
                    result = result.Substring(0, result.Length - 1);
                }
            }
            return result;
        }

    }
}
