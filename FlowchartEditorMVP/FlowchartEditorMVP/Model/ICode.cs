using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowchartEditorMVP.Model
{
    interface ICode
    { 
        void WriteFile(string path);
        void Add(string str);
        string GetCodeLikeString();
    }

    class CppCode : ICode
    {
        private List<string> code;

        public void Add(string str)
        {
            code.Add(str);
        }

        public string GetCodeLikeString()
        {
            string str = "";
            foreach (var row in code)
            {
                str += row + "\n";
            }
            return str;
        }

        public CppCode(IFlowchart flowchart)
        {
            int currentNumOfTabbs = 0;
            Stack<int> stack = new Stack<int>(flowchart.GetListOfBlocks().Count);//1 - start, 2 - if, 3 - for, 4 - square

            code = new List<string>(1);
            foreach (var block in flowchart.GetListOfBlocks())
            {                
                foreach (var str in block.GetListOfStrings())
                {
                    currentNumOfTabbs = 0;
                    if (code.Count() != 0)
                    {
                        foreach (var c in code[code.Count() - 1].ToCharArray())
                        {
                            if (c != 9)
                            {
                                break;
                            }
                            currentNumOfTabbs++;
                        }
                        string tabbs = "";
                        if (str[currentNumOfTabbs] == 9)
                        {
                            for (int i = 0; i < currentNumOfTabbs; i++)
                            {
                                tabbs += '\t';
                            }

                            if (flowchart.GetListOfBlocks()[flowchart.GetListOfBlocks().IndexOf(block) - 1] is StartBlock)
                            {
                                stack.Push(1);
                            }

                            if (code.Last().Contains("if ("))
                            {
                                stack.Push(2);
                            }

                            if (code.Last().Contains("for ("))
                            {
                                stack.Push(3);
                            }
                            code.Add(tabbs + '{');                                     
                        }
                    }
                    if (currentNumOfTabbs != 0 && str[currentNumOfTabbs - 1] != 9)
                    {
                        string tabbs = "";
                        for (int i = 0; i < currentNumOfTabbs - 1; ++i)
                        {
                            tabbs += '\t';
                        }

                        int endOfBlock = stack.Pop();
                        string endingSomething;
                        switch (endOfBlock)
                        {
                            case 1:
                                {
                                    endingSomething = "//endoffunc";
                                    break;
                                }
                            case 2:
                                {
                                    endingSomething = "//endofif";
                                    break;
                                }
                            case 3:
                                {
                                    endingSomething = "//endoffor";
                                    break;
                                }
                            default:
                                {
                                    endingSomething = "";
                                    break;
                                }
                        }


                        code.Add(tabbs + '}' + endingSomething);
                    }
                    code.Add(str);
                }
            }

            currentNumOfTabbs = 0;
            foreach (var c in code[code.Count() - 1].ToCharArray())
            {
                if (c != 9)
                {
                    break;
                }
                currentNumOfTabbs++;
            }
            string scobes = "";
            for (int j = 0; j < currentNumOfTabbs; ++j)
            {
                int endOfBlock = stack.Pop();
                string endingSomething;
                switch (endOfBlock)
                {
                    case 1:
                        {
                            endingSomething = "//endoffunc";
                            break;
                        }
                    case 2:
                        {
                            endingSomething = "//endofif";
                            break;
                        }
                    case 3:
                        {
                            endingSomething = "//endoffor";
                            break;
                        }
                    default:
                        {
                            endingSomething = "";
                            break;
                        }
                }
                scobes += '}' + endingSomething;
            }

            code.Add(scobes);


        }

        public void WriteFile(string path)
        {            if (File.Exists(path))
            {
                // Note that no lock is put on the
                // file and the possibility exists
                // that another process could do
                // something with it between
                // the calls to Exists and Delete.
                File.Delete(path);
            }
            //Create a file to write to.
            using (FileStream fs = File.Create(path))
            {
                string inFileText = "";

                foreach (var str in code)
                {
                    inFileText += str + '\n';
                }
                Byte[] info = new UTF8Encoding(true).GetBytes(inFileText);
                fs.Write(info, 0, info.Length);
            }
        }     
    }
}