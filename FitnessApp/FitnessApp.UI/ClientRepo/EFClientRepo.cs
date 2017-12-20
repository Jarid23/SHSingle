using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Models.Models;

namespace FitnessApp.UI.ClientRepo
{
    public class EFClientRepo : IClientRepo
    {
        public void AddClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(int ClientID)
        {
            throw new NotImplementedException();
        }

        public void EditClient(Client ClientID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClientsByTrainer(int TrainerID)
        {
            throw new NotImplementedException();
        }
    }
}
