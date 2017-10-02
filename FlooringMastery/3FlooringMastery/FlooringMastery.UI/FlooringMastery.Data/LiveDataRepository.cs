using FlooringMastery.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Data
{
    public class LiveDataRepository : IOrderRepository
    {
        string _filepath = null;
        public LiveDataRepository(string filepath)
        {
            _filepath = filepath;
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
                    order.OrderDate = orderDate;
                    Orders.Add(order);
                }
            }
            else
            {
                Console.ReadKey();
            }
            return Orders;
        }


        public bool AddOrder(Order newOrder)
        {
            try
            {
                string _filename = "Orders_" + newOrder.OrderDate.Month.ToString().PadLeft(2, '0')
                        + newOrder.OrderDate.Day.ToString().PadLeft(2, '0') + newOrder.OrderDate.Year + ".txt";


                var fileToRead = _filepath + _filename;
                if (!File.Exists(fileToRead))
                {
                    using (var sw = File.CreateText(fileToRead))
                    {
                        string header = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost";
                        sw.WriteLine(header);
                    }

                }

                string line = $"{newOrder.OrderNumber},{newOrder.CustomerName},{newOrder.State},{newOrder.TaxRate},{newOrder.ProductType},{newOrder.Area},{newOrder.CostPerSquareFoot},{newOrder.LaborCostPerSquareFoot},{newOrder.MaterialCost},{newOrder.LaborCost},{newOrder.Tax},{ newOrder.Total}";
                using (var sw = File.AppendText(_filepath + _filename))
                {
                    sw.WriteLine(line);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveOrder(Order orderBeingRemoved)
        {
            try
            {
                string _filename = "Orders_" + orderBeingRemoved.OrderDate.Month.ToString().PadLeft(2, '0')
                        + orderBeingRemoved.OrderDate.Day.ToString().PadLeft(2, '0') + orderBeingRemoved.OrderDate.Year + ".txt";

                var fileToRead = _filepath + _filename;
                if (File.Exists(fileToRead))
                {
                    var reader = File.ReadAllLines(fileToRead);
                    var allOrders = LoadOrders(orderBeingRemoved.OrderDate);
                   
                    allOrders.RemoveAll(o=>o.OrderNumber == orderBeingRemoved.OrderNumber);
                    File.Delete(fileToRead);
                    for(int i = 0; i < allOrders.Count; i++)
                    {
                        AddOrder(allOrders[i]);
                    }                                    
                }
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
} 
     

