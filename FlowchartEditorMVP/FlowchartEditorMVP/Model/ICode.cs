using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Model
{
    interface ICode
    {
        Flowchart ToFlowchart();
        void WriteFile(/*PATH*/);
    }

    class CppCode : ICode
    {
        private string[] code;

        public Flowchart ToFlowchart() 
        {
            return new Flowchart();
        }



        public void WriteFile(/*PATH*/) { }
    }
}
