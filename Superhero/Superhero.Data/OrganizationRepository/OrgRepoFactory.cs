using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Data.OrganizationRepository
{
    public class OrgRepoFactory
    {
        public static IOrgRepo Create()
        {
            //This value is under Web.onfig >> appsettings and controls the mode of what ILocationrepo will return
            //Test with Mock, Run with EF
            string mode = ConfigurationManager.AppSettings["Org"].ToString();

            switch (mode)
            {
                case "EF":
                    return new EFOrgRepo();
                case "Mock":
                    return new MockOrgRepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
