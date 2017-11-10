using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;

namespace DVDLibrary.Data.Repositories
{
    class MockRepository : IDvdRepository
    {
        private List<Dvd> dvds = new List<Dvd>
        {
            new Dvd
            {
                dvdId = 1,
                title ="Benjamin Button",
                realeaseYear = 2011,
                director = "Brad Pitt",
                rating = "R",
                notes = "The dude ages backwards."
            },
            new Dvd
            {
                dvdId = 2,
                title ="Star Wars",
                realeaseYear = 1969,
                director = "George Lucas",
                rating = "PG-13",
                notes = "Cultural phenomenon"
            },
            new Dvd
            {
                dvdId = 3,
                title ="Ex Machina",
                realeaseYear = 2016,
                director = "Robot Overlords",
                rating = "R",
                notes = "Sexy sentient AI lady kills people"
            },
        };
        public void AddDvd(Dvd dvd)
        {
            dvd.dvdId = dvds.Last().dvdId + 1;
            dvds.Add(dvd);
        }

        public void DeleteDvd(int dvdId)
        {
            Dvd toDelete = new Dvd();
            foreach (var dvd in dvds)
            {
                if (dvd.dvdId == dvdId)
                {
                    toDelete = dvd;
                }
            }
            dvds.Remove(toDelete);
        }

        public void EditDvd(Dvd dvdId)
        {
            Dvd toEdit = new Dvd();
            foreach (var dvd in dvds)
            {
                if (dvd.dvdId == dvdId.dvdId)
                {
                    toEdit = dvd;
                }
            }
                toEdit.director = dvdId.director;
                toEdit.title = dvdId.title;
                toEdit.rating = dvdId.rating;
                toEdit.notes = dvdId.notes;
                toEdit.realeaseYear = dvdId.realeaseYear;
            }
        

        public List<Dvd> GetDvdList()
        {
            return dvds;
        }

        public List<Dvd> GetDvdsByDirector(string director)
        {
            return dvds.Where(d => d.director == director).ToList();
        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
            return dvds.Where(d => d.rating == rating).ToList();
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            return dvds.Where(d => d.title == title).ToList();
        }

        public List<Dvd> GetDvdsByYear(int year)
        {
            return dvds.Where(d => d.realeaseYear == year).ToList();
        }

        public Dvd GetSingleDvd(int id)
        {
            Dvd toReturn = new Dvd();
            foreach (var dvd in dvds)
            {
                if(dvd.dvdId == id)
                {
                    toReturn = dvd;
                }
            }
            return toReturn;
        }
    }
}
