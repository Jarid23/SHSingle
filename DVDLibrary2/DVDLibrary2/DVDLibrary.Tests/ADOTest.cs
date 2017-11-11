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
    public class ADOTest
    {
        [TestCase(true)]
        public void ADOListDvds(bool expected)
        {
            ADORepository repo = new ADORepository();
            List<Dvd> list = repo.GetDvdList();
            bool result = list.Count > 0;

            Assert.AreEqual(result, expected);
        }

        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(55, false)]
        public void ADOListDvdsById(int dvdId, bool expected)
        {
            ADORepository repo = new ADORepository();
            Dvd dvd = repo.GetSingleDvd(dvdId);
            bool result = !(dvd == null);

            Assert.AreEqual(result, expected);
        }
    }
}
