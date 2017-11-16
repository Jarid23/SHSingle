using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model;

namespace CarDealership.Data.SpecialRepo
{
    public class MockSpecialRepo : ISpecialRepo
    {
        private List<Special> _specials = new List<Special>
        {
            new Special
            {
                SpecialId = 1,
                Description ="This special offers 10% off new cars",
                IsDeleted = false,
                Title = "10% OFF SPECIAL"
            },
            new Special
            {
                SpecialId = 2,
                Description ="This special offers only 5% off",
                IsDeleted = false,
                Title = "5% OFF SPECIAL"
            }
        };

        public void AddSpecial(Special special)
        {
            _specials.Add(special);
        }

        public List<Special> GetAllSpecials()
        {
        return _specials.Where(s => !s.IsDeleted).ToList();
        }
    }
}
