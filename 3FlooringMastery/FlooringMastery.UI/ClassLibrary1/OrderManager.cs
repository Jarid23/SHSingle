using FlooringMastery.BLL.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
      //  private ITaxRepo _taxrepo;
      //  private IProductRepository _productrepo;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public DisplayOrderResponse LookupOrder(string orderDate)
        {
            DisplayOrderResponse response = new DisplayOrderResponse();

            response.Order = _orderRepository.LookupOrder(orderDate);
                             

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"{orderDate} is not a valid date.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }
    }

}

