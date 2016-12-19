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
        void Login(string text1, string text2);
        void Register(string login, string password, string repeatedPassword);
    }

    class AccountPresenter : IAccountPresenter
    {
        private IAccountView view;
        private DataManagement data;
        
        public AccountPresenter(IAccountView view)
        {
            this.view = view;
            data = new DataManagement();
        }

        public void Login(string login, string password)
        {
            if (login == ""
                || password == "")
            {
                throw new Exception("Enter login and password");
            }
            if (data.IsUserExist(login, password))
            {
                data.SetLogin(login);
                
                ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView(data);
                ((EnterView)view).Hide();
                chooseFlowchartView.Show();                
            }
            else
            {
                throw new Exception("Incorrect login or password");
            } 
            
                      
        }

        public void Register(string login,
            string password,
            string repeatedPassword)
        {
            if (password != repeatedPassword
                || password == "")
            {
                throw new Exception("Incorrect password setting");                
            }
            if (!data.IsLoginExist(login))
            {
                data.CreateNewUser(login, password);
                EnterView enterView = new EnterView();
                ((RegisterView)view).Hide();
                enterView.Show();
            }
            else
            {
                throw new Exception("User with entered name exists.");
            }
        }
    }
}
