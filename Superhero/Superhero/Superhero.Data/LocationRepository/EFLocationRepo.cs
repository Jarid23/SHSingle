using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superhero.Model.Models;

namespace Superhero.Data.LocationRepository
{
    public class EFLocationRepo : ILocationRepo
    {
        public void AddLocation(Location location)
        {
            using (var db = new SuperheroDBContext())
            {
                db.Locations.Add(location);
                db.SaveChanges();
            }
        }

        public void DeleteLocation(int LocationID)
        {
            using (var db = new SuperheroDBContext())
            {
                Location toRemove = db.Locations.SingleOrDefault(l => l.LocationID == LocationID);
                if (toRemove != null)
                {
                    db.Locations.Remove(toRemove);
                }
                db.SaveChanges();
            }
        }

        public void EditLocation(Location LocationID)
        {
            using (var db = new SuperheroDBContext())
            {
                Location toEdit = db.Locations.SingleOrDefault(l => l.LocationID == LocationID.LocationID);
                if (toEdit != null)
                {
                    toEdit.LatitudeCoordinate = LocationID.LatitudeCoordinate;
                    toEdit.LongitudeCoordinate = LocationID.LongitudeCoordinate;
                    toEdit.LocationAddress = LocationID.LocationAddress;
                    toEdit.LocationDescription = LocationID.LocationDescription;
                    toEdit.LocationName = LocationID.LocationName;

                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Location> GetAllLocations()
        {
            using (var db = new SuperheroDBContext())
            {
                var locations = from l in db.Locations
                                select l;
                return locations.ToList();
            }
        }

        public Location GetLocationById(int LocationID)
        {
            using (SuperheroDBContext context = new SuperheroDBContext())
            {
                return context.Locations.Where(l => l.LocationID == LocationID).FirstOrDefault();
            }
        }
    }
}

