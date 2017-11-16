using CarDealership.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Model
{
    public class Make
    {
        public int MakeId { get; set; }
        public string MakeType { get; set; }
        public DateTime DateAdded { get; set; }
        public AppUser UserAdded { get; set; }
    }
}
