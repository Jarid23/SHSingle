using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class ContactVM
    {
        [Required(ErrorMessage = "We require your name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "We require a message")]
        public string Message { get; set; }
    }
}