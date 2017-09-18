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

            if (account.Type != AccountType.Basic)
            {
                response.Success = false;
                Console.WriteLine("Error: a non-basic account hit the Basic Withdraw Rule. Contact IT");
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
                Console.WriteLine("Basic accounts cannot withdraw more than $500!");
                return response;
            }
            if ((amount + account.Balance) < -100)
            {
                response.Success = false;
                Console.WriteLine("This amount will overdraft more than your $100 limit!");
                return response;
            }
            else
            {
                response.Success = true;
                response.Account = account;
                response.Amount = amount;
                response.OldBalance = account.Balance;
                account.Balance = account.Balance - amount;
                if(account.Balance < 0)
                {
                    account.Balance = account.Balance - 10;
                    Console.WriteLine("Your account balance was negative so we took another ten bucks lolol");
                }
                return response;
            }
        }

    }
}

