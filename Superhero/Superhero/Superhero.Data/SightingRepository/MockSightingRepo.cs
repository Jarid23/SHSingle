using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superhero.Model.Models;

namespace Superhero.Data.SightingRepository
{
    //This Mock Repo Inherits an interface that gives it CRUD operations and 4 listing functions
    //A Mock repo contains hard-coded data so we can test functionality without connecting to the database
    public class MockSightingRepo : ISightingRepo
    {
        private static List<Sighting> _sightings = new List<Sighting>
        {
            new Sighting
            {
                SightingID = 1,
                Date = DateTime.Now,
                Ispublished = true,
                IsDeleted = false,
                SightingLocation = new Location
                {
                    LocationID = 2,
                    LocationName ="Ice Palace",
                    LocationAddress = "NorthPole",
                    LocationDescription = "Very Cold, although climate change is making it more palatable",
                    LatitudeCoordinate = 1,
                    LongitudeCoordinate = 1
                },
                SighintgHeroes = new List<Hero>
                {
                    new Hero
                    {
                        HeroID = 2,
                        HeroName = "Jarid",
                        Description = "We'll say I burrow underground",
                        Superpower = "I'm like a hedgehog I guess",
                    }
                 },
            }
        };




        //Sighting requires a list of heroes which requires instantiating a new hero, possibly add all properties ?


        public IEnumerable<Sighting> GetNumberOfSightings(int number, int set)
        {
            return _sightings.Skip(number * set).Take(number).ToList();
        }

        public IEnumerable<Sighting> GetPendingSightings()
        {
            return _sightings.Where(s => s.Ispublished == false).ToList();
        }

        public IEnumerable<Sighting> GetSighintsByDate(string date)
        {
            var day = DateTime.Parse(date);
            return _sightings.Where(b => b.Date == day).ToList();
        }

        public Sighting GetSightingsById(int SightingID)
        {
            foreach (var sighting in _sightings)
            {
                if (sighting.SightingID == SightingID)
                {
                    return sighting;
                }
            }
            return new Sighting();
        }

        public void AddSighting(Sighting sighting)
        {
            _sightings.Add(sighting);
        }

        //This edit should have issues - can only change one hero at a time but there may be 2+ Heroes
        public void EditSighting(Sighting sighting)
        {
            var s = new Sighting();
            foreach (var sightin in _sightings)
            {
                if (sightin.SightingID == sighting.SightingID)
                {

                    sightin.Date = sighting.Date;
                    sightin.Ispublished = sighting.Ispublished;
                    sightin.IsDeleted = sighting.IsDeleted;

                }
            }
            s = sighting;
        }

        public void DeleteSighting(int sightingID)
        {
            _sightings.RemoveAll(s => s.SightingID == sightingID);
        }

        public IEnumerable<Sighting> GetAllSightings()
        {
            return _sightings;
        }
    }
}


