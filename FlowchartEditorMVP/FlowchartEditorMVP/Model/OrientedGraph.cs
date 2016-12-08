using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace FlowchartEditorMVP.Model

    class OrientedGraph
    {
        private List<int>[] adj; // Список смежности
        private int nodesNumber; // Число вершин графа
        private int edgesNumber; // Число ребер графа
<<<<<<< HEAD
        private int[] nodeTypes; // тип блока: 0 пустой, 1 квадрат, 2 if, 3 начало/конец 
=======
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a

        public OrientedGraph(int nodesNumber_)
        {
            edgesNumber = 0;
            nodesNumber = nodesNumber_;

<<<<<<< HEAD
            //Node[] nodes = new Node[nodesNumber]; // Массив узлов
            nodeTypes = new int[nodesNumber];
=======
            Node[] nodes = new Node[nodesNumber]; // Массив узлов
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a

            adj = new List<int>[nodesNumber];
            for (int i = 0; i < nodesNumber; i++)
            {
                adj[i] = new List<int>();
<<<<<<< HEAD
                //nodes[i].nodeNum = i;
=======
                nodes[i].nodeNum = i;
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
            }
        }

        public void addEdge(Edge edge)
        {
            if (edge.outNode.nodeNum != edge.inNode.nodeNum)
            {
<<<<<<< HEAD
                //if (adj[edge.outNode.nodeNum].IndexOf(edge.inNode.nodeNum) == -1 || adj[edge.inNode.nodeNum].IndexOf(edge.outNode.nodeNum) == -1)
                //{
                    adj[edge.outNode.nodeNum].Add(edge.inNode.nodeNum);
                    //adj[edge.inNode.nodeNum].Add(edge.outNode.nodeNum);
                    edgesNumber++;
                //}
            }
        }

        public List<int>[] getAdj()
        {
            return adj;
        }

        public void setNodeType(int i, int type)
        {
            nodeTypes[i] = type;
        }

        public void addNode()
        {
            Node node = new Node(nodesNumber);
            adj[node.nodeNum] = new List<int>();
        }

        public int countNodes()
        {
=======
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
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
            return nodesNumber;
        }
    }

    class Node
    {
        public int nodeNum; // Номер узла графа
<<<<<<< HEAD
        public Node(int n)
        {
            nodeNum = n;
        }
=======
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
    }

    class Edge
    {
        public Node outNode; // Начальный узел 
        public Node inNode; // Конечный узел
    }

