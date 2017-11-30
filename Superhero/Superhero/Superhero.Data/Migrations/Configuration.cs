namespace Superhero.Data.Migrations
{
    using HeroRepository;
    using LocationRepository;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using OrganizationRepository;
    using SightingRepository;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
            IOrgRepo orgrepo = OrgRepoFactory.Create();
            IHeroRepo herorepo = HeroRepoFactory.Create();
            ILocationRepo locorepo = LocationRepoFactory.Create();
            ISightingRepo sightingrepo = SightingRepoFactory.Create();
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
            var firstlocation = new Location
            {
                LocationName = "Minneapolis",
                LocationAddress = "The Twin Cities",
                LocationDescription = "A lovely city",
                LatitudeCoordinate = 100,
                LongitudeCoordinate = 100,
            };
            context.Locations.Add(firstlocation);

            var firstorg = new Organization
            {
                OrganizationName = "Minneapolis Hero Squad",
                OganizationAddress = "S 5th street Minneapolis",
                OrganizationLocation = firstlocation,
                Phone = "123-456-7899",
            };
            context.Organizations.Add(firstorg);

            var firsthero = new Hero
            {
                HeroName = "The Flash",
                Organizations = new Collection<Organization>()
                {
                    firstorg
                },
                Description = "Wears a red/yellow suit",
                Superpower = "Runs really fast",
            };
            context.Heroes.Add(firsthero);

            var firstsighting = new Sighting
            {
                SightingLocation = firstlocation,
                SightingHeroes = new Collection<Hero>()
                {
                    firsthero
                },
                Date = DateTime.Today,
                SightingDescription = "We saw the Flash in Minneapolis",
                IsDeleted = false,
                Ispublished = true,
            };
            context.Sightings.Add(firstsighting);
        }
    }
}
                







