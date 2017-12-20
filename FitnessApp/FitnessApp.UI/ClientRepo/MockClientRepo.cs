using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Models.Models;

namespace FitnessApp.UI.ClientRepo
{
    public class MockClientRepo : IClientRepo
    {
        private static List<Client> _clients = new List<Client>
        {
            new Client
            {
                ClientID = 1,
                ClientName = "Jarid",
                //ClientJoinDate = 12/19/2017,
                StartingWeight = 133,
                CurrentWeight = 156,
                FitnessGoals = "I want to get big and strong so girls are attracted to me.",
                //Trainer = Alphabro                
            }
        };

        public void AddClient(Client client)
        {
            _clients.Add(client);
        }

        public void DeleteClient(int ClientID)
        {
            _clients.RemoveAll(c => c.ClientID == ClientID);
        }

        public void EditClient(Client client)
        {
            var c = new Client();
            foreach (var clientToEdit in _clients)
            {
                if (clientToEdit.ClientID == client.ClientID)
                {
                    clientToEdit.ClientName = client.ClientName;
                    clientToEdit.ClientJoinDate = client.ClientJoinDate;
                    clientToEdit.CurrentWeight = client.CurrentWeight;
                    clientToEdit.StartingWeight = client.StartingWeight;
                    clientToEdit.FitnessGoals = client.FitnessGoals;
                    clientToEdit.Trainer = client.Trainer;

                }
            }
            c = client;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _clients;
        }

        public IEnumerable<Client> GetClientsByTrainer(int TrainerID)
        {
            var clients = _clients.Where(c => c.Trainer.TrainerID == TrainerID);
            if (clients != null)
            {
                return clients;
            }
            return null;
        }
    }
}
