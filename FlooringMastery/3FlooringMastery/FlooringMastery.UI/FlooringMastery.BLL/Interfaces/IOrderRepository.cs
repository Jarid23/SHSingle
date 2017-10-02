using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL.Interfaces
{
   public interface IOrderRepository
    {
        List<Order> LoadOrders(DateTime orderDate);
        bool AddOrder(Order orderToAdd);
        bool RemoveOrder(Order orderBeingRemoved);
    }
}
