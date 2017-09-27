using FlooringMastery.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "LiveData":
                    return new OrderManager(new LiveDataRepository(@"C:\Users\jwagner\Desktop\REPOS\dotnet---jarid---wagner\FlooringMastery\3FlooringMastery\FlooringMastery.UI\Data\"));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
