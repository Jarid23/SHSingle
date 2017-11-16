using CarDealership.Data.CarRepo.cs;
using CarDealership.Data.SpecialRepo;
using CarDealership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using CarDealership.Models;

namespace CarDealership.Controllers
{
    public class CarsController : ApiController
    {
        ICarRepo repo = CarRepoFactory.Create();
        ISpecialRepo repos = SpecialRepoFactory.Create();
        [Route("cars/{type}/{searchKey}/{yearmin}/{yearmax}/{pricemin}/{pricemax}")]
        public List<Car> Get(string type, string searchkey, int yearmin, int yearmax, int pricemin, int pricemax)
        {
            var toReturn = repo.GetAllCars(type, searchkey, yearmin, yearmax, pricemin, pricemax);
            return toReturn;
        }

        [Route("car/{id}")]
        public Car Get(int id)
        {
            var toReturn = repo.GetById(id);
            return toReturn;
        }

        [Route("featured")]
        public List<Car> GetFeatured()
        {
            var toReturn = repo.GetFeatured();
            return toReturn;
        }

        [Route("specials")]
        public List<Special> GetSpecials()
        {
            var toReturn = repos.GetAllSpecials();
            return toReturn;
        }

        [Route("model")]
        public List<CarModel> GetModels()
        {
            var toReturn = repo.GetAllModels();
            return toReturn;
        }

        [Route("makes")]
        public List<Make> GetMakes()
        {
            var toReturn = repo.GetAllMakes();
            return toReturn;
        }

        [Route("salesreport/{name}/{startdate}/{enddate}")]
        public List<SalesReport> GetSalesReport(string name, string startdate, string enddate)
        {
            var toReturn = new List<SalesReport>();
            {
                try
                {
                    var start = DateTime.Parse(startdate);
                    var end = DateTime.Parse(enddate);
                    if (name == "All")
                    {
                        foreach (var user in repo.GetSalesTeam())
                        {
                            var report = new SalesReport()

                            {
                                User = user.FirstName + ' ' + user.LastName,
                                TotalSales = repo.GetAllSales(user.Id, start, end),
                                TotalVehicles = repo.GetAllCars(user.Id, start, end),
                            };
                            toReturn.Add(report);
                        }
                    }
                    else
                    {
                        var user = repo.GetSalesTeam().FirstOrDefault(t => t.FirstName == name);
                        var report = new SalesReport()

                        {
                            User = user.FirstName + ' ' + user.LastName,
                            TotalSales = repo.GetAllSales(user.Id, start, end),
                            TotalVehicles = repo.GetAllCars(user.Id, start, end),
                        };
                        toReturn.Add(report);
                    }
                }
                catch

                {

                }
                return toReturn;
            }
        }
    }
}