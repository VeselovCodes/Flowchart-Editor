using FlowchartEditorMVP.Model;
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

        internal ReviewerView(DataManagement data, string name)
        {
            InitializeComponent();
            flowchartPresenter = new ReviewerPresenter(data, this, name);
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
            flowchartPresenter.ToChooseFlowchart();                
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
            flowchartPresenter.ToChooseFlowchart();
        }
    }
}
