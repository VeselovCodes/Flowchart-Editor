using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Model
{
    interface FlowchartFactory
    {
        IFlowchart CreateFlowchart(string path, string name);
        IFlowchart CreateFlowchartFromDB(string code, string name);
    }

    class FlowchartCppFactory : FlowchartFactory
    {
        public IFlowchart CreateFlowchart(string filePath, string name)
        {
            Flowchart fc = new Flowchart(name);
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
                    //fc.AddStringToCode(line);
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
                        line = sr.ReadLine();
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
                        e.outNode = new Node(nodeNum - 1);
                        e.inNode = new Node(nodeNum);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, line);
                        line = sr.ReadLine();
                    }
                    else
                    if (line.Contains("} else {")) //ifNodeNum2: -1 нет else; -2 в ифе есть ретёрн, нет else; -3 в ифе ретёрн, есть else; >=0 нет ретёрна, есть else
                    {
                        b = new IfBlock();
                        if (ifNodeNum2 == -1) ifNodeNum2 = nodeNum;
                        if (ifNodeNum2 == -2) ifNodeNum2 = -3;
                        if (ifNodeNum2 == -3) nodeNum++;
                        Edge e = new Edge();
                        e.outNode = new Node(ifNodeNum);
                        e.inNode = new Node(nodeNum);
                        fc.getGraph().addEdge(e);
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
                        if (ifNodeNum2 == -2)
                        {
                            nodeNum++;
                            e = new Edge();
                            e.outNode = new Node(ifNodeNum);
                            e.inNode = new Node(nodeNum);
                            fc.getGraph().addEdge(e);
                        }
                        else
                        if (ifNodeNum2 != -3)
                        {
                            fc.getGraph().getAdj()[ifNodeNum2 - 1][fc.getGraph().getAdj()[ifNodeNum2 - 1].Count - 1] = nodeNum;
                        }
                        ifNodeNum = -1;
                        ifNodeNum2 = -1;
                    }
                    else
                    if (line.Contains("for (") || (line.Contains("while (") && !line.Contains("}")))
                    {
                        forNodeNum = nodeNum;
                        b = new IfBlock();
                        //fc.getGraph().addNode();
                        fc.getGraph().setNodeType(nodeNum, 5);
                        nodeNum++;
                        Edge e = new Edge();
                        e.outNode = new Node(nodeNum - 1);
                        e.inNode = new Node(nodeNum);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, line);
                        line = sr.ReadLine();
                    }
                    else
                    if (line.Contains("//endoffor"))
                    {
                        fc.getGraph().getAdj()[nodeNum - 1][fc.getGraph().getAdj()[nodeNum - 1].Count - 1] = forNodeNum;
                        Edge e = new Edge();
                        e.outNode = new Node(forNodeNum);
                        e.inNode = new Node(nodeNum);
                        fc.getGraph().addEdge(e);
                        
                        b = new IfBlock();
                        forNodeNum = -1;
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
                        fc.getGraph().setNodeType(nodeNum, 5);
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
                        if (ifNodeNum != -1) fc.getGraph().setNodeShift(nodeNum, 1);
                        if (ifNodeNum2 != -1) fc.getGraph().setNodeShift(nodeNum, -1);
                        b = new StartBlock();
                        //fc.getGraph().addNode();
                        fc.getGraph().setNodeType(nodeNum, 3);
                        Edge e = new Edge();
                        e.outNode = new Node(0);
                        e.inNode = new Node(0);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, line);
                        if (ifNodeNum != -1) ifNodeNum2 = -2;
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
                        fc.getGraph().setNodeType(nodeNum + 1, 3);
                        nodeNum += 2;
                        Edge e = new Edge();
                        e.outNode = new Node(nodeNum - 1);
                        e.inNode = new Node(nodeNum);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, line);
                        line = sr.ReadLine();
                    }
                    else
                    {
                        if (b != null && line != "")
                            if (b.isSquare())
                            {
                                fc.AddStrToBlock(b, line);
                            }
                            else
                            {
                                if (ifNodeNum != -1) fc.getGraph().setNodeShift(nodeNum, 1);
                                if (ifNodeNum2 != -1) fc.getGraph().setNodeShift(nodeNum, -1);
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
                fc.getGraph().setNodesNumber(nodeNum + 1);
            }
            return fc;
        }
        
        public IFlowchart CreateFlowchartFromDB(string code, string name)
        {
            Flowchart fc = new Flowchart(name);
            string[] arrCode = code.Split('\n');
            int nodeNum = 0;
            int ifNodeNum = -1;
            int ifNodeNum2 = -1;
            int forNodeNum = -1;
            int tmp = 0;
            IBlock b = null;
            for (int i = 0; i < arrCode.Count(); i++)
            {
                    if (arrCode[i].Contains("int main("))
                    {
                        b = new StartBlock();
                        fc.getGraph().setNodeType(nodeNum, 3);
                        nodeNum = 1;
                        Edge e = new Edge();
                        e.outNode = new Node(0);
                        e.inNode = new Node(1);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, arrCode[i]);
                        i++;
                    }
                    else
                    if (arrCode[i].Contains("if ("))
                    {
                        ifNodeNum = nodeNum;
                        b = new IfBlock();
                        fc.getGraph().setNodeType(nodeNum, 2);
                        nodeNum++;
                        Edge e = new Edge();
                        e.outNode = new Node(nodeNum - 1);
                        e.inNode = new Node(nodeNum);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, arrCode[i]);
                        i++;
                    }
                    else
                    if (arrCode[i].Contains("} else {")) //ifNodeNum2: -1 нет else; -2 в ифе есть ретёрн, нет else; -3 в ифе ретёрн, есть else; >=0 нет ретёрна, есть else
                    {
                        b = new IfBlock();
                        if (ifNodeNum2 == -1) ifNodeNum2 = nodeNum;
                        if (ifNodeNum2 == -2) ifNodeNum2 = -3;
                        if (ifNodeNum2 == -3) nodeNum++;
                        Edge e = new Edge();
                        e.outNode = new Node(ifNodeNum);
                        e.inNode = new Node(nodeNum);
                        fc.getGraph().addEdge(e);
                    }
                    else
                    if (arrCode[i].Contains("//endofif"))
                    {
                        Edge e = new Edge();
                        if (ifNodeNum2 == -1)
                        {
                            e.outNode = new Node(ifNodeNum);
                            e.inNode = new Node(nodeNum);
                            fc.getGraph().addEdge(e);
                        }
                        else
                        if (ifNodeNum2 == -2)
                        {
                            nodeNum++;
                            e = new Edge();
                            e.outNode = new Node(ifNodeNum);
                            e.inNode = new Node(nodeNum);
                            fc.getGraph().addEdge(e);
                        }
                        else
                        if (ifNodeNum2 != -3)
                        {
                            fc.getGraph().getAdj()[ifNodeNum2 - 1][fc.getGraph().getAdj()[ifNodeNum2 - 1].Count - 1] = nodeNum;
                        }
                        ifNodeNum = -1;
                        ifNodeNum2 = -1;
                    }
                    else
                    if (arrCode[i].Contains("for (") || (arrCode[i].Contains("while (") && !arrCode[i].Contains("}")))
                    {
                        forNodeNum = nodeNum;
                        b = new IfBlock();
                        fc.getGraph().setNodeType(nodeNum, 5);
                        nodeNum++;
                        Edge e = new Edge();
                        e.outNode = new Node(nodeNum - 1);
                        e.inNode = new Node(nodeNum);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, arrCode[i]);
                        i++;
                    }
                    else
                    if (arrCode[i].Contains("//endoffor"))
                    {
                        fc.getGraph().getAdj()[nodeNum - 1][fc.getGraph().getAdj()[nodeNum - 1].Count - 1] = forNodeNum;
                        Edge e = new Edge();
                        e.outNode = new Node(forNodeNum);
                        e.inNode = new Node(nodeNum);
                        fc.getGraph().addEdge(e);

                        b = new IfBlock();
                        forNodeNum = -1;
                    }
                    else
                    if (arrCode[i].Contains("do {"))
                    {
                        forNodeNum = nodeNum;
                        b = new IfBlock();
                    }
                    else
                    if (arrCode[i].Contains("} while ("))
                    {
                        b = new IfBlock();
                        fc.getGraph().setNodeType(nodeNum, 5);
                        nodeNum++;
                        Edge e = new Edge();
                        e.outNode = new Node(nodeNum - 1);
                        e.inNode = new Node(nodeNum);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, arrCode[i]);

                        e.outNode = new Node(nodeNum - 1);
                        e.inNode = new Node(forNodeNum);
                        fc.getGraph().addEdge(e);
                    }
                    else
                    if (arrCode[i].Contains("return "))
                    {
                        if (ifNodeNum != -1) fc.getGraph().setNodeShift(nodeNum, 1);
                        if (ifNodeNum2 != -1) fc.getGraph().setNodeShift(nodeNum, -1);
                        b = new StartBlock();
                        fc.getGraph().setNodeType(nodeNum, 3);
                        Edge e = new Edge();
                        e.outNode = new Node(0);
                        e.inNode = new Node(0);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, arrCode[i]);
                        if (ifNodeNum != -1) ifNodeNum2 = -2;
                    }
                    else
                    if (arrCode[i].Contains("//endoffunc"))
                    {
                        b = null;
                        tmp = 1;
                    }
                    else
                    if (arrCode[i] != "" && tmp == 1)
                    {
                        tmp = 0;
                        b = new StartBlock();
                        fc.getGraph().setNodeType(nodeNum + 1, 3);
                        nodeNum += 2;
                        Edge e = new Edge();
                        e.outNode = new Node(nodeNum - 1);
                        e.inNode = new Node(nodeNum);
                        fc.AddBlock(b, e);
                        fc.AddStrToBlock(b, arrCode[i]);
                        i++;
                    }
                    else
                    {
                        if (b != null && arrCode[i] != "")
                            if (b.isSquare())
                            {
                                fc.AddStrToBlock(b, arrCode[i]);
                            }
                            else
                            {
                                if (ifNodeNum != -1) fc.getGraph().setNodeShift(nodeNum, 1);
                                if (ifNodeNum2 != -1) fc.getGraph().setNodeShift(nodeNum, -1);
                                b = new SquareBlock();
                                fc.getGraph().setNodeType(nodeNum, 1);
                                nodeNum++;
                                Edge e = new Edge();
                                e.outNode = new Node(nodeNum - 1);
                                e.inNode = new Node(nodeNum);
                                fc.AddBlock(b, e);
                                fc.AddStrToBlock(b, arrCode[i]);
                            }
                    }

                }
                fc.getGraph().setNodesNumber(nodeNum + 1);
            return fc;
        }
    }
}
