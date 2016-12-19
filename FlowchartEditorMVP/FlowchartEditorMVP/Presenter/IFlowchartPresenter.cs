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
        void AddBlock();
        void EditBlock(List<string> str);
        void RemoveBlock();
        bool IsEdge(int xCoordsClick, int yCoordsClick, int scroll);
        bool IsSquareBlock(int i);
        void ToCode();
        void Apply(string name, string owner);
        void Decline();
        List<Tuple<string, string>> GetReviewsAndLogins();
        void LoadReviewedFlowchart(string reviewer, string name);
        void ToDataBase();
        string GetLogin();
        void ToChooseFlowchart();
        IFlowchart getFlowchart();
        void FlowchartMouseClick(int x, int y, int scroll);
        void SelectBlock(int i);
        int GetSelectedBlock();
        int[] GetSelectedEdge();
        int GetScrollBarBValue();
    }

    class MasterPresenter : IFlowchartPresenter
    {
        private IFlowchart flowchart;
        private DataManagement data;
        //private CodeFactory code;
        private MasterView view;
        private int selectedBlock;
        private int[] selectedEdge;

        public MasterPresenter(DataManagement data, string path, MasterView view, string name, string type_code)
        {
            switch (type_code)
            {
                case "C++":
                {
                    flowchart = new FlowchartCppFactory().CreateFlowchart(path, name);
                    break;
                }
                default:
                {
                        flowchart = new Flowchart(name);
                        break;
                } 
            }
            this.data = data;
            this.view = view;
            selectedBlock = -1;
            selectedEdge = new int[2];
            selectedEdge[0] = -1;
            selectedEdge[1] = -1;
        }

        public void SelectBlock(int i)
        {
            selectedBlock = i;
        }

        public int GetSelectedBlock()
        {
            return selectedBlock;
        }

        public int[] GetSelectedEdge()
        {
            return selectedEdge;
        }

        public void ToChooseFlowchart()
        {
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView(data);
            view.Hide();
            chooseFlowchartView.Show();
        }

        public MasterPresenter(DataManagement data, MasterView view, string name)
        {                   
            this.data = data;
            this.view = view;
            flowchart = data.LoadFlowchart(name);
        }

        public string GetLogin()
        {
            return data.GetLogin();
        }

        public void Apply(string name, string owner) { }
        public void Decline()
        {
        }
        public void ToCode()
        {
            ICode code = new CppFactory().
                CreateCode(flowchart);
            code.WriteFile(@"MyTest.cpp");
        }
        public bool IsEdge(int xCoordsClick, int yCoordsClick, int scroll)
        {
            if (selectedBlock == -1)
            {
                selectedEdge = flowchart.GetEdge(xCoordsClick, yCoordsClick, scroll);
                return true;
            }
            selectedEdge[0] = -1;
            selectedEdge[1] = -1;
            return false;
        }
        public bool IsSquareBlock(int i)
        {
            return flowchart.GetListOfBlocks()[i].IsSquare();
        }
        public void Run() { }
        public void AddBlock()
        {
            if (selectedEdge[0] < selectedEdge[1])
            flowchart.AddBlockOnEdge(selectedEdge);
        }
        public void EditBlock(List<string> str)
        {
            flowchart.GetListOfBlocks()[selectedBlock].clearText();
            for (int i = 0; i < str.Count; i++)
            {
                flowchart.GetListOfBlocks()[selectedBlock].AddStr(str[i]);
            }
        }
        public void RemoveBlock()
        {
            if (flowchart.GetGraph().GetAdj()[selectedBlock][0] > selectedBlock)
            {
                flowchart.DeleteSquareBlock(selectedBlock);
                selectedBlock = -1;
            }
        }
        public List<Tuple<string, string>> GetReviewsAndLogins()
        {
            return new List<Tuple<string, string>>();
        }
        public void LoadReviewedFlowchart(string reviewer,string name)
        {
            flowchart = data.LoadFlowchart(name);
        }
        public void ToDataBase()
        {
            data.AddToDB(flowchart);
        }
        public IFlowchart getFlowchart()
        {
            return flowchart;
        }

        public void FlowchartMouseClick(int x, int y, int scroll)
        {
            selectedBlock = flowchart.GetBlock(x, y, scroll);
            if (selectedBlock == -1) 
                view.ShowBlockContent(null); 
            else
                view.ShowBlockContent(flowchart.GetListOfBlocks()[selectedBlock]);
        }

        public int GetScrollBarBValue()
        {
            return Math.Max(0, (flowchart.GetGraph().CountNodes() * 125 - 675) / 10);
        }
    }

    class ReviewerPresenter : IFlowchartPresenter
    {
        private IFlowchart flowchart;
        private DataManagement data;        
        private ReviewerView view;
        private int selectedBlock;
        private int[] selectedEdge;

        public void SelectBlock(int i)
        {
            selectedBlock = i;
        }

        public int GetSelectedBlock()
        {
            return selectedBlock;
        }

        public int[] GetSelectedEdge()
        {
            return selectedEdge;
        }

        public void FlowchartMouseClick(int x, int y, int scroll)
        {
            //IBlock block = flowchart.GetBlock(x, y);
            //view.ShowBlockContent(block);
            selectedBlock = -1;
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

        public ReviewerPresenter(DataManagement data, ReviewerView view, string name)
        {
        }
        public void Apply(string name, string owner)
        {
            flowchart = data.LoadFlowchart(name);
            this.data = data;
        }
        public void Decline()
        { }
        public void ToCode()
        {
            ICode code = new CppFactory().
                CreateCode(flowchart);
            code.WriteFile(@"MyTest.cpp");
        }
        public bool IsEdge(int xCoordsClick, int yCoordsClick, int scroll)
        {
            return true;
        }
        public bool IsSquareBlock(int i)
        {
            return true;
        }
        public void Run() { }
        public void AddBlock()
        {
            if (selectedEdge[0] < selectedEdge[1])
                flowchart.AddBlockOnEdge(selectedEdge);
        }
        public void EditBlock(List<string> str)
        {
            flowchart.GetListOfBlocks()[selectedBlock].clearText();
            for (int i = 0; i < str.Count; i++)
            {
                flowchart.GetListOfBlocks()[selectedBlock].AddStr(str[i]);
            }
        }
        public void RemoveBlock()
        {
            if (flowchart.GetGraph().GetAdj()[selectedBlock][0] > selectedBlock)
            {
                flowchart.DeleteSquareBlock(selectedBlock);
                selectedBlock = -1;
            }
        }
        public List<Tuple<string, string>> GetReviewsAndLogins()
        {
            return new List<Tuple<string, string>>();
        }
        public void LoadReviewedFlowchart(string reviewer, string name)
        {
            flowchart = data.LoadFlowchart(name);
        }
        public void ToDataBase()
        {
            //data.AddToDB(flowchart);
            data.AddToDB(flowchart);
        }
        public IFlowchart getFlowchart()
        {
            return flowchart;
        }

        public int GetScrollBarBValue()
        {
            return Math.Max(0, (flowchart.GetGraph().CountNodes() * 125 - 675) / 10);
        }
    }
}
