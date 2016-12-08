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
<<<<<<< HEAD
        private IAccountPresenter presenter;
=======
        private IEnterPresenter presenter;
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a

        public EnterView()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            /*if (presenter.Login(loginInputTextbox.Text, passwordInputTextbox.Text))
            {
                this.Hide();
                ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView();
                chooseFlowchartView.Show();
            }*/
            this.Hide();
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView(loginInputTextbox.Text);
=======
            presenter.Login(loginInputTextbox.Text, passwordInputTextbox.Text);
            ChooseFlowchartView chooseFlowchartView = new ChooseFlowchartView();
            this.Hide();
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
            chooseFlowchartView.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            presenter = new AccountPresenter(this);
=======
            presenter = new EnterPresenter(this);
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
        }       


        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterView registerView = new RegisterView();
            this.Hide();
            registerView.Show();
        }
    }
}
