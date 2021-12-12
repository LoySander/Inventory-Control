using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Security.Principal;



namespace Model
{
    public class Employee
    {

        public string UserName { get; set; }
        public string Password { get; set; }

     

        private static WindowsBuiltInRole windowsBuiltInRole;
        public static EmployeeType employeeType;
        public Employee() { }
        public Employee(string userName, string password)
        {
            //Thread.CurrentPrincipal.IsInRole
            UserName = userName;
            Password = password;
        }

        static List<Employee> listUsers = new List<Employee>() {
            new Employee{UserName = "PM",Password = "123"},
        new Employee{UserName = "AM",Password = "321"}
        };

        static public List<Employee> GetUsers()
        {
            return listUsers;
        }

        static public void SetEmployeeType(string str)
        {
            if (str == "AM")
            {
                windowsBuiltInRole = WindowsBuiltInRole.AccountManager;
                employeeType = EmployeeType.AccountManager;
            }
            else if (str == "PM")
            {
                windowsBuiltInRole = WindowsBuiltInRole.PurchasingManager;
                employeeType = EmployeeType.PurchasingManager;
            }
        

            else if (str == "B")
            {
                windowsBuiltInRole = WindowsBuiltInRole.Booker;
                employeeType = EmployeeType.Booker;
            }
            else if (str == "D")
            {
                windowsBuiltInRole = WindowsBuiltInRole.Deliverman;
                employeeType = EmployeeType.Deliverman;
            }

            else if (str == "S")
            {
                windowsBuiltInRole = WindowsBuiltInRole.Storekeeper;
                employeeType = EmployeeType.Storekeeper;
            }
        }

        //List<Customer> list = Customer.GetUsers();
    }
    //  потом будем использовать enum
    public enum EmployeeType
    {
        PurchasingManager,
        AccountManager,
        Booker,
        Deliverman,
        Storekeeper
    }

    public enum WindowsBuiltInRole
    {
        PurchasingManager,
        AccountManager,
        Booker,
        Deliverman,
        Storekeeper
    }



}
