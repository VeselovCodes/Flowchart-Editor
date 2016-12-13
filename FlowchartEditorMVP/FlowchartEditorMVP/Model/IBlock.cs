using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Model
{
    interface IBlock
    {
        void Draw();
    }

    class SquareBlock : IBlock
    {
        public void Draw() { }
    }

    class IfBlock : IBlock
    {
        public void Draw() { }
    }

    class ConnecterBlock : IBlock
    {
        public void Draw() { }
    }
}
