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
    public partial class ReviewerView : Form , IView
    {
        private int xCoordsClick;
        private int yCoordsClick;

        private IFlowchartPresenter flowchartPresenter;

<<<<<<< HEAD
        public ReviewerView(string name, string owner)
=======
        public ReviewerView()
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
        {
            InitializeComponent();
            flowchartPresenter = new ReviewerPresenter(name, owner);
        }

        private void ReviewerView_Load(object sender, EventArgs e)
        {
            
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

        private void toCodeButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.ToCode();            
        }

        private void changeModeButton_Click(object sender, EventArgs e)
        {
            ChooseFlowchartView modeView = new ChooseFlowchartView(flowchartPresenter.GetLogin());
            this.Hide();
            modeView.Show();     
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

        private void toDatabaseButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.ToDataBase();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView(flowchartPresenter.GetLogin());
            this.Hide();
            chooseFlowchartView.Show();
        }

        private void ReviewerView_Load(object sender, EventArgs e)
        {
            flowchartPresenter = new ReviewerPresenter();
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

        private void toCodeButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.ToCode();            
        }

        private void changeModeButton_Click(object sender, EventArgs e)
        {
            ModeView modeView = new ModeView();
            this.Hide();
            modeView.Show();     
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

        private void toDatabaseButton_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView();
            this.Hide();
            chooseFlowchartView.Show();
        }
    }
}
