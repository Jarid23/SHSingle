using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Models.Models;

namespace FitnessApp.UI.WorkoutRepo
{
    public class MockWorkoutRepo : IWorkoutRepo
    {
        private static List<Workout> _workouts = new List<Workout>
        {
            new Workout
            {
                WorkoutID = 1,
                WorkoutName = "5 by 5 lifting",
                WorkoutDescription = "Do 5 sets of 5 reps of squat, bench, deadlift, overhead and row. Add 5 pounds after each workout.",
                ClientsOnWorkout = new List<Client>
                {
                    new Client
                    {
                        ClientName = "Jarid"
                    }
                },
                TrainerCreator = new List<Trainer>
                {
                    new Trainer {
                    TrainerName = "Arnold Schwarzenegger"
                        }
                } } };

        public void AddWorkout(Workout workout)
        {
            _workouts.Add(workout);
        }

        public void DeleteWorkout(int WorkoutID)
        {
            _workouts.RemoveAll(t => t.WorkoutID == WorkoutID);
        }

        public void EditWorkout(Workout workout)
        {
            var w = new Workout();
            foreach (var toEdit in _workouts)
            {
                if (toEdit.WorkoutID == workout.WorkoutID)
                {
                    toEdit.WorkoutName = workout.WorkoutName;
                    toEdit.WorkoutDescription = workout.WorkoutDescription;
                    toEdit.TrainerCreator = workout.TrainerCreator;
                    toEdit.ClientsOnWorkout = workout.ClientsOnWorkout;
                }
            }
            w = workout;
        }

        public IEnumerable<Workout> GetAllWorkouts()
        {
            return _workouts;
        }

        public Workout GetWorkoutById(int WorkoutID)
        {
            foreach (var workout in _workouts)
            {
                if (workout.WorkoutID == WorkoutID)
                {
                    return workout;
                }
            }
            return new Workout();
        }
    }
}
