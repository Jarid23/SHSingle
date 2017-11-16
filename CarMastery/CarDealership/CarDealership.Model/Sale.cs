using CarDealership.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int CarId { get; set; }
        public int SalePrice { get; set; }
        public Customer SaleCustomer { get; set; }
        public string PurchaseType { get; set; }
        public AppUser SalesPerson { get; set; }
        public DateTime SaleDate { get; set; }
        
    }
}
