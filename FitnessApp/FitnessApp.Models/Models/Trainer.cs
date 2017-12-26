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

        public Trainer()
        {
            Clients = new HashSet<Client>();
        }

        public string TrainersAsHtml()
        {
            string result = "";
            if (Clients != null && Clients.Count > 0)
            {
                foreach (var client in Clients)
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
