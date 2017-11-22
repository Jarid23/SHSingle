using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Data.HeroRepository
{
    public class HeroRepoFactory
    {
        //Create an IHeroRepo
        public static IHeroRepo Create()
        {
            //This value is under Web.onfig >> appsettings and controls the mode of what IHerorepo will return
            //Test with Mock, Run with EF
            string mode = ConfigurationManager.AppSettings["Hero"].ToString();

            switch (mode)
            {
                case "EF":
                    return new EFHeroRepo();
                case "Mock":
                    return new MockHeroRepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
