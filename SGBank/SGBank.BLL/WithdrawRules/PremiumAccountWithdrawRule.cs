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
    public class PremiumAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account.Type != AccountType.Premium)
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
          
            if ((amount + account.Balance) < -500)
            {
                response.Success = false;
                Console.WriteLine("Premium accounts cannot overdraft more than 500 dollar limit!");
                return response;
            }
            else
            {
                response.OldBalance = account.Balance;
                account.Balance += amount;
                if (account.Balance < 0)
                {
                    account.Balance -= 10;
                    Console.WriteLine(account.Balance);
                    Console.WriteLine("Negative balance so here is a 10 dollar overdraft fee");
                }
                response.Account = account;
                response.Amount = amount;
                response.Success = true;
                return response;

            }
        }
    }
    }

