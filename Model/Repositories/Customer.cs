using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Services;


namespace Model.Repositories
{
    public class Customer
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public static bool PurchasingManager { get; set; }
        public static bool AccountManager { get; set; }

        public Customer() { }
        public Customer(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        static List<Customer> listUsers = new List<Customer>() {
            new Customer{UserName = "PM",Password = "123" },
        new Customer{UserName = "AM",Password = "321"}
        };

        static public List<Customer> GetUsers()
        {
            return listUsers;
        }

        //List<Customer> list = Customer.GetUsers();
    }
}
