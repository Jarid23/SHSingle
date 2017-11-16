using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.CarRepo.cs
{
    public static class CarRepoFactory
    {
        public static ICarRepo Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "EF":
                    return new EFCarRepo();
                case "Mock":
                    return new MockCarRepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}