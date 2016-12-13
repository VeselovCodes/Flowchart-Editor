using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Model
{
    interface IFlowchart
    {
        void AddBlock(IBlock block, Edge edge);
        void AddStrToBlock(SquareBlock block, string str);
        void DeleteSquareBlock(SquareBlock block);

    }

    class Flowchart : IFlowchart
    {
        public void AddBlock(IBlock block, Edge edge)
        {
        }

        public void AddStrToBlock(SquareBlock block, string str)
        {
        }

        public void DeleteSquareBlock(SquareBlock block)
        {
        }
    }
}
