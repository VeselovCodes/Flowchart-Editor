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
        void openClick(string name, string owner);
        void ToCreateNew();
    }

    class ChooseFlowchartPresenter : IChooseFlowchartPresenter
    {        
        public void Run() { }
                
        private DataManagement data;
        private ChooseFlowchartView view;

        public ChooseFlowchartPresenter(DataManagement data, ChooseFlowchartView view)
        {
            this.view = view;
            this.data = data;
            List<Tuple<string, string>> table = data.GetNamesAndLogins();
            view.SetFlowchartsTable(table);
        }

        public void openClick(string name, string owner)
        {
            if (data.GetLogin().Equals(owner))
            {
                data.LoadFlowchart(owner, name);
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
    }
}
