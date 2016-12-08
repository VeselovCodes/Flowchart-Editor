using FlowchartEditorMVP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{
    interface IChooseFlowchartPresenter : IPresenter
    {
        List<Tuple<string, string>> GetNamesAndLogins();
        string GetLogin();
    }

    class ChooseFlowchartPresenter : IChooseFlowchartPresenter
    {        
        public void Run() { }

        private string login;
        private DataManagement data;

        public ChooseFlowchartPresenter(string login)
        {
            this.login = login;
        }

        public string GetLogin()
        {
            return login;
        }

        public List<Tuple<string, string>> GetNamesAndLogins()
        {
            return data.GetNamesAndLogins();
        }
    }
}
