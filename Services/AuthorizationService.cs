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
    public class AuthorizationService:IAuthorizationCustomer
    {
        
        List<Employee> list = Employee.GetUsers();

        public string UserName { get; set; }
        public string Password { get; set; }

        // нужно перенести роли в кастомера
       public EmployeeType employeeType { get { return Employee.employeeType; } set { } }

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

        public void CheckRole(IAuthorizationCustomer loginUser)
        {
            //AppDomain myDomain = AppDomain.CurrentDomain;
            //WindowsPrincipal principial = (WindowsPrincipal)Thread.CurrentPrincipal;
            //WindowsIdentity windowsIdentity = new WindowsIdentity(loginUser.ToString());
           
            
            //WindowsPrincipal myPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;
            //Array wbirFields = Enum.GetValues(typeof(Model.WindowsBuiltInRole));

            Employee.SetEmployeeType(loginUser.ToString());
            
            //if (loginUser.UserName == "AM")
            //{
            //    Employee.AccountManager = true;
            //    x.employeeType = EmployeeType.AccountManager;
            //}
            //else if (loginUser.UserName == "PM")
            //{
            //    Employee.PurchasingManager = true;
            //    x.employeeType = EmployeeType.PurchasingManager;
            //}


        }


    }
}
