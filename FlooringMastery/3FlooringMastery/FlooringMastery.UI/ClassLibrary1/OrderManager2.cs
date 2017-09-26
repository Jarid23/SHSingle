using FlooringMastery.BLL.Interfaces;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class OrderManager2
    {
        private IOrderRepository _repo;
//        private ITaxRepo _taxrepo;
//        private IProductRepo _productrepo;

        public string GetDate()
        {
            do
            {
                Console.Write("Enter date of orders to display (MMDDYYYY): ");
                string input = Console.ReadLine();
                int num;
                var passThisString = input;
                bool parsedinput = int.TryParse(input, out num);
                if (parsedinput && input.Length == 8)
                {
                    return passThisString;
                }
                DateTime numcheck;
                bool parseddatetime = DateTime.TryParse(input, out numcheck);
                if (parseddatetime)
                {
                    return numcheck.ToString("MMddyyyy");
                }
            } while (true);
        }

        public Response DisplayOrders()
        {
            Response displayOrderResponse = new Response();

            var loadOrderVariable = _repo.LookupOrder(GetDate());

            try
            {
                if (loadOrderVariable.Count == 0)
                {
                    displayOrderResponse.Success = false;
                    displayOrderResponse.Message = "No orders were found with that date.";
                }
                else
                {
                    displayOrderResponse.Success = true;
                    displayOrderResponse.Data = new DisplayOrderReceipt();
                    displayOrderResponse.Data.Date = int.Parse(date);
                    displayOrderResponse.Data.Orders = Order;
                }
            }
            catch (Exception ex)
            {
                displayOrderResponse.Success = false;
                displayOrderResponse.Message = ex.Message;
            }
            return displayOrderResponse;
        }
    }
}
    
