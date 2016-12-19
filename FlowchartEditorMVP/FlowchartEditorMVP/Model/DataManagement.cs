using System;
using System.IO;
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
        private string login;

        private string owner;

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

        internal DataTable GetNamesAndLogins()
        {
            DataTable table = new DataTable();

            string queryString = @"SELECT owner, flowchart_name, reviewer, date FROM data";

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(queryString, connection);

            try
            {
                connection.Open();

                MySqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    table.Load(dr);
                }

                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }

            return table;
        }

        internal void SetLogin(string login)
        {
            this.login = login;
        }

        internal void AddToDB(IFlowchart flowchart)
        {            

            string dt = DateTime.Now.ToString("u");            

            string queryString = @"INSERT INTO data (owner, flowchart_name, flowchart_data, date) VALUES ('" + this.login + "', '" + flowchart.GetName() + "', '" + flowchart.GetCodeLikeStringList() + "','" + dt + "')";

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

        internal void MasterAddToDB(IFlowchart flowchart, string comment)
        {
            string dt = DateTime.Now.ToString("u");

            string queryString = @"INSERT INTO data (owner, flowchart_name, flowchart_data, date) VALUES ('" + this.login + "', '" + flowchart.GetName() + "', '" + flowchart.GetCodeLikeStringList() + "','" + dt + "')";

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

        internal IFlowchart LoadFlowchart(string flowchart_name)
        {        
            string queryString = @"SELECT flowchart_data FROM data WHERE flowchart_name = '" + flowchart_name + "' AND owner = '" + owner + "' AND reviewer = ''";

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(queryString, connection);

            try
            {
                string code = "";

                connection.Open();

                MySqlDataReader dr = com.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    code = dr.GetString("flowchart_data");
                }

                dr.Close();

                connection.Close();

                FlowchartFactory factory = new FlowchartCppFactory();

                return factory.CreateFlowchartFromDB(code, flowchart_name);
            }
            catch (Exception e)
            {
                connection.Close();
            }

            return new Flowchart(flowchart_name);
        }

        internal void ReviewerAddToDB(IFlowchart flowchart, string comment)
        {
            
        }

        internal string GetOwner()
        {
            return owner;
        }

        internal void SetOwner(string owner)
        {
            this.owner = owner;
        }

        internal string GetLogin()
        {
            return login;
        }
    }
}
