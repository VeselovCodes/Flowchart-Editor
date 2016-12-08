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

        private IFlowchartPresenter flowchartPresenter;

        public MasterView()
        {
            InitializeComponent();
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
