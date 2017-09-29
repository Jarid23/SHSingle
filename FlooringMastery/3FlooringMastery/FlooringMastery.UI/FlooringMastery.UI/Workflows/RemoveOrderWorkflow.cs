using FlooringMastery.BLL;
using FlooringMastery.Models;
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
            OrderManager orderManager = OrderManagerFactory.Create();

            Console.Write("Enter an Order Date for the Order you want to delete (MMDDYYYY): ");
            string OrderDate = Console.ReadLine();

            Console.Write("Enter an Order number for the Order you want to delete: ");
            string OrderNumber = Console.ReadLine();

            Console.ReadKey();

         //   var result = orderManager.GetSingleOrder(OrderDate, OrderNumber);
          
            //  orderManager.RemoveOrder(Order OrderBeingRemoved);

        }
    }
}
