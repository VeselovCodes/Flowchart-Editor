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
    public partial class NewFlowchartView : Form , IView
    {
        public NewFlowchartView()
        {
            InitializeComponent();
        }

        private INewFlowchartPresenter flowchartPresenter;

        private void NewFlowchartView_Load(object sender, EventArgs e)
        {
            flowchartPresenter = new NewFlowchartPresenter();
        }

        private void browseFileButton_Click(object sender, EventArgs e)
        {
            if (browseFileOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathTextbox.Text = browseFileOpenFileDialog.FileName;
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            MasterView masterView = new MasterView();
            this.Hide();
            masterView.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView();
            this.Hide();
            chooseFlowchartView.Show();
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
