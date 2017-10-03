//using FlooringMastery.BLL;
//using FlooringMastery.Data;
//using FlooringMastery.Models;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FlooringMastery.Tests
//{
//    [TestFixture]
//    public class EditTest
//    {
//        [TestCase(1, "05/05/2020", "Jarid", "OH", 5, "Wood", 101, 5.15, 4.75)]
//        public void EditTestMethod(int orderNumber, string orderDate, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot)
//        {
//            var manager = new OrderManager(new LiveDataRepository(@"C:\Users\jwagner\Desktop\REPOS\dotnet---jarid---wagner\FlooringMastery\3FlooringMastery\FlooringMastery.UI\Data\"), new ProductRepository(@"C:\Users\jwagner\Desktop\REPOS\dotnet---jarid---wagner\FlooringMastery\3FlooringMastery\FlooringMastery.UI\Data\Products.txt"), new StateRepository(@"C:\Users\jwagner\Desktop\REPOS\dotnet---jarid---wagner\FlooringMastery\3FlooringMastery\FlooringMastery.UI\Data\Taxes.txt"));

//            Order orderVariable = new Order()
//            {

//                OrderNumber = orderNumber,
//                OrderDate = DateTime.Parse(orderDate),
//                CustomerName = customerName,
//                State = state,
//                TaxRate = taxRate,
//                ProductType = productType,
//                Area = area,
//                CostPerSquareFoot = costPerSquareFoot,
//                LaborCostPerSquareFoot = laborCostPerSquareFoot
//            };
            
//        }

//    }
//}