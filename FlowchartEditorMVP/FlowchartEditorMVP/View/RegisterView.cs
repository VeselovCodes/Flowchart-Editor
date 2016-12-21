using FlowchartEditorMVP.Presenter;
using System;
using System.Windows.Forms;

namespace FlowchartEditorMVP.View
{
    public partial class RegisterView : Form , IAccountView
    {
        private IAccountPresenter presenter;

        public RegisterView()
        {
            InitializeComponent();
        }

        private void RegisterView_Load(object sender, EventArgs e)
        {
            presenter = new AccountPresenter(this);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                presenter.Register(loginInputTextbox.Text, passwordInputTextbox.Text, passwordRepeatInputTextbox.Text);
                
            }
            catch (Exception exc)
            {
                exceptionLabel.Text = exc.Message;
            }                   
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            EnterView enterView = new EnterView();
            this.Hide();
            enterView.Show();
        }
    }
}