namespace CarDealership.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Users;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDBContext context)
        {
            var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleMgr.RoleExists("Sales"))
            {
                var role = new IdentityRole();
                role.Name = "Sales";
                roleMgr.Create(role);
            }

            if (!userMgr.Users.Any(u => u.UserName == "Sales"))
            {
                var user = new AppUser()
                {
                    UserName = "Sales",
                    FirstName = "Jarid",
                    LastName = "Wagner",
                    Email = "jaridwagnersoftware@gmail.com",
                };
                userMgr.Create(user, "testing1234");
            }
            var findmanager = userMgr.FindByName("Jarid");
            // create the user with the Sales class
            if (!userMgr.IsInRole(findmanager.Id, "Sales"))
            {
                userMgr.AddToRole(findmanager.Id, "Sales");
            }

            if (!roleMgr.RoleExists("admin"))
            {
                roleMgr.Create(new IdentityRole() { Name = "admin" });
            }

            if (!userMgr.Users.Any(u => u.UserName == "admin"))
            {
                var user = new AppUser()
                {
                    UserName = "admin",
                    FirstName = "David",
                    LastName = "Wagner",
                    Email = "davidwagner@gmail.com",
                };
                userMgr.Create(user, "testing123");
            }
            var finduser = userMgr.FindByName("admin");
            // create the user with the admin class
            if (!userMgr.IsInRole(finduser.Id, "admin"))
            {
                userMgr.AddToRole(finduser.Id, "admin");
            }
        }
    }
}
