using FlowchartEditorMVP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{
    interface IEnterPresenter : IPresenter
    {
        void Login(string text1, string text2);
        string loginType(string text1, string text2);
    }

    class EnterPresenter : IEnterPresenter
    {
        private IView enterView;

        public EnterPresenter(IView _enterView)
        {
            enterView = _enterView;
        }

        public void Login(string text1, string text2) { }

        public string loginType(string text1, string text2) { return "reviewer"; }

        public void Run() { }
    }
}
