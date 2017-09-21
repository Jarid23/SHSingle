using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrdersLookupResponse LookupOrder(DateTime orderDate,int orderNum)
        {
            OrdersLookupResponse response = new OrdersLookupResponse();

            response.Order = _orderRepository.LoadOrder(orderDate, orderNum);

            if(response.Order == null)
            {
                response.Success = false;
                response.Message = $"{orderDate} is not a valid order.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public OrdersLookupResponse LookupOrders(string orderDate)
        {
            var toReturn = new OrdersLookupResponse();
            Convert.ToDateTime(orderDate);
            OrdersLookupResponse response = manager.LookupOrders(orderDate);

            if (response.Success)
            {
                DisplayOrdersDetails(response.Orders);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
            //1. Convert to date
            //2. Get orders for date from repo
            //3. Make sure there actually are any orders
            throw new NotImplementedException();

            return toReturn;
        }
    }
}
