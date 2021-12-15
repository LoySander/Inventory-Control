using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public interface IAuthorizationUser: IAuthorizationClient
    {
        string UserName { get; set; }
        string Password { get; set; } 
        UserType employeeType{ get; }
        bool Authorization(IAuthorizationUser loginUser);

        void CheckRole(IAuthorizationUser loginUser);
    }
}
