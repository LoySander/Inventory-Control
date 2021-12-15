using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Services
{
    // можно не использовать класс
    public class ClientService
    {
        public string ClientName { get; set; }
        public int IdClient { get; set; }

        List<Client> list = Client.GetClient();

        private int id = 0;

        public Client Get(int id)
        {
            return list.Where(client => client.IdClient == id).FirstOrDefault(null);
        }
    }
}


