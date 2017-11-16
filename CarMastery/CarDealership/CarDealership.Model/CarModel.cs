using CarDealership.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class CarModel
    {
        [Key]
        public int ModelId { get; set; }
        public string ModelType { get; set; }
        public Make CarMake { get; set; }
        public Style ModelStyle { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public AppUser UserAdded { get; set; }
    }
}
