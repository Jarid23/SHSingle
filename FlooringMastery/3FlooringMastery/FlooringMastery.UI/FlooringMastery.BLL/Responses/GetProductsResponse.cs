using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL.Responses
{
    public class GetProductsResponse : Response
    {
        public List<Product> Product { get; set; }
    }
}
