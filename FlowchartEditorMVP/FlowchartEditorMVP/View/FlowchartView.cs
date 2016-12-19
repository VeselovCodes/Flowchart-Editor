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
    public partial class FlowchartView : Form , IView
    {
        private IFlowchartPresenter flowchartPresenter;
        bool isMaster;
        
        internal FlowchartView(DataManagement data, string path, string name, string type_code)
        {            
            InitializeComponent();
            flowchartPresenter = new MasterPresenter(data, path, this, name, type_code);
            commentTextBox.ReadOnly = true;
            applyButton.Enabled = false;
            declineButton.Enabled = false;
        }
        internal FlowchartView(DataManagement data, string name, bool isMaster, string reviewer)
        {
            InitializeComponent();
            this.isMaster = isMaster;
            if (isMaster && (reviewer == "" || reviewer == null))
            {
                flowchartPresenter = new MasterPresenter(data, this, name);
                commentTextBox.ReadOnly = true;
                applyButton.Enabled = false;
                declineButton.Enabled = false;
            }
            else if (reviewer != "" && reviewer != null)
            {
                flowchartPresenter = new MasterViewChangesPresenter(data, this, name);
                commentTextBox.ReadOnly = true;
                toDatabaseButton.Enabled = false;
                addBlockButton.Enabled = false;
                editBlockButton.Enabled = false;
                removeButton.Enabled = false;
            }
            else
            {
                flowchartPresenter = new ReviewerPresenter(data, this, name);
                applyButton.Enabled = false;
                declineButton.Enabled = false;
            }
            vScrollBar1.Maximum = flowchartPresenter.GetScrollBarBValue();

            DrawFlowchart();
        }

        private void FlowchartView_Load(object sender, EventArgs e)
        {
        }

        private void addBlockButton_Click(object sender, EventArgs e)
        {
            ((MasterPresenter)flowchartPresenter).AddBlock();
            DrawFlowchart();
            vScrollBar1.Maximum = flowchartPresenter.GetScrollBarBValue();
        }

        private void editBlockButton_Click(object sender, EventArgs e)
        {
            if (editBlockButton.Text == "Edit block")
            {
                blockContainsTextBox.BackColor = Color.White;
                editBlockButton.Text = "Save changes";
                blockContainsTextBox.ReadOnly = false;
            }
            else
            {
                blockContainsTextBox.BackColor = SystemColors.Control;
                editBlockButton.Text = "Edit block";
                List<string> str = new List<string>();
                for (int i = 0; i < blockContainsTextBox.Lines.Length; i++)
                {
                    str.Add(blockContainsTextBox.Lines[i]);
                }
                ((MasterPresenter)flowchartPresenter).EditBlock(str);
                blockContainsTextBox.ReadOnly = true;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            ((MasterPresenter)flowchartPresenter).RemoveBlock();
            DrawFlowchart();
        }

        private void toDatabaseButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.ToDataBase("");
        }

        private void toCodeButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.ToCode();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ((MasterViewChangesPresenter)flowchartPresenter).Apply("Name", "Reviewer");
        }

        private void declineButton_Click(object sender, EventArgs e)
        {
            ((MasterViewChangesPresenter)flowchartPresenter).Decline();
        }

        private void flowchartPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            flowchartPresenter.FlowchartMouseClick(e.X - flowchartPictureBox.Location.X, e.Y - -flowchartPictureBox.Location.Y, vScrollBar1.Value);

            if (flowchartPresenter.IsEdge(e.X, e.Y, vScrollBar1.Value) && flowchartPresenter.GetSelectedBlock() == -1)
            {                
                addBlockButton.Enabled = true;
            }
            else
            {
                addBlockButton.Enabled = false;
            }

            if (flowchartPresenter.GetSelectedBlock() != -1 && flowchartPresenter.IsSquareBlock(flowchartPresenter.GetSelectedBlock()))
            {
                editBlockButton.Enabled = true;
                removeButton.Enabled = true;
            }
            else
            {
                editBlockButton.Enabled = false;
                removeButton.Enabled = false;
            }

            DrawFlowchart();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.ToChooseFlowchart();
        }
                
        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            DrawFlowchart();
        }

        void DrawFlowchart()
        {
            Model.IFlowchart fc = flowchartPresenter.getFlowchart();
            Model.FlowchartDraw fcd = new Model.FlowchartDraw();
            flowchartPictureBox.BackgroundImage = fcd.Draw(fc.GetGraph(), vScrollBar1.Value, flowchartPresenter.GetSelectedBlock(), flowchartPresenter.GetSelectedEdge());
            flowchartPictureBox.Refresh();
        }

        internal void ShowBlockContent(IBlock block)
        {
            blockContainsTextBox.Text = "";
            if (block != null)
            {
                List<string> blockContent = block.GetListOfStrings();
                foreach (var str in blockContent)
                {
                    if (str.Contains("\t"))
                        blockContainsTextBox.Text += str.Substring(str.LastIndexOf("\t") + 1, str.Length - str.LastIndexOf("\t") - 1) + '\n';
                    else
                        blockContainsTextBox.Text += str + '\n';
                }
            }
        }
    }
}
