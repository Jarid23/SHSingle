using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawRules
{
    public class FreeAccountWithdrawlRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();
            response.OldBalance = account.Balance;
            response.Account = account;
            if (account.Type != AccountType.Free)
            {
                response.Success = false;
                Console.WriteLine("“Error: a non-free account hit the Free Withdraw Rule. Contact IT");
                return response;
            }
            if (amount >= 0)
            {
                response.Success = false;
                Console.WriteLine("Withdrawal amounts must be negative!");
                return response;
            }
            if (amount < -100)
            {
                response.Success = false;
                Console.WriteLine("Free accounts cannot withdraw more than $100!");
                return response;
            }
            if ((amount + account.Balance) < 0)
            {
                response.Success = false;
                Console.WriteLine("Free accounts cannot overdraft!");
                return response;
            }
            else
            {
                
                account.Balance += amount;
               
                response.Amount = amount;
                response.Success = true;
                return response;


            }

            
        }
    }
}
