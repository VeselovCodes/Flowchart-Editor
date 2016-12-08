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
        private IRegisterPresenter presenter;

        public RegisterView()
        {
            InitializeComponent();
        }

        private void RegisterView_Load(object sender, EventArgs e)
        {
            presenter = new RegisterPresenter();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (passwordInputTextbox.Text == passwordRepeatInputTextbox.Text)
                presenter.Register(loginInputTextbox.Text, passwordInputTextbox.Text);
            else exceptionLabel.Text = "Incorrect repeated password";
            EnterView enterView = new EnterView();// Будет в ветке if
            this.Hide();// Будет в ветке if
            enterView.Show();// Будет в ветке if
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            EnterView enterView = new EnterView();
            this.Hide();
            enterView.Show();
        }
    }
}
