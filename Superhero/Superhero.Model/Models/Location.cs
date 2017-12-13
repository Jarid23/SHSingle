using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Model.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        //[Required(ErrorMessage = "Location Name Required")]
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string LocationAddress { get; set; }
        public int LatitudeCoordinate { get; set; }
        public int LongitudeCoordinate { get; set; }
    }
}

