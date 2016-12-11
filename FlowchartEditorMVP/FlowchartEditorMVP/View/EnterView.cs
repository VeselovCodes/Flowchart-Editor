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
    public partial class EnterView : Form , IAccountView
    {
        private IAccountPresenter presenter;

        public EnterView()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {            
            try
            {
                presenter.Login(loginInputTextbox.Text, passwordInputTextbox.Text);                
            } catch(Exception exc)
            {
                exceptionLabel.Text = exc.Message;
            }            
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
