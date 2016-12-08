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
    public partial class RegisterView : Form , IView
    {
<<<<<<< HEAD
        private IAccountPresenter presenter;
=======
        private IRegisterPresenter presenter;
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a

        public RegisterView()
        {
            InitializeComponent();
        }

        private void RegisterView_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            presenter = new AccountPresenter(this);
=======
            presenter = new RegisterPresenter();
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (passwordInputTextbox.Text == passwordRepeatInputTextbox.Text 
                && presenter.Register(loginInputTextbox.Text, passwordInputTextbox.Text))
            {                
                EnterView enterView = new EnterView();
                this.Hide();
                enterView.Show();
            }
            else exceptionLabel.Text = "Registration error";
            
=======
            if (passwordInputTextbox.Text == passwordRepeatInputTextbox.Text)
                presenter.Register(loginInputTextbox.Text, passwordInputTextbox.Text);
            else exceptionLabel.Text = "Incorrect repeated password";
            EnterView enterView = new EnterView();// Будет в ветке if
            this.Hide();// Будет в ветке if
            enterView.Show();// Будет в ветке if
>>>>>>> 723512b7e7e62caa86dea53a07175f6354214b4a
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            EnterView enterView = new EnterView();
            this.Hide();
            enterView.Show();
        }
    }
}
