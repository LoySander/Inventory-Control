using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;


namespace Services
{
    public class AuthorizationService:IAuthorizationUser
    {
        
       public string UserName { get; set; }
       public string Password { get; set; }
       public UserType employeeType { get { return Employee.employeeType; } set { } }

        public string ClientName { get; set; }
        public int IdClient { get; set; }

        List<Client> listClient = Client.GetClient();
        List<Employee> list = Employee.GetUsers();

        private int id = 0;

        public void Add(string clientName)
        {
            this.ClientName = clientName;
            listClient.Add(new Client() { ClientName = clientName, IdClient = id });
            id++;
        }

        public Client Get(int id)
        {
            return listClient.Where(client => client.IdClient == id).FirstOrDefault(null);
        }

        public bool Authorization(IAuthorizationUser loginUser)
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

        public void CheckRole(IAuthorizationUser loginUser)
        {
            if (loginUser.UserName == "AM")
            {
                Employee.employeeType = UserType.AccountManager;
            }
            else if (loginUser.UserName == "PM")
            {
                Employee.employeeType = UserType.PurchasingManager;
            }
            else if (loginUser.UserName == "B")
            {
                Employee.employeeType = UserType.Booker;
            }
            else if (loginUser.UserName == "D")
            {
                Employee.employeeType = UserType.Deliverman;
            }

            else if (loginUser.UserName == "S")
            {
                Employee.employeeType = UserType.Storekeeper;
            }

           else
            {
                Employee.employeeType = UserType.Client;
            }
            
        }
    }
}
