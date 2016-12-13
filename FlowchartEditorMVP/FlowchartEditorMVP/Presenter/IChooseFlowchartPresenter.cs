using FlowchartEditorMVP.Model;
using FlowchartEditorMVP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{
    interface IChooseFlowchartPresenter : IPresenter
    {        
        string GetLogin();
        void openClick();
        void ToCreateNew();
        void SelectFlowchart(string owner, string name);
    }

    class ChooseFlowchartPresenter : IChooseFlowchartPresenter
    {        
        public void Run() { }
                
        private DataManagement data;
        private ChooseFlowchartView view;

        private string owner;
        private string flowchartName;

        public ChooseFlowchartPresenter(DataManagement data, ChooseFlowchartView view)
        {
            this.view = view;
            this.data = data;
            List<Tuple<string, string>> table = data.GetNamesAndLogins();
            view.SetFlowchartsTable(table);
        }

        public void openClick()
        {
            if (data.GetLogin().Equals(owner))
            {
                data.LoadFlowchart(owner, flowchartName);
                view.Hide();
                MasterView mView = new MasterView(data);
            }
            else
            {
                ReviewerView rView = new ReviewerView(data);
            }
        }

        public void ToCreateNew()
        {
            NewFlowchartView newFlowchartView = new NewFlowchartView(data);
            view.Hide();
            newFlowchartView.Show();
        }

        public string GetLogin()
        {
            return data.GetLogin();
        }

        public void SelectFlowchart(string owner, string name)
        {
            this.owner = owner;
            this.flowchartName = name; 
        }
    }
}
