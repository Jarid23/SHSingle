using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
   public class DVD
    {
      public int DvdID { get; set; }
        
      public string TItle { get; set; }

        public string Notes { get; set; }

        public int ReleaseYear { get; set; }

        public string Director { get; set; }

        public string Rating { get; set; }
    }
}
