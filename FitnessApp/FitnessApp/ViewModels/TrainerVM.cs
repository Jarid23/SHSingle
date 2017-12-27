using FitnessApp.Models.Models;
using FitnessApp.UI.ClientRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FitnessApp.Models.ViewModels
{
    public class TrainerVM
    {
        IClientRepo crepo = ClientRepoFactory.Create();
        public int TrainerID { get; set; }
        public string TrainerName { get; set; }
        public int HourlyRate { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<Client> Clients { get; set; }
        public List<SelectListItem> ClientList { get; set; }
        public List<int> SelectedClientID { get; set; }

        public TrainerVM()
        {
            ClientList = new List<SelectListItem>();
            var AllClients = crepo.GetAllClients();
            SelectedClientID = new List<int>();

            foreach (var client in AllClients)
            {
                ClientList.Add(new SelectListItem
                {
                    Value = client.ClientID.ToString(),
                    Text = client.ClientName
                });
            }
        }
    }
}
