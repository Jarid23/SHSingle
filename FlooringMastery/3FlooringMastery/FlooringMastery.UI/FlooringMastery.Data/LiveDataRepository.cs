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
       
        List<Order> IOrderRepository.LoadOrders(string OrderDate)
        {
                List<Order> Orders = new List<Order>();
                string filename = "Orders_" + OrderDate + ".txt";
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
        public void AddOrder(Order NewOrder)
        {
            string _filename = "Orders_06012013.txt";
            string line = $"{NewOrder.OrderNumber},{NewOrder.CustomerName},{NewOrder.State},{NewOrder.TaxRate},{NewOrder.ProductType},{NewOrder.Area},{NewOrder.CostPerSquareFoot},{NewOrder.LaborCostPerSquareFoot},{NewOrder.MaterialCost},{NewOrder.LaborCost},{NewOrder.Tax},{ NewOrder.Total}";
            using (var sw = File.AppendText(_filepath + _filename))
            {
                sw.WriteLine(line);

            }
        }
        public void RemoveOrder(Order OrderBeingRemoved)
        {

        }
        }
    }

