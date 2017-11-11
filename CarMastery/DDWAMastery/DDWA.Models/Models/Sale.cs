using DDWA.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDWA.Models.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public Customer SaleCustomer { get; set; }
        public int SalesPrice { get; set; } 
        public string PurchaseType { get; set; }       
        public DateTime SaleDate { get; set; }
        public AppUser SalesPerson { get; set; }
        public int CarId { get; set; }
    }
}
