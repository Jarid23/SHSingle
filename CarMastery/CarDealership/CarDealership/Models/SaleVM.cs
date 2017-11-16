using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class SaleVM
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int SalePrice { get; set; }
        public string PurchaseType { get; set; }

    }
}