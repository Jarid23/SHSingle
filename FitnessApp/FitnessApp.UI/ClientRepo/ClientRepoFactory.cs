using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.UI.ClientRepo
{
    public class ClientRepoFactory
    {
        public static IClientRepo Create()
        {
            //This value is under Web.onfig >> appsettings and controls the mode of what IClientrepo will return
            //Test with Mock, Run with EF
            string mode = ConfigurationManager.AppSettings["Client"].ToString();

            switch (mode)
            {
                case "EF":
                    return new EFClientRepo();
                case "Mock":
                    return new MockClientRepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
