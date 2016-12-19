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
        bool IsEdge(int xCoordsClick, int yCoordsClick, int scroll);
        bool IsSquareBlock(int i);
        void ToCode();
        string GetLogin();
        void ToChooseFlowchart();
        IFlowchart getFlowchart();
        void FlowchartMouseClick(int x, int y, int scroll);        
        int GetSelectedBlock();
        int[] GetSelectedEdge();
        int GetScrollBarBValue();
    }

    class MasterPresenter : IFlowchartPresenter
    {
        protected IFlowchart flowchart;
        protected DataManagement data;
        protected FlowchartView view;
        protected int selectedBlock;
        protected int[] selectedEdge;

        public MasterPresenter(DataManagement data, string path, FlowchartView view, string name, string type_code)
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

        public MasterPresenter(DataManagement data, FlowchartView view, string name)
        {                   
            this.data = data;
            this.view = view;
            flowchart = data.LoadFlowchart(name);
            selectedBlock = -1;
            selectedEdge = new int[2];
            selectedEdge[0] = -1;
            selectedEdge[1] = -1;
        }

        public string GetLogin()
        {
            return data.GetLogin();
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
                if (flowchart.GetGraph().GetNodeShift(selectedBlock) == 0)
                    str[i] = "\t" + str[i];
                else 
                    str[i] = "\t\t" + str[i];
                if (flowchart.GetGraph().GetNodeType(selectedBlock - 1) == 5) str[i] = "\t" + str[i];
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
        public void ToDataBase(string comment)
        {
            data.MasterAddToDB(flowchart, comment);
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

    class MasterViewChangesPresenter : IFlowchartPresenter
    {
        private IFlowchart flowchart;
        private DataManagement data;
        private FlowchartView view;
        private int selectedBlock;
        private int[] selectedEdge;

        public MasterViewChangesPresenter(DataManagement data, FlowchartView view, string name)
        {
            this.data = data;
            this.view = view;
            flowchart = data.LoadFlowchart(name);
            selectedBlock = -1;
            selectedEdge = new int[2];
            selectedEdge[0] = -1;
            selectedEdge[1] = -1;
        }
        public void Apply(string name, string owner)
        {
            //замена блоксхемы мастера текущей
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

        public int GetSelectedBlock()
        {
            return selectedBlock;
        }
        public string GetLogin()
        {
            return data.GetLogin();
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

        public void Decline()
        {
            //удаление текущей блоксхемы из бд
        }
    }

    class ReviewerPresenter : MasterPresenter
    {
        public ReviewerPresenter(DataManagement data, FlowchartView view, string name) : base(data, view, name) { }       

        public void ToDataBase(string comment)
        {
            data.ReviewerAddToDB(flowchart, comment);
        }
    }
}
