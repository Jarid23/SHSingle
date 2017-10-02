using FlooringMastery.BLL.Interfaces;
using FlooringMastery.BLL.Responses;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private IStateRepository _stateRepository;
        private IProductRepository _productRepository;
       // private LiveDataRepository _liveDataRepository;

        public OrderManager(IOrderRepository orderRepository, IProductRepository productRepository, IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            
        }

        public GetProductsResponse GetProducts()
        {
            GetProductsResponse response = new GetProductsResponse();

            //response.Product = 
            throw new NotImplementedException();
        }

        public List<Tax> GetAllStates()
        {
            return _stateRepository.GetEveryState();
        }

        public DisplayOrderResponse LookupOrder(DateTime orderDate)
        {
            DisplayOrderResponse response = new DisplayOrderResponse();

            response.Order = _orderRepository.LoadOrders(orderDate);
                             

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

        public int GetNextOrderNumber(DateTime userEnteredDate)
        {
            var result = 1;
            
            var orders = _orderRepository.LoadOrders(userEnteredDate);
            if(orders.Count > 0)
            {
                result = orders.Max(o => o.OrderNumber) + 1;                   
            }
            
            return result;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetEveryProduct();
        }

        public AddOrderResponse AddOrder(Order newOrder)
        {
            AddOrderResponse response = new AddOrderResponse();
            response.NewOrder = newOrder;
        
            response.Success = _orderRepository.AddOrder(response.NewOrder);
            
            return response;
        }
        

        //public Order GetSingleOrder(string OrderDate,string OrderNumber)
        //{
        //     looping logic
        //}

        public RemoveOrderResponse RemoveOrder(Order orderBeingRemoved)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();
            response.OrderBeingRemoved = orderBeingRemoved;

            response.Success = _orderRepository.RemoveOrder(response.OrderBeingRemoved);

            return response;
            // response.Success = _orderRepository.AddOrder(response.NewOrder);
        }
    }
}

