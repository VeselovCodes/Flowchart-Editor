using FlowchartEditorMVP.Presenter;
using FlowchartEditorMVP.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowchartEditorMVP
{
    public partial class EnterView : Form , IView
    {
        private IAccountPresenter presenter;

        public EnterView()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            /*if (presenter.Login(loginInputTextbox.Text, passwordInputTextbox.Text))
            {
                this.Hide();
                ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView();
                chooseFlowchartView.Show();
            }*/
            this.Hide();
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView(loginInputTextbox.Text);
            chooseFlowchartView.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            presenter = new AccountPresenter(this);
        }       


        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterView registerView = new RegisterView();
            this.Hide();
            registerView.Show();
        }
    }
}
