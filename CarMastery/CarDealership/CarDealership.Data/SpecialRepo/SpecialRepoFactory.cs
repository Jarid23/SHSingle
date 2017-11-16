using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.SpecialRepo
{
    public static class SpecialRepoFactory
    {
        public static ISpecialRepo Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "EF":
                    return new EFSpecialRepo();
                case "Mock":
                    return new MockSpecialRepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
