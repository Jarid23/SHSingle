using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Interfaces
{
    public interface IDvdRepository
    {        
        List<Dvd> GetDvdList();
        Dvd GetSingleDvd(int dvdId);
        void AddDvd(Dvd dvd);
        void EditDvd(Dvd dvd);
        void DeleteDvd(int dvdId);
        List<Dvd> GetDvdsByTitle(string title);
        List<Dvd> GetDvdsByYear(int year);
        List<Dvd> GetDvdsByDirector(string director);
        List<Dvd> GetDvdsByRating(string rating);

    }
}
