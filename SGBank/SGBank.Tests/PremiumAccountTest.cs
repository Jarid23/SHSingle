using NUnit.Framework;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    public class PremiumAccountTest
    {
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, -599, -499, true)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, -601, -501, false)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdrawResponse = new PremiumAccountWithdrawRule();

            Account accountVariable = new Account()
            {
                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType
            };
            AccountWithdrawResponse accountWithdrawResponse = withdrawResponse.Withdraw(accountVariable, amount);
            Assert.AreEqual(expectedResult, accountWithdrawResponse.Success);
        }

    }
}

