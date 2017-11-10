using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDWA.Models.Models
{
   public class PurchaseType
    {
        public int PurchaseID { get; set; }
        public bool IsBankFinanced { get; set; }
        public bool IsDealershipFinanced { get; set; }
        public int Amount { get; set; }
    }
}
