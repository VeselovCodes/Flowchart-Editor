using FlowchartEditorMVP.Model;
using FlowchartEditorMVP.View;
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
        void ToDataBase(string name);
        string GetLogin();
        void ToChooseFlowchart();
        IFlowchart getFlowchart();
        void FlowchartMouseClick(int x, int y, int scroll);
    }

    class MasterPresenter : IFlowchartPresenter
    {
        private IFlowchart flowchart;
        private DataManagement data;
        private CodeFactory code;
        private MasterView view;
        

        public MasterPresenter(DataManagement data, string path, MasterView view)
        {
            code = new CppFactory();
            flowchart = new CppCode().ToFlowchart(path);
            this.data = data;
            this.view = view;
        }

        public void ToChooseFlowchart()
        {
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView(data);
            view.Hide();
            chooseFlowchartView.Show();
        }

        public MasterPresenter(DataManagement data, MasterView view)
        {
            code = new CppFactory();
            
            data = new DataManagement();
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
        public void ToDataBase(string name)
        {
            //data.AddToDB(flowchart);
            data.AddToDB(flowchart, name);
        }
        public IFlowchart getFlowchart()
        {
            return flowchart;
        }

        public void FlowchartMouseClick(int x, int y, int scroll)
        {
            IBlock block = flowchart.GetBlock(x, y, scroll);
            view.ShowBlockContent(block);
        }
    }

    class ReviewerPresenter : IFlowchartPresenter
    {
        private IFlowchart flowchart;
        private DataManagement data;
        private CodeFactory codeF;
        private ReviewerView view;

        public void FlowchartMouseClick(int x, int y, int scroll)
        {
            //IBlock block = flowchart.GetBlock(x, y);
            //view.ShowBlockContent(block);
        }

        public string GetLogin()
        {
            return data.GetLogin();
        }

        public void ToChooseFlowchart()
        {
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView(data);
            view.Hide();
            chooseFlowchartView.Show();
        }

        public ReviewerPresenter(DataManagement data, ReviewerView view)
        {
        }
        public void Apply(string name, string owner)
        {
            flowchart = data.LoadFlowchart(owner, name);
            this.data = data;
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
        public void ToDataBase(string name)
        {
            //data.AddToDB(flowchart);
            data.AddToDB(flowchart, name);
        }
        public IFlowchart getFlowchart()
        {
            return flowchart;
        }
        public string getFlowchartName()
        {
            return data.GetFlowchartName();
        }

    }
}
