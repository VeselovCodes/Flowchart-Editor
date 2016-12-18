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
        private int[] nodeTypes; // тип блока: 0 пустой, 1 квадрат, 2 if, 3 начало/конец 
        private int[] nodeShift; // сдвиг блока, когда он внутри ifа

        public OrientedGraph()
        {
            int MAX_NODES_NUMBER = 100;
            edgesNumber = 0;
            nodesNumber = 0;

            //Node[] nodes = new Node[nodesNumber]; // Массив узлов
            nodeTypes = new int[MAX_NODES_NUMBER];
            nodeShift = new int[MAX_NODES_NUMBER];

            adj = new List<int>[MAX_NODES_NUMBER];
            for (int i = 0; i < MAX_NODES_NUMBER; i++)
            {
                nodeShift[i] = 0;
                adj[i] = new List<int>();
                //nodes[i].nodeNum = i;
            }
        }

        public void RemoveAdge(Edge edge)
        {
            
        }

        public void AddEdge(Edge edge)
        {
            if (edge.outNode.nodeNum != edge.inNode.nodeNum)
            {
                //if (adj[edge.outNode.nodeNum].IndexOf(edge.inNode.nodeNum) == -1 || adj[edge.inNode.nodeNum].IndexOf(edge.outNode.nodeNum) == -1)
                //{
                adj[edge.outNode.nodeNum].Add(edge.inNode.nodeNum);
                //adj[edge.inNode.nodeNum].Add(edge.outNode.nodeNum);
                edgesNumber++;
                //}
            }
        }

        public List<int>[] GetAdj()
        {
            return adj;
        }

        public void SetNodeType(int i, int type)
        {
            nodeTypes[i] = type;
        }

        public void SetNodeShift(int i, int shift)
        {
            nodeShift[i] = shift;
        }

        public int GetNodeType(int i)
        {
            return nodeTypes[i];
        }

        public int GetNodeShift(int i)
        {
            return nodeShift[i];
        }

        /*public void addNode()
        {
            Node node = new Node(nodesNumber);
            adj[node.nodeNum] = new List<int>();
        }*/

        public void SetNodesNumber(int n)
        {
            nodesNumber = n;
        }

        public int CountNodes()
        {
            return nodesNumber;
        }
    }

    class Node
    {
        public int nodeNum; // Номер узла графа
        public Node(int n)
        {
            nodeNum = n;
        }
    }

    class Edge
    {
        public Node outNode; // Начальный узел 
        public Node inNode; // Конечный узел
    }
}