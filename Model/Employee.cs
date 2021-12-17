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

        public static UserType employeeType;
        public Employee() { }
        public Employee(string userName, string password)
        {
            //Thread.CurrentPrincipal.IsInRole
            UserName = userName;
            Password = password;
        }

        static List<Employee> listUsers = new List<Employee>() {
            new Employee{UserName = "PM",Password = "123"},
        new Employee{UserName = "AM",Password = "321"},
        new Employee{UserName = "S",Password = "111"},
        new Employee{UserName = "B",Password = "121"},
        };

        static public List<Employee> GetUsers()
        {
            return listUsers;
        }
    } 
    public enum UserType
    {
        PurchasingManager,
        AccountManager,
        Booker,
        Deliverman,
        Storekeeper,
        Client
    }
}
