using FlowchartEditorMVP.Model;
using FlowchartEditorMVP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{
    interface IChooseFlowchartPresenter : IPresenter
    {
        DataTable tableFilling();
        string GetLogin();
        void openClick();
        void ToCreateNew();
        void SelectFlowchart(string owner, string name);
    }

    class ChooseFlowchartPresenter : IChooseFlowchartPresenter
    {        
        public void Run() { }
                
        private DataManagement data;
        private ChooseFlowchartView view;

        private string owner;
        private string flowchartName;

        public DataTable tableFilling()
        {
            DataTable datatable = new DataTable();

            MySqlConnectionStringBuilder mysqlCSB;

            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "localhost";// или 127.0.0.1
            mysqlCSB.Database = "flowchart";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";

            string queryString = @"SELECT * FROM users WHERE 1";

            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;

                MySqlCommand com = new MySqlCommand(queryString, con);

                try
                {
                    con.Open();

                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)// есть записи?
                        {
                            datatable.Load(dr);// Заполняем объект DataTable
                        }
                    }
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                }
            }
            return datatable;
        }

        public ChooseFlowchartPresenter(DataManagement data, ChooseFlowchartView view)
        {
            this.view = view;
            this.data = data;
            List<Tuple<string, string>> table = data.GetNamesAndLogins();
            view.SetFlowchartsTable(table);
        }

        public void openClick()
        {
            if (data.GetLogin().Equals(owner))
            {
                data.LoadFlowchart(owner, flowchartName);
                view.Hide();
                MasterView mView = new MasterView(data);
            }
            else
            {
                ReviewerView rView = new ReviewerView(data);
            }
        }

        public void ToCreateNew()
        {
            NewFlowchartView newFlowchartView = new NewFlowchartView(data);
            view.Hide();
            newFlowchartView.Show();
        }

        public string GetLogin()
        {
            return data.GetLogin();
        }

        public void SelectFlowchart(string owner, string name)
        {
            this.owner = owner;
            this.flowchartName = name; 
        }
    }
}
