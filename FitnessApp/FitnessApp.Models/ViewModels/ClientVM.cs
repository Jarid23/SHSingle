using FitnessApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models.ViewModels
{
   public class ClientVM
    {
        public string ClientName { get; set; }
        public int StartingWeight { get; set; }
        public int CurrentWeight { get; set; }
        public Trainer Trainer { get; set; }
        public string FitnessGoals { get; set; }
    }
}
