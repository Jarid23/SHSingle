using CarDealership.Model;
using CarDealership.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.CarRepo.cs
{
    public interface ICarRepo
    {
        List<Car> GetAllCars(string type, string searchKey, int yearmin, int yearmax, int pricemin, int pricemax);
        Car GetById(int id);
        List<Car> GetFeatured();
        List<CarModel> GetAllModels();
        List<Make> GetAllMakes();
        List<Style> GetAllStyles();
        void AddMake(Make make);
        void AddModel(CarModel model);
        void AddCar(Car newCar);
        void EditCar(Car newCar);
        void AddUser(AppUser user, string password);
        void EditUser(AppUser user, string password);
        List<Car> GetAllNew();
        List<Car> GetAllUsed();
        List<AppUser> GetSalesTeam();
        decimal GetAllSales(string id, DateTime start, DateTime end);
        int GetAllCars(string id, DateTime start, DateTime end);
        void SellCar(Sale newSale);

    }
}
