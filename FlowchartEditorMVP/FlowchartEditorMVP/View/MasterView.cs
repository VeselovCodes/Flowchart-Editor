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
    public partial class MasterView : Form , IView
    {
        private int xCoordsClick;
        private int yCoordsClick;
        private IFlowchartPresenter flowchartPresenter;

        internal MasterView(DataManagement data, string path, string name, string type_code)
        {            
            InitializeComponent();
            flowchartPresenter = new MasterPresenter(data, path, this, name, type_code);
        }
        internal MasterView(DataManagement data, string name)
        {
            InitializeComponent();
            flowchartPresenter = new MasterPresenter(data, this, name);
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

            vScrollBar1.Maximum = flowchartPresenter.GetScrollBarBValue();
            DrawFlowchart();
        }

        private void addBlockButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.AddBlock();
            DrawFlowchart();
            vScrollBar1.Maximum = flowchartPresenter.GetScrollBarBValue();
        }

        private void editBlockButton_Click(object sender, EventArgs e)
        {
            if (editBlockButton.Text == "Edit block")
            {
                blockContainsTextBox.BackColor = Color.White;
                editBlockButton.Text = "Save changes";
                //flowchartPresenter.EditBlock(codeTextbox.Text, id);
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
                flowchartPresenter.EditBlock(str);
                blockContainsTextBox.ReadOnly = true;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.RemoveBlock();

            DrawFlowchart();
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

            flowchartPresenter.FlowchartMouseClick(xCoordsClick - flowchartPictureBox.Location.X, yCoordsClick - -flowchartPictureBox.Location.Y, vScrollBar1.Value);

            if (flowchartPresenter.IsEdge(xCoordsClick, yCoordsClick, vScrollBar1.Value) && flowchartPresenter.GetSelectedBlock() == -1)
            {
                this.Text = flowchartPresenter.GetSelectedEdge()[0].ToString() + flowchartPresenter.GetSelectedEdge()[1].ToString();
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

        private void reviewsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            flowchartPresenter.LoadReviewedFlowchart(reviewsDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()
                , reviewsDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
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
