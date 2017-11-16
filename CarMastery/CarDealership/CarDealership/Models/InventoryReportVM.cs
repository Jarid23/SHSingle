using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealership.Data.CarRepo;
using CarDealership.Data.CarRepo.cs;

namespace CarDealership.Models
{
    public class InventoryReportVM
    {
        public List<InventoryTotalsVM> NewCars;
        public List<InventoryTotalsVM> UsedCars;

        public InventoryReportVM()
        {
            NewCars = new List<InventoryTotalsVM>();
            UsedCars = new List<InventoryTotalsVM>();
        }

        public void PopulateNew(ICarRepo repo)
        {
            foreach (var car in repo.GetAllNew())
            {
                bool add = true;
                foreach (var cars in NewCars)
                {
                    if (car.Model.ModelId == cars.TotalCar.Model.ModelId)
                    {
                        cars.Total++;
                        cars.TotalPrice += car.Price;
                        add = false;
                    }
                }
                if (add)
                {
                    var toAdd = new InventoryTotalsVM
                    {
                        TotalCar = car,
                        Total = 1,
                        TotalPrice = car.Price,
                    };
                    NewCars.Add(toAdd);
                }
            }
        }

        public void PopulateUsed (ICarRepo repo)
        {
            foreach (var car in repo.GetAllUsed())
            {
                bool add = true;
                foreach (var cars in NewCars)
                {
                    if (car.Model.ModelId == cars.TotalCar.Model.ModelId)
                    {
                        cars.Total++;
                        cars.TotalPrice += car.Price;
                        add = false;
                    }
                }
                if (add)
                {
                    var toAdd = new InventoryTotalsVM
                    {
                        TotalCar = car,
                        Total = 1,
                        TotalPrice = car.Price,
                    };
                    NewCars.Add(toAdd);
                }
            }
        }
    }
}