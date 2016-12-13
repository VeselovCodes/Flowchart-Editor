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
        internal bool IsUserExist(string login, string password)
        {
            return true;
        }

        internal bool IsLoginExist(string login)
        {
            return false;
        }

        internal void CreateNewUser(string login, string password)
        {
            //throw new NotImplementedException();
        }

        internal List<Tuple<string, string>> GetNamesAndLogins()
        {
            return new List<Tuple<string, string>>();
        }

        internal void SetLogin(string login)
        {
            //throw new NotImplementedException();
        }
       

        internal void AddToDB(IFlowchart flowchart)
        {
            //throw new NotImplementedException();
        }

        internal IFlowchart LoadFlowchart(string reviewer, string name)
        {
            return new Flowchart(100);
        }

        internal string GetLogin()
        {
            return "master";
        }
    }
}
