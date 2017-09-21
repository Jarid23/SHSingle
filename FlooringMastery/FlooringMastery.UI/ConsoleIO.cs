using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine($"Order: {order.CustomerName}");
            Console.WriteLine($"Total: {order.Total:c}");
        }
        public static DateTime GetDateTime(string date)
        {  
                     
            DateTime dt = Convert.ToDateTime(date);            
            return dt;
        }

        internal static void DisplayOrdersDetails(List<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}