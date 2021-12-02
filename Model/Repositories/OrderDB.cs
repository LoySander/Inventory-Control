using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Model.Repositories
{
    class OrderDB
    {
        private MySqlConnection connection = new MySqlConnection("server = localhost;port=3306;username=root;password=root;database = orderclient");

        private static OrderDB INSTANCE;

        public static OrderDB getInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new OrderDB();
            }
            return INSTANCE;
        }

        private OrderDB()
        {

        }

        public void OpenDB()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseDB()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
