using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(List<Order> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"Order Number: {order.OrderNumber}");
                Console.WriteLine($"Name: {order.CustomerName}");
                Console.WriteLine($"Order: {order.OrderDate}");
                Console.WriteLine($"State: {order.State}");
                Console.WriteLine($"Product: {order.ProductType}");
                Console.WriteLine($"Materials: {order.MaterialCost}");
                Console.WriteLine($"Labor: {order.LaborCost}");
                Console.WriteLine($"Tax: {order.Tax}");
                Console.WriteLine($"Total: {order.Total}");
            }
        }

        public static Tax GetState(List<Tax> allStates)
        {
            throw new NotImplementedException();
        }

        public static Product GetProduct(List<Product> allProducts)
        {
            throw new NotImplementedException();
            Console.Write("Enter the product type: (Wood, Laminate, Carpet) ");
            string ProductType = Console.ReadLine();
        }

        public static decimal GetArea()
        {
            throw new NotImplementedException();
            Console.Write("Enter the area in feet (must be greater than 100) : ");
            string Area = Console.ReadLine();
            decimal areaConverter;
            decimal.TryParse(Area, out areaConverter);
        }

        public static string GetName()
        {
            throw new NotImplementedException();
            Console.Write("Enter your name: ");
            string CustomerName = Console.ReadLine();
        }

        public static DateTime GetDate()
        {
            do
            {
                Console.Write("Enter date of order (MMDDYYYY): ");
                string input = Console.ReadLine();               
                                
                DateTime enteredDate;
                bool parseddatetime = DateTime.TryParse(input, out enteredDate);
                if ((parseddatetime) && (enteredDate < DateTime.Now))
                {
                    return enteredDate;
                }
            } while (true);

            //if (Date < DateTime.Now)
            //{
            //    Console.WriteLine("Entered Date must be in the future")
            //    ConsoleIO.GetDate();
            //}
            //else
            //{

            //}

            throw new NotImplementedException();
        }
                
    }
}

