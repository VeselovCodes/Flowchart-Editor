using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Model
{
    interface CodeFactory
    {
        ICode CreateCode(IFlowchart flowchart);
    }

    class CppFactory : CodeFactory
    {
        public ICode CreateCode(IFlowchart flowchart)
        {
            return new CppCode();
        }
    }
}
