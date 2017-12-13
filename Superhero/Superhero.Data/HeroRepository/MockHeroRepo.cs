using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superhero.Model.Models;

namespace Superhero.Data.HeroRepository
{
    public class MockHeroRepo : IHeroRepo
    {
        private static List<Hero> _heroes = new List<Hero>
        {
            new Hero
            {
                    HeroID = 1,
                    HeroName = "Hero1",
                    Description = "Can Fly",
                    Superpower = "Can Fly and Laser Eyes",
                    //Need to figure how to differntiate between list and singles
                    Organizations = new List<Organization>
                    {
                        new Organization
                        {
                            OrganizationID= 1,
                            OganizationAddress = "OrgAddress1",
                            OrganizationName = "OrgName1",
                            Phone = "1234567890",
                            OrganizationLocation = new Location
                            {
                                LocationID = 2,
                                LocationAddress = "LocationAddress1",
                                LocationName = "The South Pole",
                                LatitudeCoordinate = 1,
                                LongitudeCoordinate = 1,
                                LocationDescription = "The South Pole where Superman lives"
                            }
                        }
                    },
                    Sightings = new List<Sighting>
                    {
                        new Sighting
                        {
                         SightingID = 1,
                         Ispublished = true,
                         IsDeleted = false,
                     } }
            },
            new Hero
            {
                    HeroID = 23,
                    HeroName = "Hero23",
                    Description = "This hero is like a ninja turtle",
                    Superpower = "Unbreakable shell",
                } };



        public void AddHero(Hero hero)
        {
            _heroes.Add(hero);
        }

        public void DeleteHero(int HeroID)
        {
            _heroes.RemoveAll(h => h.HeroID == HeroID);
        }

        public void EditHero(Hero hero)
        {
            var h = new Hero();
            foreach (var heroo in _heroes)
            {
                if (heroo.HeroID == hero.HeroID)
                {
                    heroo.Description = hero.Description;
                    heroo.HeroName = hero.HeroName;
                    heroo.Organizations = hero.Organizations;
                    heroo.Sightings = hero.Sightings;
                    heroo.Superpower = hero.Superpower;

                }
            }
            h = hero;
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            return _heroes;
        }

        public Hero GetHereosByID(int HeroID)
        {
            foreach (var hero in _heroes)
            {
                if (hero.HeroID == HeroID)
                {
                    return hero;
                }
            }
            return new Hero();
        }


        public IEnumerable<Hero> GetHereosByOrganization(int OrganizationID)
        {

            var heroes = _heroes.Where(h => h.Organizations.Any(o => o.OrganizationID == OrganizationID));
            if (heroes != null)
            {
                return heroes;
            }
            return null;
        }

        public IEnumerable<Hero> GetHereosBySighting(int SightingID)
        {

            var heroes = _heroes.Where(h => h.Sightings.Any(s => s.SightingID == SightingID));
            if (heroes != null)
            {
                return heroes;
            }
            return null;
        }
    }
}
