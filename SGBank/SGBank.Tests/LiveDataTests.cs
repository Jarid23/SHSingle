using NUnit.Framework;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
   public class LiveDataTests
    {
        [TestCase("11111", "Free Customer", 100, AccountType.Free)]
        [TestCase("22222", "Basic Customer", 500, AccountType.Basic)]
        [TestCase("33333", "Premium Customer", 1000, AccountType.Premium)]       
        public void LiveDataTesting(string accountNumber, string name, decimal balance, AccountType accountType)
        {

        }
    }
}
