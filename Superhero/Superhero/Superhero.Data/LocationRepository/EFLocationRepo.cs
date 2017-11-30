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
            SuperheroDBContext context = new SuperheroDBContext();
            {
                context.Locations.Add(location);
                context.SaveChanges();
            }
        }


        public void DeleteLocation(int LocationID)
        {
            SuperheroDBContext context = new SuperheroDBContext();
            {
                Location toRemove = context.Locations.SingleOrDefault(l => l.LocationID == LocationID);
                if (toRemove != null)
                {
                    context.Locations.Remove(toRemove);
                }
                context.SaveChanges();
            }
        }

        public void EditLocation(Location LocationID)
        {
            SuperheroDBContext context = new SuperheroDBContext();
            {
                Location toEdit = context.Locations.SingleOrDefault(l => l.LocationID == LocationID.LocationID);
                if (toEdit != null)
                {
                    toEdit.LatitudeCoordinate = LocationID.LatitudeCoordinate;
                    toEdit.LongitudeCoordinate = LocationID.LongitudeCoordinate;
                    toEdit.LocationAddress = LocationID.LocationAddress;
                    toEdit.LocationDescription = LocationID.LocationDescription;
                    toEdit.LocationName = LocationID.LocationName;

                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<Location> GetAllLocations()
        {
            SuperheroDBContext context = new SuperheroDBContext();
            {
                var locations = from l in context.Locations
                                select l;
                return locations.ToList();
            }
        }

        public Location GetLocationById(int LocationID)
        {
            using (SuperheroDBContext context = new SuperheroDBContext())
            {
                return context.Locations.Where(l => l.LocationID == l.LocationID).FirstOrDefault();
            }
        }
    }
}
