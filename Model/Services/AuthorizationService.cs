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

        // нужно перенести роли в кастомера
        public bool PurchasingManager { get { return Customer.AccountManager; } set { } }
        public bool AccountManager { get { return Customer.AccountManager; } set { } }

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
                    // здесь поменять
                    AccountManager = true;
                    Customer.AccountManager = true;
                }
                else if(loginUser.UserName == "PM")
                {
                    PurchasingManager = true;
                    Customer.PurchasingManager = true;
                }

            }
            return false;
        }


    }
}
