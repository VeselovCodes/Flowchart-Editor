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
        public Flowchart ToFlowchart() 
        {
            return new Flowchart();
        }

        public void WriteFile(/*PATH*/) { }
    }
}
