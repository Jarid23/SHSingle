using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Major
    {
        public int MajorId { get; set; }
        [MaxLength(50), MinLength(2)]
        public string MajorName { get; set; }
    }
}