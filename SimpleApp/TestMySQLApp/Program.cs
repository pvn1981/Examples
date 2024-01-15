using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TestMySQLApp
{
    class Program
    {
        private static void CreateDatabase(MySqlConnection connection, string dtName)
        {
            Connect(ref connection);

            // Команда Insert.
            string query = string.Format("CREATE DATABASE IF NOT EXISTS {0};", dtName);
            MySqlCommand cmd = new MySqlCommand(query, connection);

            // Выполнить Command (использованная для  delete, insert, update).
            int rowCount = cmd.ExecuteNonQuery();

            Console.WriteLine("Row Count affected = " + rowCount);
        }

        private static void CreateTable(MySqlConnection connection, string dtName, string tbName)
        {
            Connect(ref connection);

            // Команда Insert.
            string sql = null;

            if (tbName == "salary_grade")
            {
                sql = string.Format("CREATE TABLE {0}.{1} ("
                    + "Grade INT NULL,"
                    + "High_Salary FLOAT NULL,"
                    + "Low_Salary FLOAT NULL)"
                    + " ENGINE = InnoDB"
                    + " DEFAULT CHARSET = utf8mb4"
                    + " COLLATE = utf8mb4_0900_ai_ci;", dtName, tbName);
            } else if(tbName == "Employee")
            {
                sql = string.Format("CREATE TABLE {0}.{1} ("
                   + "Emp_Id INT auto_increment NOT NULL,"
                   + "emp_No varchar(100) NULL,"
                   + "Emp_Name varchar(100) NULL,"
                   + "Mng_Id INT NULL,"
                   + "CONSTRAINT Employee_pk PRIMARY KEY (Emp_Id))"
                   + " ENGINE = InnoDB"
                   + " DEFAULT CHARSET = utf8mb4"
                   + " COLLATE = utf8mb4_0900_ai_ci;", dtName, tbName);
            }

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;

            // Выполнить Command (использованная для  delete, insert, update).
            int rowCount = cmd.ExecuteNonQuery();

            Console.WriteLine("Row Count affected = " + rowCount);
        }

        private static void Read(MySqlConnection connection, string dtName, string tbName)
        {
            Connect(ref connection);

            if (tbName == "salary_grade")
            {
                QuerySalaryGrade(connection, dtName);
            } else if (tbName == "Employee")
            {
                QueryEmployee(connection, dtName);
            }
        }

        private static void WriteData(MySqlConnection connection, string dtName, string tbName)
        {
            Connect(ref connection);
            int rowCount = -1;

            string sql = null;
            if (tbName == "salary_grade")
            {
                // Команда Insert.
                sql = string.Format("Insert into {0}.{1} (Grade, High_Salary, Low_Salary) "
                    + " values (@grade, @highSalary, @lowSalary)", dtName, tbName);

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                // Создать объект Parameter.
                MySqlParameter gradeParam = new MySqlParameter("@grade", MySqlDbType.Int32);
                gradeParam.Value = 3;
                cmd.Parameters.Add(gradeParam);

                // Добавить параметр @highSalary.
                MySqlParameter highSalaryParam = cmd.Parameters.Add("@highSalary", MySqlDbType.Float);
                highSalaryParam.Value = 20000;

                // Добавить параметр @lowSalary.
                cmd.Parameters.Add("@lowSalary", MySqlDbType.Float).Value = 10000;

                // Выполнить Command (использованная для  delete, insert, update).
                rowCount = cmd.ExecuteNonQuery();
            } else if(tbName == "Employee")
            {
                // Команда Insert.
                sql = string.Format("Insert into {0}.{1} (Emp_No, Emp_Name, Mng_Id) "
                    + " values (@Emp_No, @Emp_Name, @Mng_Id)", dtName, tbName);

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                // Создать объект Parameter.
                MySqlParameter empNoParam = new MySqlParameter("@Emp_No", MySqlDbType.Text);
                empNoParam.Value = "E7369";
                cmd.Parameters.Add(empNoParam);

                // Добавить параметр @Emp_Name.
                MySqlParameter expNameParam = cmd.Parameters.Add("@Emp_Name", MySqlDbType.Text);
                expNameParam.Value = "SMITH";

                // Создать объект Parameter.
                MySqlParameter mngIdParam = new MySqlParameter("@Mng_Id", MySqlDbType.Int32);
                mngIdParam.Value = 7902;
                cmd.Parameters.Add(mngIdParam);

                // Выполнить Command (использованная для  delete, insert, update).
                rowCount = cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Row Count affected = " + rowCount);
        }

        private static void DropSchema(MySqlConnection connection, string dtName)
        {
            Connect(ref connection);

            // Команда Insert.
            string sql = string.Format("DROP SCHEMA IF EXISTS {0};", dtName);

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;

            // Выполнить Command (использованная для  delete, insert, update).
            int rowCount = cmd.ExecuteNonQuery();

            Console.WriteLine("Row Count affected = " + rowCount);
        }

        private static void Connect(ref MySqlConnection connection)
        {
            if(connection == null)
            {
                // Получить объект Connection подключенный к DB.
                connection = DBUtils.GetDBConnection();
            }

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        static void Main(string[] args)
        {
            MySqlConnection connection = null;

            try
            {
                string dtName = "simplehr";

                string tbNameSalaryGrade = "salary_grade";
                string tbNameEmployee = "Employee";

                // DropTable(connection);
                DropSchema(connection, dtName);
                CreateDatabase(connection, dtName);
                
                CreateTable(connection, dtName, tbNameSalaryGrade);
                WriteData(connection, dtName, tbNameSalaryGrade);
                Read(connection, dtName, tbNameSalaryGrade);

                CreateTable(connection, dtName, tbNameEmployee);
                WriteData(connection, dtName, tbNameEmployee);
                Read(connection, dtName, tbNameEmployee);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                    connection = null;
                }
            }

            Console.Read();
        }
        
        private static void QuerySalaryGrade(MySqlConnection conn, string dtName)
        {
            string sql = string.Format("Select Grade, High_Salary, Low_Salary from {0}.salary_grade", dtName);

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();

            // Сочетать Command с Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;


            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int gradeIndex = reader.GetOrdinal("Grade");
                        int grade = Convert.ToInt32(reader.GetValue(gradeIndex));

                        int highSalaryIndex = reader.GetOrdinal("High_Salary");
                        int high_salary = Convert.ToInt32(reader.GetValue(highSalaryIndex));

                        int lowSalaryIndex = reader.GetOrdinal("Low_Salary");// 2
                        int low_salary = Convert.ToInt32(reader.GetValue(lowSalaryIndex));

                        Console.WriteLine("--------------------");
                        Console.WriteLine("Grade:" + grade);
                        Console.WriteLine("high_salary:" + high_salary);
                        Console.WriteLine("low_salary:" + low_salary);
                    }
                }
            }
        }

        private static void QueryEmployee(MySqlConnection conn, string dtName)
        {
            string sql = string.Format("Select Emp_Id, Emp_No, Emp_Name, Mng_Id from {0}.Employee", dtName);

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();

            // Сочетать Command с Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;


            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        // Индекс (index) столбца Emp_ID в команде SQL.
                        int empIdIndex = reader.GetOrdinal("Emp_Id"); // 0


                        long empId = Convert.ToInt64(reader.GetValue(0));

                        // Столбец Emp_No имеет index = 1.
                        string empNo = reader.GetString(1);
                        int empNameIndex = reader.GetOrdinal("Emp_Name");// 2
                        string empName = reader.GetString(empNameIndex);

                        // Индекс (index) столбца Mng_Id в команде SQL.
                        int mngIdIndex = reader.GetOrdinal("Mng_Id");

                        long? mngId = null;

                        // Проверить значение данного столбца может являться null или нет.
                        if (!reader.IsDBNull(mngIdIndex))
                        {
                            mngId = Convert.ToInt64(reader.GetValue(mngIdIndex));
                        }
                        Console.WriteLine("--------------------");
                        Console.WriteLine("empIdIndex:" + empIdIndex);
                        Console.WriteLine("EmpId:" + empId);
                        Console.WriteLine("EmpNo:" + empNo);
                        Console.WriteLine("EmpName:" + empName);
                        Console.WriteLine("MngId:" + mngId);
                    }
                }
            }
        }
    }
}
