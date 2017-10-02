using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL.Responses
{
   public class RemoveOrderResponse : Response
    {
        public Order OrderBeingRemoved { get; set; }
    }
}
