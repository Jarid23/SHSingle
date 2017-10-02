using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }

        public decimal MaterialCost => (CostPerSquareFoot * Area);
        public decimal LaborCost => LaborCostPerSquareFoot * Area;
        public decimal Tax => TaxRate * (LaborCost + MaterialCost);
        public decimal Total => Tax + LaborCost + MaterialCost;
    }
}
