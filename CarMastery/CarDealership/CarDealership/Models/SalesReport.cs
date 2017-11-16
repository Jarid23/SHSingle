using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class SalesReport
    {
        public string User { get; set; }
 	 	public decimal TotalSales { get; set; }
 	 	public int TotalVehicles { get; set; }
    }
}