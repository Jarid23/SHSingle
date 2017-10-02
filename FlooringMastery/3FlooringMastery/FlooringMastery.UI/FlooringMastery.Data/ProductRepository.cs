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
    public class ProductRepository : IProductRepository
    {
        string _filepath = null;
        public ProductRepository(string filepath)
        {
            _filepath = filepath;
        }
        public List<Product> GetEveryProduct()
        {
            var toReturn = new List<Product>();
            //  throw new NotImplementedException();
            var fileToRead = _filepath;
            if (File.Exists(fileToRead))
            {
                var reader = File.ReadAllLines(fileToRead);
                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split(',');
                    {
                        var product = new Product();

                        product.ProductType = columns[0];
                        product.CostPerSquareFoot = decimal.Parse(columns[1]);
                        product.LaborCostPerSquareFoot = decimal.Parse(columns[2]);
                        toReturn.Add(product);
                    }
                    // load from file based on file path
                    // C:\Users\jwagner\Desktop\REPOS\dotnet---jarid---wagner\FlooringMastery\3FlooringMastery\FlooringMastery.UI\Data\Taxes.txt
                }
            }
            return toReturn;
        }
    }
    }

