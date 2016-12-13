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
        void AddStrToBlock(IBlock block, string str);
        void DeleteSquareBlock(SquareBlock block);
        OrientedGraph getGraph();
    }

    class Flowchart : IFlowchart
    {
        private OrientedGraph graph;
        private List<IBlock> blocks;

        public Flowchart(int maxN)
        {
            graph = new OrientedGraph();
            blocks = new List<IBlock>();
        }

        public void AddBlock(IBlock block, Edge edge)
        {
            blocks.Add(block);
            graph.addEdge(edge);
        }

        public void AddStrToBlock(IBlock block, string str)
        {
            block.AddStr(str);
        }

        public void DeleteSquareBlock(SquareBlock block)
        {
        }

        public OrientedGraph getGraph()
        {
            return graph;
        }
    }
}
