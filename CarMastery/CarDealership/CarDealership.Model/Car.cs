using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class Car
    {
        public int CarId { get; set; }
        public string VIN { get; set; }
        public CarModel Model { get; set; }
        public Sale Sold { get; set; }
        public string Interior { get; set; }
        public string Exterior { get; set; }
        public int MSRP { get; set; }
        public int Mileage { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public bool IsManual { get; set; }
        public int CarYear { get; set; }
        public int Price { get; set; }
        public string ImageLocation { get; set; }

    }
}
