<<<<<<< HEAD
﻿using FlowchartEditorMVP.Model;
using System;
=======
﻿using System;
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{
    interface IChooseFlowchartPresenter : IPresenter
    {
<<<<<<< HEAD
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
=======
    }

    class ChooseFlowchartPresenter : IChooseFlowchartPresenter
    {
        public void Run() { }
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
    }
}
