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
        int[] GetEdge(int x, int y, int scroll);
        List<IBlock> GetListOfBlocks();

        string GetCodeLikeStringList();

        void AddBlockOnEdge(int[] edge);

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

        public int[] GetEdge(int x, int y, int scroll)
        {
            int[] edge = new int[2];
            int index = ((y - 12) * 4 / 3 + SCROLL_SCALE * scroll - 50) / DIST_BETWEEN_BLOCKS;
            edge[0] = index;

            if (graph.GetAdj()[index].Count == 0)
            {
                edge[0] = -1;
                return edge;
            }
            else
            if (graph.GetAdj()[index].Count == 1)
            {
                edge[1] = graph.GetAdj()[index][0];
                return edge;
            }
            else
            {
                if (graph.GetNodeType(index) != 5)
                    if (x >= 250)
                    {
                        edge[1] = graph.GetAdj()[index][0];
                    }
                    else
                    {
                        edge[1] = graph.GetAdj()[index][1];
                    }
                else
                {
                    if (x >= 250 + 50*3/4)
                    {
                        edge[1] = graph.GetAdj()[index][1];
                    }
                    else
                    {
                        edge[1] = graph.GetAdj()[index][0];
                    }
                }
            }

            return edge;
        }

        public void AddBlockOnEdge(int[] edge)
        {
            IBlock b = new SquareBlock();
            blocks.Insert(edge[1], b);

            for (int i = graph.CountNodes()+1; i > 0; i--)
            {
                if (i >= edge[1])
                {
                    graph.SetNodeShift(i, graph.GetNodeShift(i - 1));
                    graph.setNodeType(i, graph.GetNodeType(i - 1));
                    graph.GetAdj()[i] = new List<int>();
                    for (int j = 0; j < graph.GetAdj()[i-1].Count; j++)
                    {
                        graph.GetAdj()[i].Add(graph.GetAdj()[i - 1][j]);
                    }
                }
                for (int j = 0; j < graph.GetAdj()[i].Count; j++)
                {
                    if (graph.GetAdj()[i][j] >= edge[1]) graph.GetAdj()[i][j]++;
                }
            }
            graph.SetNodeShift(edge[1], graph.GetNodeShift(edge[1]+1));
            graph.setNodeType(edge[1], 1);
            graph.SetNodesNumber(graph.CountNodes() + 1);
            if (graph.GetAdj()[edge[0]][0] == edge[1] + 1 || graph.GetAdj()[edge[0]].Count == 1) 
                graph.GetAdj()[edge[0]][0] = edge[1]; 
            else
                graph.GetAdj()[edge[0]][1] = edge[1];
            graph.GetAdj()[edge[1]] = new List<int>();
            graph.GetAdj()[edge[1]].Add(edge[1] + 1);
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

            for (int i = 0; i < id; i++)
            {
                for (int j = 0; j < graph.GetAdj()[i].Count; j++)
                {
                    if (graph.GetAdj()[i][j] > id) graph.GetAdj()[i][j]--;
                }
            }
            for (int i = id; i < graph.CountNodes() - 1; i++)
            {
                graph.SetNodeShift(i, graph.GetNodeShift(i + 1));
                graph.setNodeType(i, graph.GetNodeType(i + 1));
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

        public string GetCodeLikeStringList()
        {
            ICode code = new CppCode(this);
            return code.GetCodeLikeString();
        }
    }
}
