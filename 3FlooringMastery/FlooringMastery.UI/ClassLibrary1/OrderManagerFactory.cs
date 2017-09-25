using FlooringMastery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class OrderManagerFactory
    {
        public OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "LiveData":
                    return new OrderManager(new LiveDataRepository(@"C:\Users\jwagner\Desktop\3FlooringMastery\FlooringMastery.UI/Data"));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
