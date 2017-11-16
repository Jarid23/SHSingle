using CarDealership.Data.CarRepo.cs;
using CarDealership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class VehicleVM
    {
        public Make Make { get; set; }
        public CarModel Model { get; set; }
        public bool IsNew { get; set; }
        public Style Style { get; set; }
        public int Year { get; set; }
        public bool IsAutomatic { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public int MSRP { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public List<SelectListItem> MakeList { get; set; }
        public List<SelectListItem> ModelList { get; set; }
        public List<SelectListItem> StyleList { get; set; }


        public VehicleVM()
        {
            Make = new Make();
            Model = new CarModel();
            Style = new Style();
            MakeList = new List<SelectListItem>();
            ModelList = new List<SelectListItem>();
            StyleList = new List<SelectListItem>();
        }

        public void PopulateMakeList(ICarRepo repo)
        {
            foreach (var make in repo.GetAllMakes())
            {
                var addMake = new SelectListItem
                {
                    Value = make.MakeId.ToString(),
                    Text = make.MakeType,
                };

                MakeList.Add(addMake);
            }
        }

        public void PopulateModelList(ICarRepo repo)
        {
            foreach (var model in repo.GetAllModels())
            {
                var addModel = new SelectListItem
                {
                    Value = model.ModelId.ToString(),
                    Text = model.ModelType,
                };

                MakeList.Add(addModel);
            }
        }

        public void PopulateStyleList(ICarRepo repo)
        {
            foreach (var style in repo.GetAllStyles())
            {
                var addStyle = new SelectListItem
                {
                    Value = style.StyleId.ToString(),
                    Text = style.StyleType,
                };

                MakeList.Add(addStyle);
            }
        }
    }
}
