using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
   public class LiveDataTests
    {
        static string directory = @"C:\Users\jwagner\Desktop\REPOS\dotnet---jarid---wagner\SGBank";
        string oldfFile = Path.Combine(directory, "LiveData.txt");
        string seedFile = Path.Combine(directory, "SeedData.txt");
        [SetUp]
        public void TestSetup()
        {           
            if(File.Exists(oldfFile))
            {
                File.Delete(oldfFile);
            }
            File.Copy(seedFile, oldfFile);
        }

        [Test]
        public void LiveDataTesting()
        {
            var repo = new LiveDataRepository(oldfFile);
            var basicAccount = repo.LoadAccount("22222");
            Assert.AreEqual("22222", basicAccount.AccountNumber);
            Assert.AreEqual("Basic Customer", basicAccount.Name);
            Assert.AreEqual(500, basicAccount.Balance);
            Assert.AreEqual(AccountType.Basic, basicAccount.Type);

            basicAccount.Balance = 5000;
            basicAccount.Name = "Jarid";
            basicAccount.Type = AccountType.Premium;

            repo.SaveAccount(basicAccount);
            var validateAccount = repo.LoadAccount("22222");
            Assert.AreEqual(5000, validateAccount.Balance);
            Assert.AreEqual("Jarid", validateAccount.Name);
            Assert.AreEqual(AccountType.Premium, basicAccount.Type);
        }
    }
}
