using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class Dvd
    {
        public int dvdId { get; set; }
        public string title { get; set; }
        public string notes { get; set; }
        [Column("ReleaseYear")]
        public int realeaseYear { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        
    }
}
