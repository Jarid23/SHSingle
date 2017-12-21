using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.UI.WorkoutRepo
{
    public class WorkoutRepoFactory
    {
        public static IWorkoutRepo Create()
        {
            string mode = ConfigurationManager.AppSettings["Workout"].ToString();

            switch (mode)
            {
                case "EF":
                    return new EFWorkoutRepo();
                case "Mock":
                    return new MockWorkoutRepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
