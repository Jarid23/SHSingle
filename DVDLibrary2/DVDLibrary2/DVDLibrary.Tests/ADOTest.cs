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

        [TestCase(7, true)]
        [TestCase(8, true)]
        [TestCase(9, true)]
        [TestCase(55, false)]
        public void ADOListDvdsById(int dvdId, bool expected)
        {
            ADORepository repo = new ADORepository();
            Dvd dvd = repo.GetSingleDvd(dvdId);
            bool result = !(dvd.title == null);

            Assert.AreEqual(result, expected);
        }

        
        //[Test]
        //public void ADORemoveDvd()
        //{
        //    var createdDvd = new Dvd();
        //    ADORepository repo = new ADORepository();

        //    createdDvd.title = "New Movie";
        //    createdDvd.realeaseYear = 2010;
        //    createdDvd.rating = "G";
        //    createdDvd.director = "Jarid Wagner";
        //    createdDvd.notes = "Test Movie";
            

        //    repo.AddDvd(createdDvd);

        //    var dvdToDelete = repo.GetSingleDvd(15);
        //    Assert.IsNotNull(dvdToDelete);

        //    repo.DeleteDvd(15);

        //    dvdToDelete = repo.GetSingleDvd(15);
        //    Assert.IsNull(dvdToDelete);
            
        //}


//        [TestCase("Ex Machina", 3,"Robot Overlords", "G", true)]
//        [TestCase("Star Wars", 8, "Me", "R", true)]
//        [TestCase("se7en", 0, "Kevin Spacey", "R", false)]
//        public void ADOAddDvd(string title, int dvdId, string director, string rating)
//        {
//            ADORepository repo = new ADORepository();
//            Dvd dvd = new Dvd { title = title, dvdId = dvdId, director = director, rating = rating };

//            bool result = repo.AddDvd(dvd) > 0;

//            Assert.AreEqual(result, expected);
//        }
    }
}
