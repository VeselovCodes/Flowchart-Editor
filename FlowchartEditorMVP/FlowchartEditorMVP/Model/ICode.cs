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

            code = new List<string>(1);
            foreach (var block in flowchart.GetListOfBlocks())
            {
                foreach (var str in block.GetListOfStrings())
                {
                    code.Add(str);
                }
            }
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