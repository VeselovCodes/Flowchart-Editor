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
            graph = new OrientedGraph(100);
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

<<<<<<< HEAD
        public OrientedGraph getGraph()
        {
            return graph;
        }
=======
        private List<int>[] adj; // Список смежности
        private int nodesNumber; // Число вершин графа
        private int edgesNumber; // Число ребер графа

        public Flowchart()
        { }

        public Flowchart(int nodesNumber_)
        {
            edgesNumber = 0;
            nodesNumber = nodesNumber_;

            Node[] nodes = new Node[nodesNumber]; // Массив узлов

            adj = new List<int>[nodesNumber];
            for (int i = 0; i < nodesNumber; i++)
            {
                adj[i] = new List<int>();
                nodes[i].nodeNum = i;
            }
        }

        private void addEdge(Edge edge)
        {
            if (edge.outNode.nodeNum != edge.inNode.nodeNum)
            {
                if (adj[edge.outNode.nodeNum].IndexOf(edge.inNode.nodeNum) == -1 || adj[edge.inNode.nodeNum].IndexOf(edge.outNode.nodeNum) == -1)
                {
                    adj[edge.outNode.nodeNum].Add(edge.inNode.nodeNum);
                    adj[edge.inNode.nodeNum].Add(edge.outNode.nodeNum);
                    edgesNumber++;
                }
            }
        }

        public void addNode()
        {
            Node node = new Node();
            node.nodeNum = nodesNumber;
            adj[node.nodeNum] = new List<int>();
        }

        public int countNodes()
        {
            return nodesNumber;
        }
    }

    class Node
    {
        public int nodeNum; // Номер узла графа
    }

    class Edge
    {
        public Node outNode; // Начальный узел 
        public Node inNode; // Конечный узел
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
    }

}

