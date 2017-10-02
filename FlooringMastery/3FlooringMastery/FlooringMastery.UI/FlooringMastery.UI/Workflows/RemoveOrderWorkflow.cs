using FlooringMastery.BLL;
using FlooringMastery.BLL.Interfaces;
using FlooringMastery.Data;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            var userEnteredDate = ConsoleIO.GetDate();

            var userEnteredOrderNumber = ConsoleIO.GetOrderNumber();

            OrderManager orderManager = OrderManagerFactory.Create();
            
            var response = orderManager.LookupOrder(userEnteredDate);

            var orderBeingRemoved = response.Order.SingleOrDefault(o => o.OrderNumber == userEnteredOrderNumber);

            ConsoleIO.DisplaySingleOrderDetails(orderBeingRemoved);
            Console.WriteLine("Are you sure you want to delete this Order : ");
            string delete = Console.ReadLine();
            
            if ((orderBeingRemoved == null) || (delete == "n") || (delete =="N"))
            {
                Console.WriteLine("We could not find that order or you selected not to delete");
                Console.ReadKey();
            }
            if(((delete == "y") || (delete == "Y")) && (orderBeingRemoved != null))
            {
                orderManager.RemoveOrder(orderBeingRemoved);
                Console.WriteLine("We deleted the order");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("We could not find that order or you selected not to delete");
                Console.ReadKey();
            }
                                                             
        }
    }
}
