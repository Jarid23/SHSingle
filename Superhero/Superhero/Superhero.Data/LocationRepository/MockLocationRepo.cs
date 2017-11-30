using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superhero.Model.Models;

namespace Superhero.Data.LocationRepository
{
    public class MockLocationRepo : ILocationRepo
    {
        private static List<Location> _locations = new List<Location>
        {
            new Location
            {
                LocationID = 2,
                LatitudeCoordinate = 2,
                LongitudeCoordinate = 2,
                LocationAddress = "The South Pole",
                LocationDescription = "Very cold with penguins",
                LocationName = "The South Pole"
            },
             new Location
            {
                LocationID = 3,
                LatitudeCoordinate = 3,
                LongitudeCoordinate = 3,
                LocationAddress = "Minneapolis",
                LocationDescription = "The 2nd largest city in the Midwest",
                LocationName = "Minneapolis"
            } };

    public void AddLocation(Location location)
        {
            _locations.Add(location);
        }

        public void DeleteLocation(int LocationID)
        {
            _locations.RemoveAll(l => l.LocationID == LocationID);
        }

        public void EditLocation(Location location)
        {
            var l = new Location();
            foreach (var loco in _locations)
            {
                if (loco.LocationID == location.LocationID)
                {
                    loco.LongitudeCoordinate = location.LongitudeCoordinate;
                    loco.LatitudeCoordinate = location.LatitudeCoordinate;
                    loco.LocationAddress = location.LocationAddress;
                    loco.LocationDescription = location.LocationDescription;
                    loco.LocationName = location.LocationName;

                }
            }
            l = location;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _locations;
        }

        public Location GetLocationById(int LocationID)
        {
            foreach (var location in _locations)
            {
                if (location.LocationID == LocationID)
                {
                    return location;
                }
            }
            return new Location();
        }
    }
}

