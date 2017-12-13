using NUnit.Framework;
using Superhero.Data.HeroRepository;
using Superhero.Data.LocationRepository;
using Superhero.Data.OrganizationRepository;
using Superhero.Data.SightingRepository;
using Superhero.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Tests
{
    [TestFixture]
    public class EFTest
    {
        [TestCase(true)]
        public void EFListSightings(bool expected)
        {
            EFSightingRepo repo = new EFSightingRepo();
            List<Sighting> list = repo.GetAllSightings().ToList();
            bool result = list.Count > 0;

            Assert.AreEqual(result, expected);
        }

        [TestCase(true)]
        public void EFListHeroes(bool expected)
        {
            EFHeroRepo repo = new EFHeroRepo();
            List<Hero> list = repo.GetAllHeroes().ToList();
            bool result = list.Count > 0;

            Assert.AreEqual(result, expected);
        }

        [TestCase(true)]
        public void EFListOrgs(bool expected)
        {
            EFOrgRepo repo = new EFOrgRepo();
            List<Organization> list = repo.GetAllOrganizations().ToList();
            bool result = list.Count > 0;

            Assert.AreEqual(result, expected);
        }

        [TestCase(true)]
        public void EFListLocationss(bool expected)
        {
            EFLocationRepo repo = new EFLocationRepo();
            List<Location> list = repo.GetAllLocations().ToList();
            bool result = list.Count > 0;

            Assert.AreEqual(result, expected);
        }

        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(45, false)]
        public void EFListSightingsById(int sightingID, bool expected)
        {
            EFSightingRepo repo = new EFSightingRepo();
            Sighting sighting = repo.GetSightingsById(sightingID);
            bool result = !(sighting.SightingDescription == null);

            Assert.AreEqual(result, expected);
        }       
    }
}