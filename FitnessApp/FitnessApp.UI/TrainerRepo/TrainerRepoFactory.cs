using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.UI.TrainerRepo
{
    public class TrainerRepoFactory
    {
        public static ITrainerRepo Create()
        {            
            string mode = ConfigurationManager.AppSettings["Trainer"].ToString();

            switch (mode)
            {
                case "EF":
                    return new EFTrainerRepo();
                case "Mock":
                    return new MockTrainerRepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
