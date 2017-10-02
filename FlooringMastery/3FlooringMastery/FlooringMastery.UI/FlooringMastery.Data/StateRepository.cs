using FlooringMastery.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using System.IO;

namespace FlooringMastery.Data
{
    public class StateRepository : IStateRepository
    {
        string _filepath = null;
        public StateRepository(string filepath)
        {
            _filepath = filepath;
        }
        public List<Tax> GetEveryState()
        {
            var toReturn = new List<Tax>();
            //  throw new NotImplementedException();
            var fileToRead = _filepath;
            if (File.Exists(fileToRead))
            {
                var reader = File.ReadAllLines(fileToRead);
                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split(',');
                    {
                        var tax = new Tax();

                        tax.StateAbbreviation = columns[0];
                        tax.StateName = columns[1];
                        tax.TaxRate = decimal.Parse(columns[2]);
                        toReturn.Add(tax);
                    }
                    // load from file based on file path
                    // C:\Users\jwagner\Desktop\REPOS\dotnet---jarid---wagner\FlooringMastery\3FlooringMastery\FlooringMastery.UI\Data\Taxes.txt
                }
            }
            return toReturn;
        }
    }
}
