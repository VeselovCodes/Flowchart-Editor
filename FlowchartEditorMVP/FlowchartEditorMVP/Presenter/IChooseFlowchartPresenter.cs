using FlowchartEditorMVP.Model;
using FlowchartEditorMVP.View;
using System.Data;

namespace FlowchartEditorMVP.Presenter
{
    interface IChooseFlowchartPresenter : IPresenter
    {        
        string GetLogin();
        void openClick();
        void ToCreateNew();
        void SelectFlowchart(string owner, string name, string reviewer);
        void ShowComment(string owner, string reviewer, string name);
    }

    class ChooseFlowchartPresenter : IChooseFlowchartPresenter
    {                  
        private DataManagement data;
        private ChooseFlowchartView view;

        private string owner;
        private string reviewer;
        private string flowchartName;

        public ChooseFlowchartPresenter(DataManagement data, ChooseFlowchartView view)
        {
            this.view = view;
            this.data = data;
            DataTable table = data.GetNamesAndLogins();
            view.SetFlowchartsTable(table);
        }

        public void ShowComment(string owner, string reviewer, string name)
        {
            string comment = data.GetComment(owner, reviewer, name);
            view.SetCommentText(comment);
        }

        public void openClick()
        {
            if (data.GetLogin().Equals(owner))
            {
                data.SetOwner(data.GetLogin());
                data.SetReviewer(reviewer);
                view.Hide();
                FlowchartView mView = new FlowchartView(data, flowchartName, true, reviewer);
                mView.Show();
            }  
            else
            {
                data.SetReviewer(data.GetLogin());
                data.SetOwner(owner);
                view.Hide();
                FlowchartView mView = new FlowchartView(data, flowchartName, false, reviewer);
                mView.Show();
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

        public void SelectFlowchart(string owner, string name, string reviewer)
        {
            this.owner = owner;
            this.reviewer = reviewer;
            flowchartName = name; 
        }
    }
}