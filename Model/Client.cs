using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Client
    {
        public string  ClientName{ get; set; }

        public int IdClient { get; set; }

        private static List<Client> listClients = new List<Client>();
      
        static public List<Client> GetClient()
        {
            return listClients;
        }
    }

}
