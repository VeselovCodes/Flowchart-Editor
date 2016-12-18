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
        void DeleteSquareBlock(int id);
        string GetName(); 
        OrientedGraph GetGraph();
        int GetBlock(int x, int y, int scroll);
        List<IBlock> GetListOfBlocks();
        void AddBlockOnEdge(IBlock block, Edge edge);
    }

    class Flowchart : IFlowchart
    {
        private OrientedGraph graph;
        private List<IBlock> blocks;
        private string name;
        int DIST_BETWEEN_BLOCKS = 125;
        int SCROLL_SCALE = 10;

        public Flowchart(string name)
        {
            this.name = name;
            graph = new OrientedGraph();
            blocks = new List<IBlock>();
        }

        public string GetName()
        {
            return name;
        }

        public List<IBlock> GetListOfBlocks()
        {
            return blocks;
        }

        public int GetBlock(int x, int y, int scroll)
        {
            int index = 0;
            for (; index < blocks.Count; ++index)
            {
                int shift = 25;

                if (blocks[index] is SquareBlock)
                {
                    shift = 50;
                    if (y < (shift*2 + DIST_BETWEEN_BLOCKS * index - SCROLL_SCALE * scroll + 25)*3/4+12  &&
                    y > (DIST_BETWEEN_BLOCKS * index - SCROLL_SCALE * scroll + 25)*3/4+12 &&
                    x < (shift + graph.GetNodeShift(index) * 100) * 3 / 4 + 250 - 172 &&
                    x > (-shift + graph.GetNodeShift(index) * 100) * 3 / 4 + 250 - 172)
                        return index;
                } else 
                {
                    if (y < (shift*2 + DIST_BETWEEN_BLOCKS * index - SCROLL_SCALE * scroll+50)*3/4+12 &&
                    y > (DIST_BETWEEN_BLOCKS * index - SCROLL_SCALE * scroll + 50) * 3 / 4 + 12 &&
                    x < (shift * 2 + graph.GetNodeShift(index) * 100) * 3 / 4 + 250 - 172 &&
                    x > (-shift * 2 + graph.GetNodeShift(index) * 100) * 3 / 4 + 250 - 172)
                        return index;
                }               
            }
            
            return -1;
        }

        public void AddBlockOnEdge(IBlock block, Edge edge)
        {
            blocks.Add(block);
            
        }

        public void AddBlock(IBlock block, Edge edge)
        {
            blocks.Add(block);
            graph.AddEdge(edge);
        }

        public void AddStrToBlock(IBlock block, string str)
        {
            block.AddStr(str);
        }

        public void DeleteSquareBlock(int id)
        {
            blocks.RemoveAt(id);
            for (int i = id; i < graph.CountNodes() - 1; i++)
            {
                graph.SetNodeShift(i, graph.GetNodeShift(i + 1));
                graph.SetNodeType(i, graph.GetNodeType(i + 1));
                for (int j = 0; j < graph.GetAdj()[i + 1].Count; j++)
                {
                    if (graph.GetAdj()[i + 1][j] >= id) graph.GetAdj()[i + 1][j]--;
                }
                graph.GetAdj()[i] = graph.GetAdj()[i + 1];
            }
            graph.SetNodesNumber(graph.CountNodes() - 1);
        }

        public OrientedGraph GetGraph()
        {
            return graph;
        }
    }
}
