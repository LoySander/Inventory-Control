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
        
        List<Employee> list = Employee.GetUsers();

        public string UserName { get; set; }
        public string Password { get; set; }

        // нужно перенести роли в кастомера
        public bool PurchasingManager { get {return Employee.PurchasingManager; } set { } }
        public bool AccountManager { get { return Employee.AccountManager; } set { } }

        public bool Authorization(IAuthorizationCustomer loginUser)
        {
            foreach(Employee x in list)
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
            foreach (Employee x in list)
            {
                if (loginUser.UserName == "AM")
                {
                    Employee.AccountManager = true;
                }
                else if(loginUser.UserName == "PM")
                {
                    Employee.PurchasingManager = true;
                }

            }
            return false;
        }

       


    }
}
