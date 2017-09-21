using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IOrderRepository
    {
        Order LoadOrder(DateTime orderDate, int orderNum);
        void SaveOrder(Order order);
    }
}
