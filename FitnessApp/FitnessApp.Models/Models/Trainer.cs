using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models.Models
{
    public class Trainer
    {
        public int TrainerID { get; set; }
        public string TrainerName { get; set; }
        public DateTime StartDate { get; set; }
        public int HourlyRate { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
