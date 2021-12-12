using Model;
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
         
        EmployeeType employeeType{ get; }
        bool Authorization(IAuthorizationCustomer loginUser);

        void CheckRole(IAuthorizationCustomer loginUser);
    }
}
