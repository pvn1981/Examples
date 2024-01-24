using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWithPassword.Models
{
    enum Role
    {
        Administrator,
        User
    }

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

        public void CreateDatabase()
        {
            using (var command = new MySqlCommand { Connection = mySqlConnection })
            {
                try
                {
                    command.CommandText = "CREATE DATABASE IF NOT EXISTS " + rakursDeviceDB;
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message + " sql query error.");
                    return;
                }
            }
        }

        public void CreateTable()
        {
            using (var command = new MySqlCommand { Connection = mySqlConnection })
            {
                try
                {
                    // MySqlDataAdapter

                    command.CommandText =
                        "CREATE TABLE IF NOT EXISTS " + userTb + "(" +
                        "`ID` int NOT NULL," +
                        "`Computer` varchar(100) DEFAULT NULL," +
                        "`Login` varchar(100) DEFAULT NULL," +
                        "PRIMARY KEY (`ID`)" +
                        ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";

                    command.ExecuteNonQuery();//Execute your command
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message + " sql query error.");
                    return;
                }
            }
        }

        private MySqlConnection mySqlConnection;
        private string rakursDeviceDB = "testDatabase";
        private string userTb = "testDatabase.user_rakurs";
    }
}
