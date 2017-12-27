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
        public ICollection<Client> Clientelle { get; set; }

        public Trainer()
        {
            Clientelle = new HashSet<Client>();
        }

        public string TrainersAsHtml()
        {
            string result = "";
            if (Clientelle != null && Clientelle.Count > 0)
            {
                foreach (var client in Clientelle)
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
