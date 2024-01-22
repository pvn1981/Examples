using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWithPassword.Models
{
    class DatabaseModel
    {
        public bool Connected { get; set; }

        public DatabaseModel()
        {
            string host = "127.0.0.1";
            int port = 3306;
            string user_name = "root";
            string password = "12345678";

            string connectionString = "Server=" + host + ";port=" + port + ";User Id=" + user_name + ";password=" + password;
            mySqlConnection = new MySqlConnection(connectionString);
        }

        public void Connect()
        {
            try
            {
                mySqlConnection.Open();
                if (mySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    Connected = true;
                }
                else
                {
                    Connected = false;
                }
            }
            catch (MySqlException exception)
            {
                Console.WriteLine("error message: {0}", exception.Message);
                Connected = false;
            }
        }

        public void Disconnect()
        {
            mySqlConnection.Close();
            Connected = false;
        }

        private MySqlConnection mySqlConnection;
        
    }
}
