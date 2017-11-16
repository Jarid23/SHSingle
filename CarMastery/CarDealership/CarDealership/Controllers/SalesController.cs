using CarDealership.Data;
using CarDealership.Data.CarRepo.cs;
using CarDealership.Model;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    //[Authorize(Roles = "admin,Sales")]
    public class SalesController : Controller
    {
        ICarRepo repo = CarRepoFactory.Create();
        CarDBContext context = new CarDBContext();
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sale(int id)
        {
            var model = new SaleVM();

            model.CarId = id;

            return View(model);
        }

        public ActionResult ChangePassWord()
        {
            return View(new UserVM());
        }

        [HttpPost]
        public ActionResult ChangePassWord(UserVM model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Sale(SaleVM model)
        {
            if (ModelState.IsValid)
            {
                var newSale = new Sale
                {
                    PurchaseType = model.PurchaseType,
                    SaleDate = DateTime.Now,
                    SalePrice = model.SalePrice,
                    SalesPerson = context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name),
                    CarId = model.CarId,
                    SaleCustomer = new Customer
                    {
                        Email = model.Email,
                        Name = model.Name,
                        Phone = model.Phone,
                        CustomerAddress = new Address
                        {
                            State = model.State,
                            City = model.City,
                            Zip = model.Zip,
                            Street1 = model.Street1,
                            Street2 = model.Street2,
                        }
                    }
                };

                repo.SellCar(newSale);

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
