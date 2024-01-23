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

        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public DatabaseModel()
        {
            Host = Properties.Settings.Default.Host;
            Port = Properties.Settings.Default.Port;
            User = Properties.Settings.Default.User;
            Password = Properties.Settings.Default.Password;
        }

        public void Connect()
        {
            try
            {
                string connectionString = "Server=" + Host + ";port=" + Port + ";User Id=" + User + ";password=" + Password;
                mySqlConnection = new MySqlConnection(connectionString);

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
