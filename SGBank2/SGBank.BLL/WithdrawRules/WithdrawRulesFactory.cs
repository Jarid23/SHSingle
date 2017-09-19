using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class WithdrawRulesFactory
    {
        public static IWithdraw Create(AccountType Account)
        {
            switch (Account)
            {
                case AccountType.Free:
                    return new FreeAccountWithdrawlRule();              
                case AccountType.Basic:
                    return new BasicAccountWithdrawRule();
                case AccountType.Premium:
                    return new PremiumAccountWithdrawRule();
                
                default:
                    Console.WriteLine("Account type is not supported!");
                    throw new Exception();
            }
        }
    }
}
