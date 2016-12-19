using FlowchartEditorMVP.Model;
using FlowchartEditorMVP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowchartEditorMVP.Presenter
{

    interface INewFlowchartPresenter : IPresenter
    {
        string GetLogin();
        void ToChooseFlowchart();
        void CreateNew(string text1, string text2, string code_type);
    }

    class NewFlowchartPresenter : INewFlowchartPresenter
    {
        private DataManagement data;
        private NewFlowchartView view;

        public NewFlowchartPresenter(DataManagement data, NewFlowchartView view)
        {
            this.data = data;
            this.view = view;
        }

        public void ToChooseFlowchart()
        {
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView(data);
            view.Hide();
            chooseFlowchartView.Show();
        }

        public string GetLogin()
        {
            return data.GetLogin();
        }

        public void CreateNew(string name, string path, string code_type)
        {
            if (name == "" || path == "")
            {
                throw new Exception("Enter name and path of code file for creating flowchart.");
            }
            FlowchartView masterView = new FlowchartView(data, path, name, code_type);
            view.Hide();
            masterView.Show();   
        }
    }    
}
