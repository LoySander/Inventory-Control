using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model.Services;


namespace Model.Repositories
{
    public class Employee
    {

        public string UserName { get; set; }
        public string Password { get; set; }

        public EmployeeType employeeType { get; set; }

        public static bool PurchasingManager = false;
        public static bool AccountManager = false;

        public Employee() { }
        public Employee(string userName, string password)
        {
            //Thread.CurrentPrincipal.IsInRole

            UserName = userName;
            Password = password;
        }

        static List<Employee> listUsers = new List<Employee>() {
            new Employee{UserName = "PM",Password = "123",employeeType = EmployeeType.PurchasingManager},
        new Employee{UserName = "AM",Password = "321",employeeType = EmployeeType.AccountManager}
        };

        static public List<Employee> GetUsers()
        {
            return listUsers;
        }

        //List<Customer> list = Customer.GetUsers();
    }
   //  потом будем использовать enum
    public enum EmployeeType
    {
        PurchasingManager,
        AccountManager
    }
}
