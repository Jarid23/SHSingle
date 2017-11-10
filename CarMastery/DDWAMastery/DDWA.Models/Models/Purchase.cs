using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDWA.Models.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public string Customer { get; set; }
        public int SalesPrice { get; set; }
        public int MSRP { get; set; }
        public int VINNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
