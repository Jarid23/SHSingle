namespace Superhero.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Superhero.Data.SuperheroDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Superhero.Data.SuperheroDBContext context)
        {
            var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleMgr.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
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

            context.Heroes.AddOrUpdate(h => h.HeroName,
                new Hero
                {
                    HeroID = 1,
                    HeroName = "Hero1",
                    Description = "Can Fly",
                    //Need to figure how to differntiate between list and singles
                    Organizations = new List<Organization>
                    {

                    new Organization
                    {
                        OrganizationID = 1,
                        OganizationAddress = "OrganizationAddress1",
                        OrganizationName = "OrganizationName1",
                        Phone = "123-456-7890",
                        //OrganizationHeroes =
                       
                        //This seems to create an infite loop. The hero needs an orgnization then the Org needs a hero
                    }
                    },

                    Sightings = new List<Sighting>
                    {
                    new Sighting
                    {
                        SightingID = 1,
                        Date = DateTime.Now,
                        //LocationName = "Minneapolis",
                        Ispublished = true,
                    }
                    },
            Superpower = "Can Fly"
                }
                );

            context.Locations.AddOrUpdate(l => l.LocationAddress,
              new Location
              {
                  LocationID = 1,
                  LocationName = "LocationName1",
                  LocationAddress = "LocationAddress1",
                  LocationDescription = "LocationDescription1",
                  LatitudeCoordinate = 1,
                  LongitudeCoordinate = 1
              }
              );

            context.Organizations.AddOrUpdate(o => o.OrganizationName,
              new Organization
              {
                  OrganizationID = 1,
                  OrganizationName = "OrganizationName1",
                  OganizationAddress = "OrganizationAddress1",
                  //How do I seed an IENumerbale or I need to differntiate to a single
                  // OrganizationHeroes = Hero1,
                  Phone = "123-456-7890",
              }
              );

            context.Sightings.AddOrUpdate(s => s.SightingID,
              new Sighting
              {
                  Date = DateTime.Today,
                  //Need to figure out lstings
                  //Hero = Hero1,
                  Ispublished = true,
                  IsDeleted = false,
                  //LocationName = "LocationName1",
                  SightingID = 1

              }
              );


        }
    }
}



