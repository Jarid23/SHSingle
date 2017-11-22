using Superhero.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Data.SightingRepository
{
    // The interface represents a contract. A set of public methods any implementing class has to have
    public interface ISightingRepo
    {
        IEnumerable<Sighting> GetNumberOfSightings(int number, int set);
        IEnumerable<Sighting> GetPendingSightings();
        Sighting GetSightingsById(int SightingID);
        IEnumerable<Sighting> GetAllSightings();
        IEnumerable<Sighting> GetSighintsByDate(string date);
        void AddSighting(Sighting sighting);
        void EditSighting(Sighting sighting);
        void DeleteSighting(int sightingID);
        
    }
}
