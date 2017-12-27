using FitnessApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.UI.ClientRepo
{
    public interface IClientRepo
    {
        void AddClient(Client client);
        void EditClient(Client client);
        void DeleteClient(int ClientID);
        Client GetClientById(int id);
        IEnumerable<Client> GetAllClients();
        IEnumerable<Client> GetClientsByTrainer(int TrainerID);
        
    }
}
