using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Data.LocationRepository
{
    public class LocationRepoFactory
    {
        //Create an IHeroRepo
        public static ILocationRepo Create()
        {
            //This value is under Web.onfig >> appsettings and controls the mode of what ILocationrepo will return
            //Test with Mock, Run with EF
            string mode = ConfigurationManager.AppSettings["Location"].ToString();

            switch (mode)
            {
                case "EF":
                    return new EFLocationRepo();
                case "Mock":
                    return new MockLocationRepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
