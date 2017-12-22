using FitnessApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models.ViewModels
{
    public class TrainerVM
    {
        public string TrainerName { get; set; }
        public int HourlyRate { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
