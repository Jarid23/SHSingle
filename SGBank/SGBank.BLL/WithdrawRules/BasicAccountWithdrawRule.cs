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
    public class BasicAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();
            response.Account = account;
            response.OldBalance = account.Balance;
            if (account.Type != AccountType.Basic)
            {
                response.Success = false;
                Console.WriteLine("“Error: a non-basic account hit the Basic Withdraw Rule. Contact IT");
                return response;
            }
            if (amount >= 0)
            {
                response.Success = false;
                Console.WriteLine("Withdrawal amounts must be negative!");
                return response;
            }
            if (amount < -500)
            {
                response.Success = false;
                Console.WriteLine("Free accounts cannot withdraw more than $500!");
                return response;
            }
            if ((amount + account.Balance) < -100)
            {
                response.Success = false;
                Console.WriteLine("Basic accounts cannot overdraft more than 100 dollar limit!");
                return response;
            }
            else
            {
                
                account.Balance += amount;
                if(account.Balance < 0)
                {
                    account.Balance -= 10;
                    Console.WriteLine(account.Balance);
                    Console.WriteLine("Negative balance so here is a 10 dollar overdraft fee");
                }
                
                response.Amount = amount;
                response.Success = true;
                return response;


            }
        }
    }
}
