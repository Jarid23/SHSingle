using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model;
using CarDealership.Model.Users;

namespace CarDealership.Data.CarRepo.cs
{
    public class EFCarRepo : ICarRepo
    {
        CarDBContext context = new CarDBContext();
        public void AddCar(Car newCar)
        {
            throw new NotImplementedException();
        }

        public void AddMake(Make make)
        {
            throw new NotImplementedException();
        }

        public void AddModel(CarModel model)
        {
            throw new NotImplementedException();
        }

        public void AddUser(AppUser user, string password)
        {
            throw new NotImplementedException();
        }

        public void EditCar(Car newCar)
        {
            throw new NotImplementedException();
        }

        public void EditUser(AppUser user, string password)
        {
            throw new NotImplementedException();
        }

        public int GetAllCars(string id, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars(string type, string searchKey, int yearmin, int yearmax, int pricemin, int pricemax)
        {
            throw new NotImplementedException();
        }

        public List<Make> GetAllMakes()
        {
            throw new NotImplementedException();
        }

        public List<CarModel> GetAllModels()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllNew()
        {
            throw new NotImplementedException();
        }

        public decimal GetAllSales(string id, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public List<Style> GetAllStyles()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllUsed()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetFeatured()
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetSalesTeam()
        {
            throw new NotImplementedException();
        }

        public void SellCar(Sale newSale)
        {
            throw new NotImplementedException();
        }
    }
}
