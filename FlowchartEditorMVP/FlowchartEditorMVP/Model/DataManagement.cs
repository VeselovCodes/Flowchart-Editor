using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace FlowchartEditorMVP.Model
{
    class DataManagement
    {
        private MySqlConnection initializeDatabaseConnection(string server_name, string database_name, string user_id, string database_password)
        {
            MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();

            mysqlCSB.Server = server_name;

            mysqlCSB.Database = database_name;

            mysqlCSB.UserID = user_id;

            mysqlCSB.Password = database_password;

            MySqlConnection con = new MySqlConnection();

            con.ConnectionString = mysqlCSB.ConnectionString;

            return con;
        }

        internal bool IsUserExist(string login, string password)
        {

            string queryString = @"SELECT * FROM users WHERE login LIKE '" + login + "' AND password LIKE '" + password + "'";

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(queryString, connection);

            try
            {
                connection.Open();

                MySqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)// есть записи?
                {
                    connection.Close();

                    return true;
                }

                connection.Close();

                return false;
            }
            catch (Exception e)
            {
                connection.Close();

                return false;
            }
        }

        internal bool IsLoginExist(string login)
        {

            string queryString = @"SELECT * FROM users WHERE login LIKE '" + login + "'";

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(queryString, connection);

            try
            {
                connection.Open();

                MySqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)// есть записи?
                {
                    connection.Close();

                    return true;
                }

                connection.Close();

                return false;
            }
            catch (Exception e)
            {
                connection.Close();

                return false;
            }
        }

        internal void CreateNewUser(string login, string password)
        {

            string queryString = @"INSERT INTO users (login, password) VALUES ('" + login + "', '" + password + "')";

            // Нужно написать запрос создания строки во второй таблице для данного user'а

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(queryString, connection);

            try
            {
                connection.Open();

                MySqlDataReader dr = com.ExecuteReader();

                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }

        internal List<Tuple<string, string>> GetNamesAndLogins()
        {
            return new List<Tuple<string, string>>();
        }

        internal void SetLogin(string login)
        {
            string queryString = @"INSERT INTO users (login) VALUES ('" + login + "')";

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(queryString, connection);

            try
            {
                connection.Open();

                MySqlDataReader dr = com.ExecuteReader();

                connection.Close();
            }
            catch
            {
                connection.Clone();
            }
        }


        internal void AddToDB(IFlowchart flowchart)
        {

            string queryString = @"INSERT INTO data (login, flowcharts_data, comments) VALUES ('', '', '')";

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(queryString, connection);

            try
            {
                connection.Open();

                MySqlDataReader dr = com.ExecuteReader();

                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }

        internal IFlowchart LoadFlowchart(string reviewer, string name)
        {
            string queryString = @"SELECT * FROM data WHERE flowchart_name = '" + name + "' AND reviewer_name = '" + reviewer + "'";

            MySqlConnection connection = new MySqlConnection();

            MySqlCommand com = new MySqlCommand(queryString, connection);

            try
            {
                connection.Open();



                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }

            return new Flowchart(100);
        }

        internal string GetLogin()
        {
            string queryString = @"SELECT login FROM users WHERE ...";

            MySqlConnection connection = new MySqlConnection();

            MySqlCommand com = new MySqlCommand(queryString, connection);

            try
            {
                connection.Open();



                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }

            return "master";
        }
    }
}
