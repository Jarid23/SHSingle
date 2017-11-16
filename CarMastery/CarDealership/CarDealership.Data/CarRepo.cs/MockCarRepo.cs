using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Model;
using CarDealership.Model.Users;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarDealership.Data.CarRepo.cs
{
    public class MockCarRepo : ICarRepo
    {
        private static List<Style> _styles = new List<Style>
        {
            new Style
            {
                StyleId = 1,
                StyleType = "Sedan"
            }
        };

        private static List<Address> _addresses = new List<Address>
        {
            new Address
            {
                AddressId = 1,
                City = "Mscatine",
                State = "IA",
                Street1 = "2453 Woodlily Ridge",
                Zip = "52761",
            }
        };

        private static List<Customer> _customers = new List<Customer>
        {
            new Customer
            {
                CustomerId = 1,
                CustomerAddress = _addresses[0],
                Email = "Dave@gmail.com",
                Name = "Dave",
                Phone = "123-456-7890"
            }
        };

        private static List<AppUser> _users = new List<AppUser>
        {
            new AppUser
            {
                Id = "1",
                FirstName = "Jarid",
                LastName = "Wagner",
                Email = "wagnerjarid@gmail.com",
            }
        };

        private static List<Make> _makes = new List<Make>
        {
            new Make
            {
                MakeId = 1,
                MakeType = "Honda",
                DateAdded = DateTime.Parse("11/11/2011"),
                UserAdded = _users[0],
            }
        };

        private static List<CarModel> _models = new List<CarModel>
        {
            new CarModel
            {
                ModelId = 1,
                ModelType = "Accord",
                CarMake = _makes[0],
                ModelStyle = _styles[0],
                Description = "I own this car.",
                DateAdded = DateTime.Parse("11/11/2011"),
                UserAdded = _users[0],
            }
        };

        private static List<Sale> _sales = new List<Sale>
        {
            new Sale
            {
                SaleCustomer = _customers[0],
                PurchaseType = "Bank Financed",
                SalePrice = 23000,
                SaleId = 1,
                SalesPerson = _users[0],
                SaleDate = DateTime.Parse("11/11/2017"),
                CarId = 1,
            }
        };

        private List<Car> _cars = new List<Car>
        {
            new Car
            {
                CarId = 1,
                CarYear = 2017,
                Price = 23000,
                MSRP = 25000,
                Mileage = 0,
                Exterior = "Black",
                Interior = "Black",
                IsManual = false,
                IsFeatured = true,
                Sold = null,
                VIN = "123456789ABCD",
                Model = new CarModel
                {
                    ModelId = 1,
                    ModelType = "Accord",
                    CarMake = new Make
                    {
                        MakeId = 1,
                        MakeType = "Honda"
                    },
                    ModelStyle = new Style
                    {
                        StyleId = 1,
                        StyleType = "Sedan"
                    },
                    Description = "I own this car."
                },
                IsNew = true
            }
        };

        public List<Car> GetAllCars(string type, string searchKey, int yearmin, int yearmax, int pricemin, int pricemax)
        {
            var toReturn = new List<Car>();

            foreach (var car in _cars)
            {
                if ((type == "new" && car.IsNew) || (type == "used" && !car.IsNew))
                    if (car.Price > pricemin && car.Price < pricemax && car.CarYear > yearmin && car.CarYear < yearmax)
                    {
                        if (car.Model.ModelType == searchKey || car.Model.CarMake.MakeType == searchKey || car.CarYear.ToString() == searchKey)
                        {
                            toReturn.Add(car);
                        }
                    }
            }
            return toReturn.Take(10).ToList();
        }

        public Car GetById(int id)
        {
            return _cars.FirstOrDefault(c => c.CarId == id);
        }

        public List<Car> GetFeatured()
        {
            return _cars.Where(c => c.IsFeatured).ToList();
        }

        public List<CarModel> GetAllModels()
        {
            return _models;
        }

        public List<Make> GetAllMakes()
        {
            return _makes;
        }

        public List<Style> GetAllStyles()
        {
            return _styles;
        }

        public void AddMake(Make make)
        {
            _makes.Add(make);
        }

        public void AddModel(CarModel model)
        {
            _models.Add(model);
        }

        public void AddCar(Car newCar)
        {
            newCar.Model = _models.FirstOrDefault(c => c.ModelId == newCar.Model.ModelId);
            _cars.Add(newCar);
        }

        public void EditCar(Car newCar)
        {
            var editCar = _cars.FirstOrDefault(c => c.CarId == newCar.CarId);
            editCar.CarYear = newCar.CarYear;
            editCar.Interior = newCar.Interior;
            editCar.Exterior = newCar.Exterior;
            editCar.IsFeatured = newCar.IsFeatured;
            editCar.IsManual = newCar.IsManual;
            editCar.IsNew = newCar.IsManual;
            editCar.Mileage = newCar.Mileage;
            editCar.Model = newCar.Model;
            editCar.Price = newCar.Price;
            editCar.VIN = newCar.VIN;
            editCar.MSRP = newCar.MSRP;
        }

        public void AddUser(AppUser user, string password)
        {
            _users.Add(user);
        }

        public void EditUser(AppUser user, string password)
        {
            var editUser = _users.FirstOrDefault(u => u.UserName == user.UserName);
            editUser.FirstName = user.FirstName;
            editUser.LastName = editUser.LastName;
            editUser.Email = editUser.Email;
        }

        public List<Car> GetAllNew()
        {
            return _cars.Where(c => c.IsNew).ToList();
        }

        public List<Car> GetAllUsed()
        {
            return _cars.Where(c => !c.IsNew).ToList();
        }

        public List<AppUser> GetSalesTeam()
        {
            return _users;
        }

        public void SellCar(Sale newSale)
        {
            newSale.SaleId = _sales.Last().SaleId + 1;
            _sales.Add(newSale);
            _cars.FirstOrDefault(c => c.CarId == newSale.CarId).Sold = newSale;
        }

        public decimal GetAllSales(string id, DateTime start, DateTime end)
        {
            decimal toReturn = 0;

            foreach (var sale in _sales)
            {
                if (sale.SalesPerson.Id == id && sale.SaleDate >= start && sale.SaleDate <= end)
                {
                    toReturn += sale.SalePrice;
                }
            }
            return toReturn;
        }


        public int GetAllCars(string id, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
