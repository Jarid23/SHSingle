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
                Console.WriteLine($"State: {order.State}");
                Console.WriteLine($"Product: {order.ProductType}");
                Console.WriteLine($"Materials: {order.MaterialCost}");
                Console.WriteLine($"Labor: {order.LaborCost}");
                Console.WriteLine($"Tax: {order.Tax}");
                Console.WriteLine($"Total: {order.Total}");
            }
        }

        public static void DisplaySingleOrderDetails(Order orderBeingRemoved)
        {
            Console.WriteLine($"Order Number: {orderBeingRemoved.OrderNumber}");
            Console.WriteLine($"Name: {orderBeingRemoved.CustomerName}");            
            Console.WriteLine($"State: {orderBeingRemoved.State}");
            Console.WriteLine($"Product: {orderBeingRemoved.ProductType}");
            Console.WriteLine($"Materials: {orderBeingRemoved.MaterialCost}");
            Console.WriteLine($"Labor: {orderBeingRemoved.LaborCost}");
            Console.WriteLine($"Tax: {orderBeingRemoved.Tax}");
            Console.WriteLine($"Total: {orderBeingRemoved.Total}");
        }


        public static int GetOrderNumber()
        {
            do
            {
                Console.Write("Enter the Order Number for the Order you wish to edit/delete : ");
                string getOrderNumber = Console.ReadLine();
                var orderNumberInt = Convert.ToInt32(getOrderNumber);

                if (orderNumberInt > 0)
                {
                    return orderNumberInt;
                }
            } while (true);
        }

        public static Tax GetState(List<Tax> allStates)
        {
            Tax toReturn = null;
            bool gotValidInput = false;
            //loop until user has selected one
            while (!gotValidInput)
            {
                var allStateAbbreviations = string.Join(", ", allStates.Select(p => p.StateAbbreviation));
                Console.WriteLine($"Select a state from the following : {allStateAbbreviations}");
                string input = Console.ReadLine();
                toReturn = allStates.SingleOrDefault(s => s.StateAbbreviation == input);
                if (toReturn != null)
                {
                    gotValidInput = true;
                }

            }
            return toReturn;
        }

        public static Product GetProduct(List<Product> allProducts)
        {
            Product toReturn = null;
            bool gotValidInput = false;

            while (!gotValidInput)
            {
                var allProductsVariable = string.Join(", ", allProducts.Select(p => p.ProductType));
                Console.WriteLine($"Select a product from the following : {allProductsVariable}");
                string input = Console.ReadLine();
                toReturn = allProducts.SingleOrDefault(p => p.ProductType == input);
                if (toReturn != null)
                {
                    gotValidInput = true;
                }
            }
            return toReturn;
        }

        public static decimal GetArea()
        {
            do
            {
                Console.Write("Enter the area in feet (must be greater than 100) : ");
                string area = Console.ReadLine();
                decimal areaConverter;
                decimal.TryParse(area, out areaConverter);
                if (areaConverter > 100)
                {
                    return areaConverter;
                }
            } while (true);
        }


        public static string GetName()
        {
            do
            {
                Console.Write("Enter your name: ");
                string customerName = Console.ReadLine();
                if (!string.IsNullOrEmpty(customerName))
                {
                    return customerName;
                }
            } while (true);
        }

        public static DateTime GetFutureDate()
        {
            do
            {
                DateTime enteredDate = GetDate();

                if (enteredDate > DateTime.Now)
                {
                    return enteredDate;
                }
            } while (true);
        }
        public static DateTime GetDate()
        {
            do
            {
                Console.Write("Enter date of order (MM/DD/YYYY): ");
                string input = Console.ReadLine();

                DateTime enteredDate;
                bool parseddatetime = DateTime.TryParse(input, out enteredDate);
                if (parseddatetime)
                {
                    return enteredDate;
                }
            } while (true);
        }
        public static string EditGetName(Order orderBeingEdited)
        {
            do
            {
                Console.Write("Enter your name: ");
                string customerName = Console.ReadLine();
                if (customerName == "")
                {
                    return orderBeingEdited.CustomerName;
                }
                if (!string.IsNullOrEmpty(customerName))
                {
                    return customerName;
                }
            } while (true);
        }
        public static Tax EditGetState(Order orderBeingEdited, List<Tax> allStates)
        {
            Tax toReturn = null;
            bool gotValidInput = false;
            //loop until user has selected one
            while (!gotValidInput)
            {
                var allStateAbbreviations = string.Join(", ", allStates.Select(p => p.StateAbbreviation));
                Console.WriteLine($"Select a state from the following : {allStateAbbreviations}");
                string input = Console.ReadLine();
                if (input == "")
                {
                    toReturn = allStates.Single(s => s.StateAbbreviation == orderBeingEdited.State);
                    gotValidInput = true;
                }
                else
                {
                    toReturn = allStates.SingleOrDefault(s => s.StateAbbreviation == input);
                    if (toReturn != null)
                    {
                        gotValidInput = true;
                    }
                }
            }
            return toReturn;
        }
        public static decimal EditGetArea(Order orderBeingEdited)
        {
            do
            {
                Console.Write("Enter the area in feet (must be greater than 100) : ");
                string area = Console.ReadLine();
                decimal areaConverter;
                decimal.TryParse(area, out areaConverter);
                if (area == "")
                {
                    return orderBeingEdited.Area;
                }
                if (areaConverter > 100)
                {
                    return areaConverter;
                }
            } while (true);
        }
        public static Product EditGetProduct(List<Product> allProducts, Order orderBeingEdited)
        {
            Product toReturn = null;
            bool gotValidInput = false;

            while (!gotValidInput)
            {
                var allProductsVariable = string.Join(", ", allProducts.Select(p => p.ProductType));
                Console.WriteLine($"Select a product from the following : {allProductsVariable}");
                string input = Console.ReadLine();
                if (input == "")
                {
                    toReturn = allProducts.Single(s => s.ProductType == orderBeingEdited.ProductType);
                    gotValidInput = true;
                }
                else
                {
                    toReturn = allProducts.SingleOrDefault(p => p.ProductType == input);                    
                    if (toReturn != null)
                    {
                        gotValidInput = true;
                    }
                }
            }
            return toReturn;
        }
    }
}

