namespace FitnessApp.UI.Migrations
{
    using ClientRepo;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Models;
    using Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrainerRepo;
    using WorkoutRepo;

    internal sealed class Configuration : DbMigrationsConfiguration<FitnessApp.UI.FitnessDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FitnessApp.UI.FitnessDBContext context)
        {
            //create repos and userMGr and roleMgr to use throughout seed data
            ITrainerRepo orgrepo = TrainerRepoFactory.Create();
            IClientRepo herorepo = ClientRepoFactory.Create();
            IWorkoutRepo locorepo = WorkoutRepoFactory.Create();
            
            var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleMgr.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleMgr.Create(role);
            }

            if (!userMgr.Users.Any(u => u.UserName == "user"))
            {
                var user = new IdentityUser()
                {
                    UserName = "user"
                };
                userMgr.Create(user, "testing");
            }
            var findmanager = userMgr.FindByName("user");
            // create the user with the manager class
            if (!userMgr.IsInRole(findmanager.Id, "user"))
            {
                userMgr.AddToRole(findmanager.Id, "user");
            }

            if (!roleMgr.RoleExists("admin"))
            {
                roleMgr.Create(new IdentityRole() { Name = "admin" });
            }

            if (!userMgr.Users.Any(u => u.UserName == "admin"))
            {
                var user = new IdentityUser()
                {
                    UserName = "admin"
                };
                userMgr.Create(user, "testing");
            }
            var finduser = userMgr.FindByName("admin");
            // create the user with the manager class
            if (!userMgr.IsInRole(finduser.Id, "admin"))
            {
                userMgr.AddToRole(finduser.Id, "admin");
            }

            if (!context.Trainers.Any(t => t.TrainerName == "Arnold"))
            {
                var firsttrainer = new Trainer
                {
                    TrainerName = "Arnold",
                    TrainerID = 1,
                    HourlyRate = 25,
                    StartDate = new DateTime(2017, 1, 18),
                    
                };
                context.Trainers.Add(firsttrainer);
                context.SaveChanges();
            }
            var trainer = context.Trainers.First(t => t.TrainerName == "Arnold");

            if (!context.Clients.Any(c => c.ClientName == "Jarid"))
            {
                var firstclient = new Client
                {
                    ClientName = "Jarid",
                    ClientID = 1,
                    ClientJoinDate = new DateTime(2017, 3, 23),
                    CurrentWeight = 158,
                    StartingWeight = 133,
                    FitnessGoals = "I gotta get jacked so girls will want this hot body",
                    
                };
                context.Clients.Add(firstclient);
                context.SaveChanges();
            }
            var client = context.Clients.First(c => c.ClientName == "Jarid");

            if (!context.Workouts.Any(w => w.WorkoutName == "5x5 StrongLifts"))
            {
                var firstworkout = new Workout
                {
                    WorkoutID = 1,
                    WorkoutName = "5x5 StrongLifts",
                    WorkoutDescription = "5 sets of 5 reps. Squat, Bench, Deadlift, Overhead and Row. Add 5 pounds after each workout.",
                                                          
                };
                context.Workouts.Add(firstworkout);
                context.SaveChanges();
            }
            var workout = context.Workouts.First(w => w.WorkoutName == "5x5 StrongLifts");
        }
    }
}
