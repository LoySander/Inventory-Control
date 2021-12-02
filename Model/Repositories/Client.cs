using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Services;

namespace Model.Repositories
{
    public class Client:IAuthorizationClient
    {
        public string UserName { get; set; }

        public string IdClient { get; set; }

        public Client()
        {

        }

        public Client (string userName)
        {
            UserName = userName;
        }
    }

}
