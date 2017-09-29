using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.DepositRules
{
    public class FreeAccountDepositRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();
            response.OldBalance = account.Balance;
            response.Account = account;
            if (account.Type != AccountType.Free)
            {
                response.Success = false;
                response.Message = "Error: a non free account hit the Free Deposit Rule.  Contact IT";
                return response;
            }

            if(amount > 100)
            {
                response.Success = false;
                response.Message = "Free accounts cannot deposit more than $100 at a time";
                return response;
            }

            if (amount <= 0)
            {
                response.Success = false;
                response.Message = "Deposit amounts must be greater than zero.";
                return response;
            }

           
            account.Balance += amount;
            
            response.Amount = amount;
            response.Success = true;

            return response;
        }
    }
}
