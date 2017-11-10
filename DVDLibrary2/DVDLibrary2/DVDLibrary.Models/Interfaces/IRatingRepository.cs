using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Interfaces
{
   public interface IRatingRepository
    {
        List<Rating> GetRatingList();
        Rating GetRatingByName(string Description);
        Rating GetRatingById(int RatingId);
    }
}
