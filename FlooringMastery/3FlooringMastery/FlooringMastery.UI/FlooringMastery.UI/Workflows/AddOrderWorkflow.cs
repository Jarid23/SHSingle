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

            Console.Write("Enter an Order number for your new Order: ");
            string OrderNumber = Console.ReadLine();

            Console.Write("Enter your name: ");
            string CustomerName = Console.ReadLine();

            Console.Write("Enter your State: ");
            string State = Console.ReadLine();

            Console.Write("Enter the tax rate for the state: ");
            string TaxRate = Console.ReadLine();
            decimal taxRateConverter;
            decimal.TryParse(TaxRate, out taxRateConverter);

            Console.Write("Enter the product type: ");
            string ProductType = Console.ReadLine();

            Console.Write("Enter the area: ");
            string Area = Console.ReadLine();
            decimal areaConverter;
            decimal.TryParse(Area, out areaConverter);

            Console.Write("Enter the material cost per square foot: ");
            string CostPerSquareFoot = Console.ReadLine();
            decimal materialCostConverter;
            decimal.TryParse(CostPerSquareFoot, out materialCostConverter);

            Console.Write("Enter the labor cost per square foot: ");
            string LaborCostPerSquareFoot = Console.ReadLine();
            decimal laborCostConverter;
            decimal.TryParse(LaborCostPerSquareFoot, out laborCostConverter);

            Console.WriteLine("The material cost is : {0} ", (materialCostConverter * areaConverter));
            decimal MaterialCost = ((materialCostConverter * areaConverter));

            Console.WriteLine("The labor cost is : {0} ", (laborCostConverter * areaConverter));
            decimal LaborCost = (laborCostConverter * areaConverter);

            Console.WriteLine("The tax is : {0} ", ((taxRateConverter) * (LaborCost + MaterialCost)));
            decimal Tax = ((taxRateConverter) * (LaborCost + MaterialCost));

            Console.WriteLine("The total is : {0} ", (Tax + LaborCost + MaterialCost));
            decimal Total = (Tax + LaborCost + MaterialCost);

            orderManager.AddOrder(new Order() {
                OrderNumber = OrderNumber,
                CustomerName = CustomerName,
                State = State,
                TaxRate = taxRateConverter,
                ProductType = ProductType,
                Area = areaConverter,
                CostPerSquareFoot = materialCostConverter,
                LaborCostPerSquareFoot = laborCostConverter,
                MaterialCost = MaterialCost,
                LaborCost = LaborCost,
                Tax = Tax,
                Total = Total
            });

        }
    }
}
