using FlowchartEditorMVP.Model;
using FlowchartEditorMVP.Presenter;
using System;
using System.Data;
using System.Windows.Forms;

namespace FlowchartEditorMVP.View
{
    public partial class ChooseFlowchartView : Form , IView
    {
        private IChooseFlowchartPresenter presenter;
        
        internal ChooseFlowchartView(DataManagement data)
        {
            InitializeComponent();
            presenter = new ChooseFlowchartPresenter(data, this);
        }

        private void ChooseFlowchartView_Load(object sender, EventArgs e)
        {          

            
        }

        internal void SetFlowchartsTable(DataTable table)
        {
            flowchartDataGridView.DataSource = table;
        }

        private void changeUserButton_Click(object sender, EventArgs e)
        {
            EnterView enterView = new EnterView();
            this.Hide();
            enterView.Show();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            presenter.openClick();            
        }

        private void createNewButton_Click(object sender, EventArgs e)
        {
            presenter.ToCreateNew();
        }

        private void flowchartDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var owner = flowchartDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                var reviewer = flowchartDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                var name = flowchartDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                presenter.ShowComment(owner, reviewer, name);
                if (reviewer != "" && owner != presenter.GetLogin())
                {
                    openButton.Enabled = false;
                }
                else
                {
                    presenter.SelectFlowchart(owner, name, reviewer);
                    openButton.Enabled = true;
                }
            }
            catch (Exception exc)
            {
                excLabel.Text = "Select one of the current flowcharts or create new.";
            }       
        }

        public void SetCommentText(string text)
        {
            commentRichTextBox.Text = text;
        }
    }
}