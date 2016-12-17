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
        
        void WriteFile(string path);
    }

    class CppCode : ICode
    {
        private List<string> code;

        public CppCode(IFlowchart flowchart)
        {
            int currentNumOfTabbs = 0;

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
                        code.Add(tabbs + '}');
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
                scobes += '}';
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