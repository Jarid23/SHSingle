using FlooringMastery.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;
using FlooringMastery.BLL.Responses;

namespace FlooringMastery.Data
{
    public class OrderRepository : IOrderRepository
    {
        static List<Order> _allOrderData = new List<Order>();
        static bool _isLoaded = false;

        string _filepath = null;
        public OrderRepository(string filepath)
        {
            _filepath = filepath;
        }

        public void AddOrder(Order orderToAdd)
        {
            AddOrderResponse response = new AddOrderResponse();
            response.NewOrder = newOrder;

            _orderRepository.AddOrder(response.NewOrder);
            return response;
        }

        public List<Order> LoadOrders(DateTime orderDate)
        {
            List<Order> Orders = new List<Order>();

            string filename = "Orders_" + orderDate.Month.ToString().PadLeft(2, '0')
                    + orderDate.Day.ToString().PadLeft(2, '0') + orderDate.Year + ".txt";

            var fileToRead = _filepath + filename;
            if (File.Exists(fileToRead))
            {
                var reader = File.ReadAllLines(fileToRead);
                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split(',');
                    var order = new Order();

                    order.OrderNumber = int.Parse(columns[0]);
                    order.CustomerName = columns[1];
                    order.State = columns[2];
                    order.TaxRate = decimal.Parse(columns[3]);
                    order.ProductType = columns[4];
                    order.Area = decimal.Parse(columns[5]);
                    order.CostPerSquareFoot = decimal.Parse(columns[6]);
                    order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);

                    Orders.Add(order);
                }
            }
            else
            {
                Console.ReadKey();
            }
            return Orders;
        }


        public void RemoveOrder(Order orderBeingRemoved)
        {
            throw new NotImplementedException();
            //RemoveOrderResponse response = new RemoveOrderResponse();
            //response.OrderBeingRemoved = orderBeingRemoved;

            //_orderRepository.RemoveOrder(response.OrderBeingRemoved);
            //return response;
        }
    }
}

