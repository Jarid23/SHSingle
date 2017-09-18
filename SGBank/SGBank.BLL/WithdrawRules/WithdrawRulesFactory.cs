using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Interfaces;

namespace SGBank.BLL.WithdrawRules
{
    class WithdrawRulesFactory
    {
        public static IWithdraw Create(AccountType Account)
        {
            switch (Account)
            {
                case AccountType.Free:
                    return new FreeAccountWithdrawRule();
                case AccountType.Basic:
                    return new BasicAccountWithdrawRule();
          

                default:
                    Console.WriteLine("Account type is not supported!");
                    throw new Exception();

            }
        }
    }
}
