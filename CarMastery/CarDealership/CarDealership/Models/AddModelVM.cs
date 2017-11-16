using CarDealership.Data.CarRepo.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class AddModelVM
    {
        public int MakeID { get; set; }
        public string ModelName { get; set; }
        public int StyleId { get; set; }
        public List<SelectListItem> MakeList { get; set; }
        public List<SelectListItem> StyleList { get; set; }

        public AddModelVM()
        {
            MakeList = new List<SelectListItem>();
            StyleList = new List<SelectListItem>();
        }

        public void CreateList(ICarRepo repo)
        {
            var list = repo.GetAllMakes();
            foreach(var item in list)
            {
                MakeList.Add(new SelectListItem
                {
                    Value = item.MakeId.ToString(),
                    Text = item.MakeType,
                });
            }
        }
        public void CreateStyle(ICarRepo repo)
        {
            var list = repo.GetAllStyles();
            foreach (var item in list)
            {
                MakeList.Add(new SelectListItem
                {
                    Value = item.StyleId.ToString(),
                    Text = item.StyleType,
                });
            }
        }
    }
}