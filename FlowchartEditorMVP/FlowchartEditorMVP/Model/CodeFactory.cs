using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Model
{
    interface CodeFactory
    {
        ICode CreateCode(Flowchart flowchart);
    }

    class CppFactory : CodeFactory
    {
        public ICode CreateCode(Flowchart flowchart)
        {
            return new CppCode();
        }
    }
}
