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
        IBlock GetBlock(int x, int y, int scroll);
        List<IBlock> GetListOfBlocks();
    }

    class Flowchart : IFlowchart
    {
        private OrientedGraph graph;
        private List<IBlock> blocks;
        int DIST_BETWEEN_BLOCKS = 125;
        int SCROLL_SCALE = 10;

        public Flowchart(int maxN)
        {
            graph = new OrientedGraph();
            blocks = new List<IBlock>();
        }

        public List<IBlock> GetListOfBlocks()
        {
            return blocks;
        }

        public IBlock GetBlock(int x, int y, int scroll)
        {
            int index = 0;
            for (; index < blocks.Count; ++index)
            {
                int shift = 25;

                if (blocks[index] is SquareBlock)
                {
                    shift = 50;
                    if (y < shift*2 + DIST_BETWEEN_BLOCKS * index - SCROLL_SCALE * scroll - 25 &&
                    y > DIST_BETWEEN_BLOCKS * index - SCROLL_SCALE * scroll)
                        return blocks[index];
                } else 
                {
                    if (y < shift*2 + DIST_BETWEEN_BLOCKS * index - SCROLL_SCALE * scroll &&
                    y > DIST_BETWEEN_BLOCKS * index - SCROLL_SCALE * scroll)
                        return blocks[index];
                }               
            }
            
            return blocks[0];
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
