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
<<<<<<< HEAD
        string pathVar;
=======
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a

        private INewFlowchartPresenter flowchartPresenter;

        private void NewFlowchartView_Load(object sender, EventArgs e)
        {
            flowchartPresenter = new NewFlowchartPresenter();
        }

        private void browseFileButton_Click(object sender, EventArgs e)
        {
            if (browseFileOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
<<<<<<< HEAD
                pathVar = pathTextbox.Text = browseFileOpenFileDialog.FileName;

=======
                pathTextbox.Text = browseFileOpenFileDialog.FileName;
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

            MasterView masterView = new MasterView(flowchartNameInputTextbox.Text, 
                flowchartPresenter.GetLogin(), pathVar);
=======
            MasterView masterView = new MasterView();
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
            this.Hide();
            masterView.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView(flowchartPresenter.GetLogin());
=======
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView();
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
            this.Hide();
            chooseFlowchartView.Show();
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
