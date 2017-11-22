using Superhero.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Data.LocationRepository
{
    public interface ILocationRepo
    {
        IEnumerable<Location> GetAllLocations();
        void AddLocation(Location location);
        void EditLocation(Location location);
        void DeleteLocation(int LocationID);
        Location GetLocationById(int LocationID);
    }
}
