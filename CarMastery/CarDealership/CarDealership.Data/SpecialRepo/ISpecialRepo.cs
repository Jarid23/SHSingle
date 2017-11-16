using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model;

namespace CarDealership.Data.SpecialRepo
{
    public interface ISpecialRepo
    {
        List<Special> GetAllSpecials();
        void AddSpecial(Special special);
    }  
}
