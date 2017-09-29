using FlooringMastery.BLL.Interfaces;
using FlooringMastery.BLL.Responses;
using FlooringMastery.Models;
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

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public GetProductsResponse GetProducts()
        {
            GetProductsResponse response = new GetProductsResponse();

            response.Product = 
        }

        public List<Tax> GetAllStates()
        {
            throw new NotImplementedException();
        }

        public DisplayOrderResponse LookupOrder(string orderDate)
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
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public AddOrderResponse AddOrder(Order NewOrder)
        {
            AddOrderResponse response = new AddOrderResponse();
            response.NewOrder = new Order();

            response.NewOrder.OrderNumber = NewOrder.OrderNumber;
            response.NewOrder.CustomerName = NewOrder.CustomerName;
            response.NewOrder.State = NewOrder.State;
            response.NewOrder.TaxRate = NewOrder.TaxRate;
            response.NewOrder.ProductType = NewOrder.ProductType;
            response.NewOrder.Area = NewOrder.Area;
            response.NewOrder.CostPerSquareFoot = NewOrder.CostPerSquareFoot;
            response.NewOrder.LaborCostPerSquareFoot = NewOrder.LaborCostPerSquareFoot;
            response.NewOrder.MaterialCost = NewOrder.MaterialCost;
            response.NewOrder.LaborCost = NewOrder.LaborCost;
            response.NewOrder.Tax = NewOrder.Tax;
            response.NewOrder.Total = NewOrder.Total;

            _orderRepository.AddOrder(response.NewOrder);
            return response;
        }
        

        //public Order GetSingleOrder(string OrderDate,string OrderNumber)
        //{
        //     looping logic
        //}
        //public RemoveOrderResponse RemoveOrder(Order OrderBeingRemoved)
        //{

        //}
    }
}

