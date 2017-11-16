using CarDealership.Data.CarRepo.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class SalesReportVM
    {
        public List<SelectListItem> SalesTeam { get; set; }

        public SalesReportVM()
        {
            SalesTeam = new List<SelectListItem>();
        }

        public void SetSalesTeam(ICarRepo repo)
        {
            SalesTeam.Add(new SelectListItem
            {
                Value = "All",
                Text = "All",
            });
        foreach(var member in repo.GetSalesTeam())
            {
                SalesTeam.Add(new SelectListItem
                {
                    Value = member.FirstName,
                    Text = member.FirstName
                });
            }
        }
    }
}