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
        private string owner;
        private string name;
                
        public ChooseFlowchartView(string login)
        {
            InitializeComponent();
            presenter = new ChooseFlowchartPresenter(login);
        }

        private void ChooseFlowchartView_Load(object sender, EventArgs e)
        {
            //List<Tuple<string, string>> flowchartNamesLogins = presenter.GetNamesAndLogins();

            /*for (int i = 0; i < 10; i++)
            {
                flowchartDataGridView.Rows.Add();
                flowchartDataGridView.Rows[i].Cells[0].Value = flowchartNamesLogins[i].Item1;
                flowchartDataGridView.Rows[i].Cells[1].Value = flowchartNamesLogins[i].Item2;
            }*/
        }

        private void changeUserButton_Click(object sender, EventArgs e)
        {
            EnterView enterView = new EnterView();
            this.Hide();
            enterView.Show();
        }

        private void openButton_Click(object sender, EventArgs e)
        {           

            if (owner == presenter.GetLogin())
            {
                MasterView masterView = new MasterView(name, owner);
                this.Hide();
                masterView.Show();
            }
            else 
            {
                ReviewerView reviewerView = new ReviewerView(name, owner);
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

        private void flowchartDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            owner = flowchartDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            name = flowchartDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
