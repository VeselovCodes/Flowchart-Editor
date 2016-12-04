using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Model
{
    class OrientedGraph
    {
        private List<int>[] adj; // Список смежности
        private int nodesNumber; // Число вершин графа
        private int edgesNumber; // Число ребер графа

        public OrientedGraph(int nodesNumber_)
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

        public void AddEdge(Node outNode, Node inNode)
        {
            if (outNode.nodeNum != inNode.nodeNum)
            {
                if (adj[outNode.nodeNum].IndexOf(inNode.nodeNum) == -1 || adj[inNode.nodeNum].IndexOf(outNode.nodeNum) == -1)
                {
                    adj[outNode.nodeNum].Add(inNode.nodeNum);
                    adj[inNode.nodeNum].Add(outNode.nodeNum);
                    edgesNumber++;
                }
            }
        }

        public void AddNode()
        {
            Node node = new Node();
            node.nodeNum = nodesNumber;
            adj[node.nodeNum] = new List<int>();
        }
    }

    class Node
    {
        public int nodeNum; // Номер узла графа
    }

    class Edge
    {
        Node outNode; // Начальный узел 
        Node inNode; // Конечный узел
    }
}
