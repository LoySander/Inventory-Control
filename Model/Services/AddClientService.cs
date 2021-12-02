using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Repositories;

namespace Model.Services
{
   public class AddClientService : IAuthorizationClient
    {
        public string ClientName { get; set; }
        public int IdClient { get; set; }

        List<Client> list = Client.GetClient();

        private int id = 0;

        public void Add(string clientName)
        {
            this.ClientName = clientName;
            list.Add(new Client() { ClientName = clientName, IdClient = id });
            id++;
        }
    }
}


