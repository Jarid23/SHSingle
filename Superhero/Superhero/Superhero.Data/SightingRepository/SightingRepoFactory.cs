using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Data.SightingRepository
{
    //Factory classes only job is to instantiate other classes
    public class SightingRepoFactory
    {
        //Create an ISighting Repo
        public static ISightingRepo Create()
        {
            //This value is under Web.onfig >> appsettings and controls the mode of what ISightingrepo will return
            //Test with Mock, Run with EF
            string mode = ConfigurationManager.AppSettings["Sighting"].ToString();

            switch (mode)
            {
                case "EF":
                    return new EFSightingRepo();
                case "Mock":
                    return new MockSightingRepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}

