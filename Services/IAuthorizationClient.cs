using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAuthorizationClient
    {
       string ClientName { get; set; }
        int IdClient { get; set; }
        void Add(string clientName);
    }
}
