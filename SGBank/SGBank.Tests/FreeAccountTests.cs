using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
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
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }

        [TestCase("12345", "", 100, AccountType.Free, 250,100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100,100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, 100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, 150, true)]
        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount,decimal expectedBalance, bool expectedResult)
        {
            IDeposit depositResponse = new FreeAccountDepositRule();

            Account accountVariable = new Account()
            {

                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType
            };
            AccountDepositResponse accountDepositResponse = depositResponse.Deposit(accountVariable , amount);
            Assert.AreEqual(expectedResult, accountDepositResponse.Success);
            if (expectedResult)
            {
                Assert.AreEqual(expectedBalance, accountDepositResponse.Account.Balance);
            }
        }
    }
}

