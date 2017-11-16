using CarDealership.Data.CarRepo.cs;
using CarDealership.Data.SpecialRepo;
using CarDealership.Model;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    //[Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        ISpecialRepo repos = SpecialRepoFactory.Create();
        ICarRepo repo = CarRepoFactory.Create();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddVehicle()
        {
            VehicleVM viewToPass = new VehicleVM();
            viewToPass.PopulateMakeList(repo);
            viewToPass.PopulateModelList(repo);
            viewToPass.PopulateStyleList(repo);
            return View(viewToPass);
        }

        [HttpPost]
        public ActionResult AddVehicle(VehicleVM m)
        {
            if (ModelState.IsValid)
            {
                var newCar = new Car
                {
                    CarYear = m.Year,
                    Exterior = m.Color,
                    Interior = m.Interior,
                    Sold = null,
                    IsNew = m.IsNew,
                    IsFeatured = false,
                    IsManual = !m.IsAutomatic,
                    Mileage = m.Mileage,
                    MSRP = m.MSRP,
                    Price = m.Price,
                    VIN = m.VIN,
                    Model = new CarModel
                    {
                        ModelId = m.Model.ModelId
                    },
                };
                repo.AddCar(newCar);

                return RedirectToAction("Index");
            }
            m.PopulateMakeList(repo);
            m.PopulateModelList(repo);
            m.PopulateStyleList(repo);

            return View(m);
        }   

        public ActionResult AddSpecial()
        {
            return View(new SpecialVM());
        }

        [HttpPost]
        public ActionResult AddSpecial(SpecialVM model)
        {
            if (ModelState.IsValid)
            {
                Special one = new Special
                {
                    Description = model.Description ,
                    Title = model.Title ,
                };

                repos.AddSpecial(one);
            }
            return View(model);
        }

        public ActionResult EditVehicle()
        {
            var model = new VehicleVM();
            return View(model);
        }

        public ActionResult Users()
        {
            var model = new List<UserVM>();
            return View(model);
        }

        public ActionResult AddModel()
        {
            var model = new AddModelVM();

            model.CreateList(repo);

            return View(model);
        }

        [HttpPost]
        public ActionResult AddModel(CarModel model)
        {
            var repo = CarRepoFactory.Create();

            if (ModelState.IsValid)
            {
                var newmodel = new AddModelVM();

                newmodel.CreateList(repo);

                return View(newmodel);
            }
            return View(model);
        }

        public ActionResult AddUser()
        {
            UserVM viewToPass = new UserVM();
            return View(viewToPass);
        }

        public ActionResult EditUser(string id)
        {
            var model = new UserVM();
            return View(model);
        }



        public ActionResult AddMake()
        {
            return View(new Make());
        }

        public ActionResult SalesReport()
        {
            var model = new SalesReportVM();

            model.SetSalesTeam(repo);

            return View(model);
        }

        public ActionResult InventoryReport()
        {
            var model = new InventoryReportVM();

            model.PopulateNew(repo);
            model.PopulateUsed(repo);

            return View(model);
        }
    }
}

