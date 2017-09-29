using FlooringMastery.BLL;
using FlooringMastery.BLL.Responses;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringMastery.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            OrderManager orderManager = OrderManagerFactory.Create();

            var userEnteredDate = ConsoleIO.GetDate();
            var userEnteredName = ConsoleIO.GetName();

            List<Tax> allStates = orderManager.GetAllStates();
            Tax userEnteredState = ConsoleIO.GetState(allStates);

            List<Product> allProducts = orderManager.GetAllProducts();
            var userEnteredProduct = ConsoleIO.GetProduct(allProducts);

            decimal userEnteredArea = ConsoleIO.GetArea();

            int newOrderNumber = orderManager.GetNextOrderNumber(userEnteredDate);

            Console.ReadKey();

            var response = orderManager.AddOrder(new Order()
            {
                OrderNumber = newOrderNumber,
                CustomerName = userEnteredName,
                State = userEnteredState.StateAbbreviation,
                TaxRate = userEnteredState.TaxRate,
                ProductType = userEnteredProduct.ProductType,
                Area = userEnteredArea,
                CostPerSquareFoot = userEnteredProduct.CostPerSquareFoot,
                LaborCostPerSquareFoot = userEnteredProduct.LaborCostPerSquareFoot,

            });

            if (response.Success)
            {
                Console.WriteLine("We added the order succesfully");
            }
            else
            {
                Console.WriteLine(response.Message);
            }

        }
    }
}
