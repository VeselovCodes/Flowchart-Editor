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
    public partial class MasterView : Form , IView
    {
        private int xCoordsClick;
        private int yCoordsClick;
<<<<<<< HEAD
        private IFlowchartPresenter flowchartPresenter;

        public MasterView(string name, string owner, string path)
        {            
            InitializeComponent();
            flowchartPresenter = new MasterPresenter(name, owner, path);
        }
        public MasterView(string name, string owner)
=======

        private IFlowchartPresenter flowchartPresenter;

        public MasterView()
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
        {
            InitializeComponent();
            flowchartPresenter = new MasterPresenter(name, owner);
        }

        private void MasterView_Load(object sender, EventArgs e)
        {
            List<Tuple<string, string>> flowchartReviewsLogins = flowchartPresenter.GetReviewsAndLogins();

            /*for (int i = 0; i < 10; i++)
            {
                reviewsDataGridView.Rows.Add();
                reviewsDataGridView.Rows[i].Cells[0].Value = flowchartReviewsLogins[i].Item1;
                reviewsDataGridView.Rows[i].Cells[1].Value = flowchartReviewsLogins[i].Item2;
            }*/
        }

        private void addBlockButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.AddBlock(codeTextbox.Text, xCoordsClick, yCoordsClick);
        }

        private void editBlockButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.EditBlock(codeTextbox.Text, xCoordsClick, yCoordsClick);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.RemoveBlock(xCoordsClick, yCoordsClick);
        }

        private void toDatabaseButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.ToDataBase();
        }

        private void toCodeButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.ToCode();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.Apply("Name", "Reviewer");
        }

        private void declineButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.Decline();
        }

        private void flowchartPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            xCoordsClick = e.X;
            yCoordsClick = e.Y;
            if (flowchartPresenter.IsEdge(xCoordsClick, yCoordsClick))
                addBlockButton.Enabled = true;

            if (flowchartPresenter.IsSquareBlock(xCoordsClick, yCoordsClick))
            {
                editBlockButton.Enabled = true;
                removeButton.Enabled = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView(flowchartPresenter.GetLogin());
            this.Hide();
            chooseFlowchartView.Show();
        }

        private void reviewsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            flowchartPresenter.LoadReviewedFlowchart(reviewsDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()
                , reviewsDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void MasterView_Load(object sender, EventArgs e)
        {
            flowchartPresenter = new MasterPresenter();
        }

        private void addBlockButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.AddBlock(codeTextbox.Text, xCoordsClick, yCoordsClick);
        }

        private void editBlockButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.EditBlock(codeTextbox.Text, xCoordsClick, yCoordsClick);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.RemoveBlock(xCoordsClick, yCoordsClick);
        }

        private void toDatabaseButton_Click(object sender, EventArgs e)
        {

        }

        private void toCodeButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.ToCode();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.Apply();
        }

        private void declineButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.Decline();
        }

        private void flowchartPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            xCoordsClick = e.X;
            yCoordsClick = e.Y;
            if (flowchartPresenter.IsEdge(xCoordsClick, yCoordsClick))
                addBlockButton.Enabled = true;

            if (flowchartPresenter.IsSquareBlock(xCoordsClick, yCoordsClick))
            {
                editBlockButton.Enabled = true;
                removeButton.Enabled = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView();
            this.Hide();
            chooseFlowchartView.Show();
        }
    }
}
