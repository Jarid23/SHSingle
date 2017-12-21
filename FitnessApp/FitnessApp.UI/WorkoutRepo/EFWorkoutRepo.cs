using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Models.Models;

namespace FitnessApp.UI.WorkoutRepo
{
    public class EFWorkoutRepo : IWorkoutRepo
    {
        public void AddWorkout(Workout workout)
        {
            using (var db = new FitnessDBContext())
            {
                db.Workouts.Add(workout);
                db.SaveChanges();
            }
        }

        public void DeleteWorkout(int WorkoutID)
        {
            using (var db = new FitnessDBContext())
            {
                var toRemove = db.Workouts.SingleOrDefault(w => w.WorkoutID == WorkoutID);
                if (toRemove != null)
                {
                    db.Workouts.Remove(toRemove);
                }
                db.SaveChanges();
            }
        }

        public void EditWorkout(Workout workout)
        {
            using (var db = new FitnessDBContext())
            {
                var toEdit = db.Workouts.SingleOrDefault(w => w.WorkoutID == workout.WorkoutID);
                if (toEdit != null)
                {
                    toEdit.WorkoutName = workout.WorkoutName;
                    toEdit.WorkoutDescription = workout.WorkoutDescription;
                    toEdit.TrainerCreator = workout.TrainerCreator;
                    toEdit.ClientsOnWorkout = workout.ClientsOnWorkout;
                }
                db.SaveChanges();
            }
        }

        public IEnumerable<Workout> GetAllWorkouts()
        {
            using (var db = new FitnessDBContext())
            {
                var workouts = from w in db.Workouts
                               select w;
                return workouts.ToList();
               
            }
        }
    }
}
