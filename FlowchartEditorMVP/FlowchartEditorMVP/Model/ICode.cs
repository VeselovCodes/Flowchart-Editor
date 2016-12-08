using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Model
{
    interface ICode
    {
        Flowchart ToFlowchart(string filePath);
        void WriteFile(/*PATH*/);
    }

    class CppCode : ICode
    {
        public Flowchart ToFlowchart(string filePath) 
        {
            Flowchart fc = new Flowchart(100);
            FileInfo f = new FileInfo(filePath);
            // открытие файла
            using (StreamReader sr = f.OpenText())
            {
                string line;
                int nodeNum = 0;
                int ifNodeNum = -1;
                int ifNodeNum2 = -1;
                int forNodeNum = -1;
                int tmp = 0;
                IBlock b = null;
                do
                {
                    line = sr.ReadLine();
                    if (line.Contains("int main("))
                    {
                        b = new StartBlock();
                        //fc.getGraph().addNode();
                        //fc.getGraph().addNode();
                        fc.getGraph().setNodeType(nodeNum, 3);
                        nodeNum = 1;
                        Edge e = new Edge();
                        e.outNode = new Node(0);
                        e.inNode = new Node(1);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, line);
                    }
                    else
                    if (line.Contains("if ("))
                    {
                        ifNodeNum = nodeNum;
                        b = new IfBlock();
                        //fc.getGraph().addNode();
                        fc.getGraph().setNodeType(nodeNum, 2);
                        nodeNum++;
                        Edge e = new Edge();
                        e.outNode = new Node(nodeNum-1);
                        e.inNode = new Node(nodeNum);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, line);
                    }
                    else
                    if (line.Contains("else"))
                    {
                        ifNodeNum2 = nodeNum;
                        nodeNum++;
                        Edge e = new Edge();
                        e.outNode = new Node(ifNodeNum);
                        e.inNode = new Node(nodeNum);
                    }
                    else
                    if (line.Contains("//endofif"))
                    {
                        Edge e = new Edge();
                        if (ifNodeNum2 == -1)
                        {
                            e.outNode = new Node(ifNodeNum);
                            e.inNode = new Node(nodeNum);
                            fc.getGraph().addEdge(e);
                        }
                        else
                        {
                            fc.getGraph().getAdj()[nodeNum - 1][fc.getGraph().getAdj()[nodeNum - 1].Count - 1] = ifNodeNum2;
                        }
                    }
                    else
                    if (line.Contains("for (") || (line.Contains("while (") && !line.Contains("}")))
                    {
                        forNodeNum = nodeNum;
                        b = new IfBlock();
                        //fc.getGraph().addNode();
                        fc.getGraph().setNodeType(nodeNum, 2);
                        nodeNum++;
                        Edge e = new Edge();
                        e.outNode = new Node(nodeNum - 1);
                        e.inNode = new Node(nodeNum);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, line);
                    }
                    else
                    if (line.Contains("//endoffor"))
                    {
                        fc.getGraph().getAdj()[nodeNum - 1][fc.getGraph().getAdj()[nodeNum - 1].Count-1] = forNodeNum;
                        Edge e = new Edge();
                        e.outNode = new Node(forNodeNum);
                        e.inNode = new Node(nodeNum);
                        fc.getGraph().addEdge(e);
                    }
                    else
                    if (line.Contains("do {"))
                    {
                        forNodeNum = nodeNum;
                        b = new IfBlock();
                    }
                    else
                    if (line.Contains("} while ("))
                    {
                        b = new IfBlock();
                        //fc.getGraph().addNode();
                        fc.getGraph().setNodeType(nodeNum, 2);
                        nodeNum++;
                        Edge e = new Edge();
                        e.outNode = new Node(nodeNum - 1);
                        e.inNode = new Node(nodeNum);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, line);

                        e.outNode = new Node(nodeNum - 1);
                        e.inNode = new Node(forNodeNum);
                        fc.getGraph().addEdge(e);
                    }
                    else
                    if (line.Contains("return "))
                    {
                        b = new StartBlock();
                        //fc.getGraph().addNode();
                        fc.getGraph().setNodeType(nodeNum, 3);
                        Edge e = new Edge();
                        e.outNode = new Node(0);
                        e.inNode = new Node(0);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, line);
                    }
                    else
                    if (line.Contains("//endoffunc"))
                    {
                        b = null;
                        tmp = 1;
                    }
                    else
                    if (line != "" && tmp == 1)
                    {
                        tmp = 0;
                        b = new StartBlock();
                        //fc.getGraph().addNode();
                        //fc.getGraph().addNode();
                        fc.getGraph().setNodeType(nodeNum+1, 3);
                        nodeNum += 2;
                        Edge e = new Edge();
                        e.outNode = new Node(nodeNum-1);
                        e.inNode = new Node(nodeNum);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, line);
                    }
                    else
                    {
                        if (b != null)
                            if (b.isSquare())
                            {
                                fc.AddStrToBlock(b, line);
                            }
                            else
                            {
                                b = new SquareBlock();
                                //fc.getGraph().addNode();
                                fc.getGraph().setNodeType(nodeNum, 1);
                                nodeNum++;
                                Edge e = new Edge();
                                e.outNode = new Node(nodeNum - 1);
                                e.inNode = new Node(nodeNum);
                                fc.AddBlock(b, e);
                                fc.AddStrToBlock(b, line);
                            }
                    }

                } while (!sr.EndOfStream);
            }
            return fc;
        }

        public void WriteFile(/*PATH*/) { }


    }
}
