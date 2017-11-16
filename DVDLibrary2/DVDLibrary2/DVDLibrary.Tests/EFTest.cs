using DVDLibrary.Data.Repositories;
using DVDLibrary.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Tests
{
    [TestFixture]
    public class EFTest
    {
        [TestCase(true)]
        public void EFListDvds(bool expected)
        {
            EFRepository repo = new EFRepository();
            List<Dvd> list = repo.GetDvdList();
            bool result = list.Count > 0;

            Assert.AreEqual(result, expected);
        }

        [TestCase(7, true)]
        [TestCase(8, true)]
        [TestCase(9, true)]
        [TestCase(55, false)]
        public void EFListDvdsById(int dvdId, bool expected)
        {
            EFRepository repo = new EFRepository();
            Dvd dvd = repo.GetSingleDvd(dvdId);
            bool result = !(dvd.title == null);

            Assert.AreEqual(result, expected);
        }
    }
}
