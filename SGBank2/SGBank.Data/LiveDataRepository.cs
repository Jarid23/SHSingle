using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class LiveDataRepository : IAccountRepository
    {
        string _filepath = null;
        public LiveDataRepository(string filepath)
        {            
             _filepath = filepath;
        }
      
        // populate list of account objects (member variable for this repo)
        public Account LoadAccount(string AccountNumber)
        {
            List<Account> Accounts = new List<Account>();
            Account c = new Account();
            using (StreamReader reader = new StreamReader(_filepath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    if(AccountNumber == columns[0])
                    {
                        c.AccountNumber = columns[0];
                        c.Name = columns[1];
                        c.Balance = decimal.Parse(columns[2]);
                        switch (columns[3])
                        {
                            case "F":
                                c.Type = AccountType.Free;
                                break;
                            case "B":
                                c.Type = AccountType.Basic;
                                break;
                            case "P":
                                c.Type = AccountType.Premium;
                                break;
                            case "Free":
                                c.Type = AccountType.Free;
                                break;
                            case "Basic":
                                c.Type = AccountType.Basic;
                                break;
                            case "Premium":
                                c.Type = AccountType.Premium;
                                break;
                        }
                    }
                                    
                }

            } return c; 
        }

        public void SaveAccount(Account account)
        {
            List<Account> Accounts = new List<Account>();
            Account c = new Account();
            string line = $"{account.AccountNumber},{account.Name},{account.Balance},{account.Type}";
            using (StreamWriter writer = new StreamWriter(_filepath))
            {
                writer.Write(line);
            }
           
        }
        //private Account ReadAllAccounts()
        //{

        //}
        //private Account WriteAllAccounts()
        //{

        //}
    }
}
