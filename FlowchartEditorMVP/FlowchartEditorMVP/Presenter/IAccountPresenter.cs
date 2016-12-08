using FlowchartEditorMVP.Model;
using FlowchartEditorMVP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{
    interface IAccountPresenter : IPresenter
    {
        bool Login(string text1, string text2);
        bool Register(string login, string password);
    }

    class AccountPresenter : IAccountPresenter
    {
        private IView view;
        private DataManagement data;
        
        public AccountPresenter(IView view)
        {
            this.view = view;
            data = new DataManagement();
        }

        public bool Login(string login, string password)
        {
            if (data.IsUserExist(login, password))
            {              
                return true;
            }
            data.SetLogin(login);
            return false;            
        }

        public bool Register(string login, string password)
        {
            if (data.IsLoginExist(login, password))
                return false;
            data.CreateNewUser(login, password);
            return true;
        }
        public void Run() { }
    }
}
