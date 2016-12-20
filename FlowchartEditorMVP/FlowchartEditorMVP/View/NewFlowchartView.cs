using FlowchartEditorMVP.Model;
using FlowchartEditorMVP.Presenter;
using System;
using System.Windows.Forms;

namespace FlowchartEditorMVP.View
{
    public partial class NewFlowchartView : Form , IView
    {
        internal NewFlowchartView(DataManagement data)
        {
            InitializeComponent();
            flowchartPresenter = new NewFlowchartPresenter(data, this);
            languageComboBox.SelectedIndex = 0;
        }
        string pathVar;

        string flowchartName;

        private INewFlowchartPresenter flowchartPresenter;

        private void NewFlowchartView_Load(object sender, EventArgs e)
        {
        }

        private void browseFileButton_Click(object sender, EventArgs e)
        {
            if (browseFileOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathVar = pathTextbox.Text = browseFileOpenFileDialog.FileName;

            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            try
            {
                flowchartPresenter.CreateNew(flowchartNameInputTextbox.Text, pathTextbox.Text, languageComboBox.Text);
            }
            catch (Exception exc)
            {
                excaptionLabel.Text = exc.Message;
            }
            
         //Do collection for choosing language    
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            flowchartPresenter.ToChooseFlowchart();
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
