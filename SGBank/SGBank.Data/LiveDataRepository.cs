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
            Account c = null;
            using (StreamReader reader = new StreamReader(_filepath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    if(AccountNumber == columns[0])
                    {
                        c = new Account();
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

            string line = $"{account.AccountNumber},{account.Name},{account.Balance},{account.Type.ToString()[0]}";
            string[] everyLine = File.ReadAllLines(_filepath);

            using (StreamWriter writer = new StreamWriter(_filepath))
            {
                foreach (var fileline in everyLine)
                {
                    string[] columns = fileline.Split(',');

                    if (account.AccountNumber == columns[0])
                    {
                        writer.WriteLine(line);
                    }
                    else
                    {
                        writer.WriteLine(fileline);
                    }
                }
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
