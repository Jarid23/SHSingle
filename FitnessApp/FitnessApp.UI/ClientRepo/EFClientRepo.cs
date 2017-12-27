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
            using (var db = new FitnessDBContext())
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }
        }

        public void DeleteClient(int ClientID)
        {
            using (var db = new FitnessDBContext())
            {
                Client toRemove = db.Clients.SingleOrDefault(c => c.ClientID == ClientID);
                if (toRemove != null)
                {
                    db.Clients.Remove(toRemove);
                }
                db.SaveChanges();
            }
        }

        public void EditClient(Client client)
        {
            using (var db = new FitnessDBContext())
            {
                var toEdit = db.Clients.SingleOrDefault(c => c.ClientID == client.ClientID);

                if (toEdit != null)
                {
                    toEdit.ClientName = client.ClientName;
                    toEdit.ClientJoinDate = client.ClientJoinDate;
                    toEdit.CurrentWeight = client.CurrentWeight;
                    toEdit.StartingWeight = client.StartingWeight;
                    toEdit.FitnessGoals = client.FitnessGoals;
                    toEdit.ClientTrainer = client.ClientTrainer;
                }
                db.SaveChanges();
            }
        }

        public IEnumerable<Client> GetAllClients()
        {
            using (var db = new FitnessDBContext())
            {
                var clients = from c in db.Clients
                             select c;
                return clients.ToList();
            }
        }

        public Client GetClientById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClientsByTrainer(int TrainerID)
        {
            using (var db = new FitnessDBContext())
            {
                var trainer = db.Trainers.Where(t => t.TrainerID == TrainerID).FirstOrDefault();
                if (trainer != null)
                {
                    return trainer.Clients;
                }
                return null;
            }
        }
    }
}
