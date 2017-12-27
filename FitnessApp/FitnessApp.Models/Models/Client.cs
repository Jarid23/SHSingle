using FitnessApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public DateTime ClientJoinDate { get; set; }
        public int StartingWeight { get; set; }
        public int CurrentWeight { get; set; }
        public Trainer ClientTrainer { get; set; }
        public string FitnessGoals { get; set; }
        public List<int> SelectedTrainerID { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }

    }
}
