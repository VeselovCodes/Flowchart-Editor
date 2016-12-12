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
        bool isSquare();
        void AddStr(string str);
    }

    class StartBlock : IBlock
    {
        private string text;

        public void Draw() { }
        public bool isSquare() { return false; }
        public void AddStr(string str) { text = str; }
    }

    class SquareBlock : IBlock
    {
        private List<string> text = new List<string>();

        public void Draw() { }
        public bool isSquare() { return true; }
        public void AddStr(string str) { text.Add(str); }
    }

    class IfBlock : IBlock
    {
        private string text;

        public void Draw() { }
        public bool isSquare() { return false; }
        public void AddStr(string str) { text = str; }
    }

    class ConnecterBlock : IBlock
    {
        public void Draw() { }
        public bool isSquare() { return false; }
        public void AddStr(string str) { }
    }
}
