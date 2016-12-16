using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Model
{
    interface IBlock
    {
        void Draw();
        bool IsSquare();
        void AddStr(string str);
        List<string> GetListOfStrings();
    }

    class StartBlock : IBlock
    {
        private string text;

        public void Draw() { }
        public bool IsSquare() { return false; }
        public void AddStr(string str) { text = str; }
        public List<string> GetListOfStrings()
        {
            List <string> str = new List<string>(1);
            str.Add(text);
            return str;
        }
    }

    class SquareBlock : IBlock
    {
        private List<string> text = new List<string>();

        public void Draw() { }
        public bool IsSquare() { return true; }
        public void AddStr(string str) { text.Add(str); }
        public List<string> GetListOfStrings()
        {           
            return text;
        }
    }

    class IfBlock : IBlock
    {
        private string text;

        public void Draw() { }
        public bool IsSquare() { return false; }
        public void AddStr(string str) { text = str; }
        public List<string> GetListOfStrings()
        {
            List<string> str = new List<string>(1);
            str.Add(text);
            return str;
        }
    }

    class ConnecterBlock : IBlock
    {
        public void Draw() { }
        public bool IsSquare() { return false; }
        public void AddStr(string str) { }
        public List<string> GetListOfStrings()
        {
            List<string> str = new List<string>(1);
            str.Add("");
            return str;
        }
    }
}
