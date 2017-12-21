using FitnessApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.UI.WorkoutRepo
{
    public interface IWorkoutRepo
    {
        void AddWorkout(Workout workout);
        void EditWorkout(Workout workout);
        void DeleteWorkout(int WorkoutID);
        IEnumerable<Workout> GetAllWorkouts();
    }
}
