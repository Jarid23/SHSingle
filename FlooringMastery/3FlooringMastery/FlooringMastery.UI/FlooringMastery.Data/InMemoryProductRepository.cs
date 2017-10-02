using FlooringMastery.BLL;
using FlooringMastery.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class InMemoryProductRepository : IProductRepository 
    {
        static List<Product> _allProductData = new List<Product>
        {
            new Product
            {                
                ProductType = "Carpet",
                CostPerSquareFoot = 2,
                LaborCostPerSquareFoot = 5
            },
            new Product
            {
                ProductType = "Wood",
                CostPerSquareFoot = 3,
                LaborCostPerSquareFoot = 4

            },
            new Product
            {
                ProductType = "Laminate",
                CostPerSquareFoot = 2,
                LaborCostPerSquareFoot = 3

            },

        };
        public List<Product> GetEveryProduct()
        {
            return _allProductData;
        }
    }
}
