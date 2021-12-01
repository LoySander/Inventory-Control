using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Repositories;


namespace Model.Services
{
    public class AuthorizationService:IAuthorizationCustomer
    {
        
        List<Customer> list = Customer.GetUsers();

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool PurchasingManager { get; set; }
        public bool AccountManager { get; set; }

        public bool Authorization(IAuthorizationCustomer loginUser)
        {
            foreach(Customer x in list)
            {
                if(loginUser.Password == x.Password && loginUser.UserName == x.UserName)
                {
                    return true;
                }
                
            }
            return false;
        }

        public bool CheckRole(IAuthorizationCustomer loginUser)
        {
            foreach (Customer x in list)
            {
                if (loginUser.UserName == "AM")
                {
                    AccountManager = true;
                }
                else if(loginUser.UserName == "PM")
                {
                    PurchasingManager = true;
                }

            }
            return false;
        }


    }
}
