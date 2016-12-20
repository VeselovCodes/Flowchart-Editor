using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace FlowchartEditorMVP.Model
{
    class DataManagement
    {
        private string login;

        private string owner;

        private string reviewer;

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

        internal string GetComment(string owner, string reviewer, string name)
        {
            string queryString = @"SELECT comment FROM data WHERE flowchart_name = '" + name + "' AND owner = '" + owner + "' AND reviewer = '" + reviewer + "'";

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(queryString, connection);

            try
            {
                string comment = "";

                connection.Open();

                MySqlDataReader dr = com.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    comment = dr.GetString("comment");
                }

                dr.Close();

                connection.Close();

                return comment;
            }
            catch (Exception e)
            {
                connection.Close();
            }
            return "";
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

        internal void MasterAddToDB(IFlowchart flowchart, string comment)
        {
            string dt = DateTime.Now.ToString("u");

            string querySelect = @"SELECT flowchart_name FROM data WHERE flowchart_name = '" + flowchart.GetName() + "' AND owner = '" + this.login + "'";

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(querySelect, connection);
            
            try {

                connection.Open();

                MySqlDataReader dr = com.ExecuteReader();

                string query = "";

                if (dr.HasRows)
                {
                    query = @"UPDATE data SET owner = '" + this.login + "', flowchart_name = '" + flowchart.GetName() + "', flowchart_data = '" + flowchart.GetCodeLikeStringList() + "', date = '" + dt + "', comment = '" + comment + "' WHERE owner = '" + this.login + "' AND flowchart_name = '" + flowchart.GetName() + "'";
                    connection.Close();
                }
                else
                {
                    query = @"INSERT INTO data (owner, flowchart_name, flowchart_data, date, comment) VALUES ('" + this.login + "', '" + flowchart.GetName() + "', '" + flowchart.GetCodeLikeStringList() + "','" + dt + "', '" + comment + "')";
                    connection.Close();
                }

                com = new MySqlCommand(query, connection);

                connection.Open();

                dr = com.ExecuteReader();

                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }

        internal void MasterApply(IFlowchart flowchart)
        {
            string dt = DateTime.Now.ToString("u");

            string query = @"UPDATE data SET flowchart_data = '" + flowchart.GetCodeLikeStringList() + "', date = '" + dt + "', comment = '' WHERE owner = '" + login + "' AND flowchart_name = '" + flowchart.GetName() + "' AND reviewer = ''";

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(query, connection);

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

        internal void Delete(IFlowchart flowchart)
        {
            string dt = DateTime.Now.ToString("u");

            string query = @"DELETE FROM data WHERE owner = '" + login + "' AND reviewer = '" + reviewer + "' AND flowchart_name = '" + flowchart.GetName() + "'";

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(query, connection);

            
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
            string queryString = "";
            if (reviewer == login)
                queryString = @"SELECT flowchart_data FROM data WHERE flowchart_name = '" + flowchart_name + "' AND owner = '" + owner + "' AND reviewer = ''";
            else
                queryString = @"SELECT flowchart_data FROM data WHERE flowchart_name = '" + flowchart_name + "' AND owner = '" + owner + "' AND reviewer = '" + reviewer + "'";
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
            string dt = DateTime.Now.ToString("u");

            string querySelect = @"SELECT flowchart_name FROM data WHERE flowchart_name = '" + flowchart.GetName() + "' AND owner = '" + this.owner + "' AND reviewer = ''";

            MySqlConnection connection = initializeDatabaseConnection("localhost", "flowchart", "root", "");

            MySqlCommand com = new MySqlCommand(querySelect, connection);

            try
            {

                connection.Open();

                MySqlDataReader dr = com.ExecuteReader();

                string query = "";

                if (dr.HasRows)
                {
                    query = @"INSERT INTO data (owner, flowchart_name, flowchart_data, date, reviewer, comment) VALUES ('" + this.owner + "', '" + flowchart.GetName() + "', '" + flowchart.GetCodeLikeStringList() + "','" + dt + "', '" + this.login + "', '" + comment + "')";
                    connection.Close();
                }

                com = new MySqlCommand(query, connection);

                connection.Open();

                dr = com.ExecuteReader();

                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }

        internal string GetOwner()
        {
            return owner;
        }

        internal void SetOwner(string owner)
        {
            this.owner = owner;
        }

        internal void SetReviewer(string reviewer)
        {
            this.reviewer = reviewer;
        }

        internal string GetLogin()
        {
            return login;
        }
    }
}
