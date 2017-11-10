using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;
using System.Data.Entity;

namespace DVDLibrary.Data.Repositories
{
    public class EFRepository : IDvdRepository
    {
        public void AddDvd(Dvd dvd)
        {
            using (var db = new MovieDBEntity())
            {
                db.Dvds.Add(dvd);
                db.SaveChanges();
            }
        }

        public void DeleteDvd(int dvdId)
        {
            using (var db = new MovieDBEntity())
            {
                Dvd toRemove = db.Dvds.SingleOrDefault(d => d.dvdId == dvdId);
                if (toRemove != null)
                {
                    db.Dvds.Remove(toRemove);
                }
                db.SaveChanges();
            }
        }

        public void EditDvd(Dvd dvdId)
        {
            using (var db = new MovieDBEntity())
            {
                Dvd toEdit = db.Dvds.SingleOrDefault(d => d.dvdId == dvdId.dvdId);
                if (toEdit != null)
                {
                    toEdit.director = dvdId.director;
                    toEdit.notes = dvdId.notes;
                    toEdit.rating = dvdId.rating;
                    toEdit.realeaseYear = dvdId.realeaseYear;
                    toEdit.title = dvdId.title;
                    db.SaveChanges();

                }
            }
        }

        public List<Dvd> GetDvdList()
        {
            List<Dvd> toReturn = new List<Dvd>();
            using (var db = new MovieDBEntity())
            {
                var query = from d in db.Dvds
                            select d;
                foreach(var dvd in query)
                {
                    toReturn.Add(dvd);
                }
            }
            return toReturn;
        }

        public List<Dvd> GetDvdsByDirector(string director)

        {
            List<Dvd> toReturn = new List<Dvd>();
            using (var db = new MovieDBEntity())
            {
                var query = from d in db.Dvds
                            where d.director == director
                            select d;

                foreach (var dvd in query)
                {
                    toReturn.Add(dvd);
                }
            }
            return toReturn;
        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
            List<Dvd> toReturn = new List<Dvd>();
            using (var db = new MovieDBEntity())
            {
                var query = from d in db.Dvds
                            where d.rating == rating
                            select d;

                foreach (var dvd in query)
                {
                    toReturn.Add(dvd);
                }
            }
            return toReturn;
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            List<Dvd> toReturn = new List<Dvd>();
            using (var db = new MovieDBEntity())
            {
                var query = from d in db.Dvds
                            where d.title == title
                            select d;

                foreach (var dvd in query)
                {
                    toReturn.Add(dvd);
                }
            }
            return toReturn;
        }

        public List<Dvd> GetDvdsByYear(int year)
        {
            List<Dvd> toReturn = new List<Dvd>();
            using (var db = new MovieDBEntity())
            {
                var query = from d in db.Dvds
                            where d.realeaseYear == year
                            select d;

                foreach (var dvd in query)
                {
                    toReturn.Add(dvd);
                }
            }
            return toReturn;
        }

        public Dvd GetSingleDvd(int id)
        {
            Dvd toReturn = new Dvd();
            using (var db = new MovieDBEntity())
            {
                var query = from d in db.Dvds
                            where d.dvdId == id
                            select d;
                
                foreach (var dvd in query)
                {
                    toReturn = dvd;
                }
            }
            return toReturn;
        }
    }
}
