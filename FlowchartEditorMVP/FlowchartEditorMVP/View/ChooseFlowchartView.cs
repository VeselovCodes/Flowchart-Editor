using FlowchartEditorMVP.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowchartEditorMVP.View
{
    public partial class ChooseFlowchartView : Form , IView
    {
        private IChooseFlowchartPresenter presenter;
        private IEnterPresenter enterPresenter;

        public ChooseFlowchartView()
        {
            InitializeComponent();
        }

        private void ChooseFlowchartView_Load(object sender, EventArgs e)
        {
            presenter = new ChooseFlowchartPresenter();
            enterPresenter = new EnterPresenter(this);
        }

        private void changeUserButton_Click(object sender, EventArgs e)
        {
            EnterView enterView = new EnterView();
            this.Hide();
            enterView.Show();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            string str1 = "reviewer"; // Заменить на первый textbox

            string str2 = "reviewer"; // Заменить на второй textbox

            if (enterPresenter.loginType(str1, str2) == "master")
            {
                MasterView masterView = new MasterView();
                this.Hide();
                masterView.Show();
            }
            else if (enterPresenter.loginType(str1, str2) == "reviewer")
            {
                ReviewerView reviewerView = new ReviewerView();
                this.Hide();
                reviewerView.Show();
            }
        }

        private void createNewButton_Click(object sender, EventArgs e)
        {
            NewFlowchartView newFlowchartView = new NewFlowchartView();
            this.Hide();
            newFlowchartView.Show();
        }
    }
}
