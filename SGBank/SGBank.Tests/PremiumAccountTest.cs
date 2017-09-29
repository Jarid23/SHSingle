using NUnit.Framework;
using SGBank.BLL.DepositRules;
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
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, -599, -509, true)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, -601, 100, false)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal expectedBalance, bool expectedResult)
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
            Assert.AreEqual(expectedBalance, accountWithdrawResponse.Account.Balance);
        }

        [TestCase("12345", "", 100, AccountType.Free, 250, 100, false)]
        [TestCase("12345", "Premium Account", 100, AccountType.Premium, -100, 100, false)]
        [TestCase("12345", "Premium Account", 100, AccountType.Free, 50, 100, false)]
        [TestCase("12345", "Premium Account", 100, AccountType.Premium, 50, 150, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal expectedBalance, bool expectedResult)
        {
            IDeposit depositResponse = new NoLimitDepositRule();

            Account accountVariable = new Account()
            {
                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType
            };
            AccountDepositResponse accountDepositResponse = depositResponse.Deposit(accountVariable, amount);
            Assert.AreEqual(expectedResult, accountDepositResponse.Success);
            Assert.AreEqual(expectedBalance, accountDepositResponse.Account.Balance);
            //deposit
        }


    }
}