using FlooringMastery.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class LiveDataRepository : IOrderRepository
    {
        string _filepath = null;
        public LiveDataRepository(string filepath)
        {
            _filepath = filepath;
        }
        public Order LookupOrder(string OrderDate)
        {
            //check order date
            //Steamwrite everything that matches
            throw new NotImplementedException();
        }
    }
}
