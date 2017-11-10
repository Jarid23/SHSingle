using DVDLibrary.Data.Repositories;
using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Repositories
{
    public class DVDRepositoryFactory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "ADO":
                    return new ADORepository();
                case "EF":
                    return new EFRepository();
                case "Mock":
                    return new MockRepository();
                default:
                    throw new Exception("App config mode value must be ADO, EF or Mock");
            }
        }
    }
}
