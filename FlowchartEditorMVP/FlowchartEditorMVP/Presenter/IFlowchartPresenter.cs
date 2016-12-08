using FlowchartEditorMVP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{
    interface IFlowchartPresenter : IPresenter
    {
        void AddBlock(string str, int x, int y);
        void EditBlock(string str, int x, int y);
        void RemoveBlock(int x, int y);
        bool IsEdge(int xCoordsClick, int yCoordsClick);
        bool IsSquareBlock(int xCoordsClick, int yCoordsClick);
        void ToCode();
        void Apply(string name, string owner);
        void Decline();
        List<Tuple<string, string>> GetReviewsAndLogins();
        void LoadReviewedFlowchart(string reviewer, string name);
        void ToDataBase();
        string GetLogin();
    }

    class MasterPresenter : IFlowchartPresenter
    {
        private IFlowchart flowchart;
        private DataManagement data;
        private CodeFactory code;

        public MasterPresenter(string name, string owner, string path)
        {
            code = new CppFactory();
            flowchart = new CppCode().ToFlowchart(path);
            data = new DataManagement();
        }

        public MasterPresenter(string name, string owner)
        {
            code = new CppFactory();
            
            data = new DataManagement();

            flowchart =data.LoadFlowchart(name, owner);
        }
        public string GetLogin()
        {
            return data.GetLogin();
        }
        public void Apply(string name, string owner) { }
        public void Decline() { }
        public void ToCode() { }
        public bool IsEdge(int xCoordsClick, int yCoordsClick) { return true; }
        public bool IsSquareBlock(int xCoordsClick, int yCoordsClick) { return true; }
        public void Run() { }
        public void AddBlock(string str, int x, int y) { }
        public void EditBlock(string str, int x, int y) { }
        public void RemoveBlock(int x, int y) { }
        public List<Tuple<string, string>> GetReviewsAndLogins()
        {
            return new List<Tuple<string, string>>();
        }
        public void LoadReviewedFlowchart(string reviewer,string name)
        {
            flowchart = data.LoadFlowchart(reviewer, name);
        }
        public void ToDataBase()
        {
            data.AddToDB(flowchart);
        }
    }

    class ReviewerPresenter : IFlowchartPresenter
    {
        private IFlowchart flowchart;
        private DataManagement data;
        private CodeFactory codeF;
        
        public string GetLogin()
        {
            return data.GetLogin();
        }
        public ReviewerPresenter(string name, string owner) { }
        public void Apply(string name, string owner)
        {
            flowchart = data.LoadFlowchart(owner, name);
        }
        public void Decline()
        { }
        public void ToCode()
        {
            codeF.CreateCode(flowchart);
        }
        public bool IsEdge(int xCoordsClick, int yCoordsClick)
        {
            return true;
        }
        public bool IsSquareBlock(int xCoordsClick, int yCoordsClick) { return true; }
        public void Run() { }
        public void AddBlock(string str, int x, int y)
        {
            flowchart.AddBlock(new SquareBlock(), new Edge());
        }
        public void EditBlock(string str, int x, int y)
        {
            flowchart.AddStrToBlock(new SquareBlock(), str);
        }
        public void RemoveBlock(int x, int y)
        {
            flowchart.DeleteSquareBlock(new SquareBlock());
        }
        public List<Tuple<string, string>> GetReviewsAndLogins()
        {
            return new List<Tuple<string, string>>();
        }
        public void LoadReviewedFlowchart(string reviewer, string name)
        {
            flowchart = data.LoadFlowchart(reviewer, name);
        }
        public void ToDataBase()
        {
            data.AddToDB(flowchart);
        }
    }
}
