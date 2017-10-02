using FlooringMastery.BLL;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            var userEnteredDate = ConsoleIO.GetDate();

            var userEnteredOrderNumber = ConsoleIO.GetOrderNumber();

            OrderManager orderManager = OrderManagerFactory.Create();

            var response = orderManager.LookupOrder(userEnteredDate);

            var orderBeingEdited = response.Order.SingleOrDefault(o => o.OrderNumber == userEnteredOrderNumber);

            ConsoleIO.DisplaySingleOrderDetails(orderBeingEdited);
            Console.WriteLine("Are you sure you want to edit this Order : ");
            string edit = Console.ReadLine();

            if(((edit == "y") || (edit == "yes")) || (edit=="Y"))
            {               
              var EditedName = ConsoleIO.EditGetName(orderBeingEdited);
              var EditedState = ConsoleIO.EditGetState(orderBeingEdited, orderManager.GetAllStates() );
              var EditedArea = ConsoleIO.EditGetArea(orderBeingEdited);
              var EditedProduct = ConsoleIO.EditGetProduct(orderManager.GetAllProducts(), orderBeingEdited);

              var newordertoedit = new Order()
                {
                    OrderDate = orderBeingEdited.OrderDate,
                    OrderNumber = orderBeingEdited.OrderNumber,
                    CustomerName = EditedName,
                    State = EditedState.StateAbbreviation,                   
                    Area = EditedArea,
                    ProductType = EditedProduct.ProductType,
                    CostPerSquareFoot = EditedProduct.CostPerSquareFoot,
                    LaborCostPerSquareFoot = EditedProduct.LaborCostPerSquareFoot,
                    TaxRate = EditedState.TaxRate,

                };
                orderManager.RemoveOrder(orderBeingEdited);
                orderManager.AddOrder(newordertoedit);
            }
            else
            {
                Console.WriteLine("You decided not to edit the record");
                Console.ReadKey();
            }
        }
    }
}
