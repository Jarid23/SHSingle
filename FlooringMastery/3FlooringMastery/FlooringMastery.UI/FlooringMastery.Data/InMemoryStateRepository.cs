using FlooringMastery.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;

namespace FlooringMastery.Data
{
    public class InMemoryStateRepository : IStateRepository
    {
        static List<Tax> _allStateData = new List<Tax>
        {
            new Tax
            {
                StateAbbreviation = "OH",
                StateName = "Ohio",
                TaxRate = 5

            },
            new Tax
            {
                StateAbbreviation = "MN",
                StateName = "Minnesota",
                TaxRate = 7

            },
                        new Tax
            {
                StateAbbreviation = "IA",
                StateName = "Iowa",
                TaxRate = 4

            },

        };

        public List<Tax> GetEveryState()
        {
            return _allStateData;
        }
    }
}
