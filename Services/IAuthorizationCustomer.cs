using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public interface IAuthorizationCustomer
    {
        string UserName { get; set; }
        string Password { get; set; }
        bool PurchasingManager { get; set; }
        bool AccountManager { get; set; }
        bool Authorization(IAuthorizationCustomer loginUser);

        bool CheckRole(IAuthorizationCustomer loginUser);
    }
}
