using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{
    interface INewFlowchartPresenter : IPresenter
    {
        string GetLogin();
    }

    class NewFlowchartPresenter : INewFlowchartPresenter
    {
        private string login;
        public string GetLogin()
        {
            return login;
        }
        public void Run() { }
    }    
}
