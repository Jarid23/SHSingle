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
    public class InMemoryOrderRepository : IOrderRepository
    {
        static List<Order> _allOrderData = new List<Order>
        {
            new Order
            {
                 OrderNumber = 1,
                 OrderDate = DateTime.Parse("06/01/2013"),
                 CustomerName = "Eric",
                 State = "OH",
                 TaxRate = 5,
                 ProductType = "Wood",
                 Area = 101,
                 CostPerSquareFoot = 3,
                 LaborCostPerSquareFoot = 4 } };

        public void AddOrder(Order orderToAdd)
        {
            _allOrderData.Add(orderToAdd);
        }
        public void RemoveOrder(Order orderBeingRemoved)
        {
            _allOrderData.Remove(orderBeingRemoved);
        }
        

        public List<Order> LoadOrders(DateTime orderDate)
        {
           return _allOrderData.Where(o => o.OrderDate == orderDate).ToList();
        }
    }
}




