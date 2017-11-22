using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Superhero.Models
{
    public class ChangePasswordVM
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string newPasswordConfirm { get; set; }
    }
}