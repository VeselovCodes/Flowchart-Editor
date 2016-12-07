using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{
    interface IRegisterPresenter : IPresenter
    {
        void Register(string text1, string text2);
    }

    class RegisterPresenter : IRegisterPresenter
    {
        public void Register(string text1, string text2) { }
        public void Run() { }
    }
        
}
