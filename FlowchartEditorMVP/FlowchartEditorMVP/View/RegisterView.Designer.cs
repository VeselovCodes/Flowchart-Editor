namespace FlowchartEditorMVP.View
{
    partial class RegisterView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginInputTextbox = new System.Windows.Forms.TextBox();
            this.passwordInputTextbox = new System.Windows.Forms.TextBox();
            this.passwordRepeatInputTextbox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.loginInputLabel = new System.Windows.Forms.Label();
            this.passwordInputLabel = new System.Windows.Forms.Label();
            this.passwordRepeatInputLabel = new System.Windows.Forms.Label();
            this.exceptionLabel = new System.Windows.Forms.Label();
            this.registrationHeaderLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginInputTextbox
            // 
            this.loginInputTextbox.Location = new System.Drawing.Point(333, 100);
            this.loginInputTextbox.Name = "loginInputTextbox";
            this.loginInputTextbox.Size = new System.Drawing.Size(300, 20);
            this.loginInputTextbox.TabIndex = 0;
            // 
            // passwordInputTextbox
            // 
            this.passwordInputTextbox.Location = new System.Drawing.Point(333, 150);
            this.passwordInputTextbox.Name = "passwordInputTextbox";
            this.passwordInputTextbox.Size = new System.Drawing.Size(300, 20);
            this.passwordInputTextbox.TabIndex = 1;
            // 
            // passwordRepeatInputTextbox
            // 
            this.passwordRepeatInputTextbox.Location = new System.Drawing.Point(333, 200);
            this.passwordRepeatInputTextbox.Name = "passwordRepeatInputTextbox";
            this.passwordRepeatInputTextbox.Size = new System.Drawing.Size(300, 20);
            this.passwordRepeatInputTextbox.TabIndex = 2;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(333, 250);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 3;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(558, 250);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // loginInputLabel
            // 
            this.loginInputLabel.AutoSize = true;
            this.loginInputLabel.Location = new System.Drawing.Point(219, 103);
            this.loginInputLabel.Name = "loginInputLabel";
            this.loginInputLabel.Size = new System.Drawing.Size(83, 13);
            this.loginInputLabel.TabIndex = 5;
            this.loginInputLabel.Text = "Enter your login:";
            // 
            // passwordInputLabel
            // 
            this.passwordInputLabel.AutoSize = true;
            this.passwordInputLabel.Location = new System.Drawing.Point(201, 153);
            this.passwordInputLabel.Name = "passwordInputLabel";
            this.passwordInputLabel.Size = new System.Drawing.Size(101, 13);
            this.passwordInputLabel.TabIndex = 6;
            this.passwordInputLabel.Text = "Enter the password:";
            // 
            // passwordRepeatInputLabel
            // 
            this.passwordRepeatInputLabel.AutoSize = true;
            this.passwordRepeatInputLabel.Location = new System.Drawing.Point(191, 203);
            this.passwordRepeatInputLabel.Name = "passwordRepeatInputLabel";
            this.passwordRepeatInputLabel.Size = new System.Drawing.Size(111, 13);
            this.passwordRepeatInputLabel.TabIndex = 7;
            this.passwordRepeatInputLabel.Text = "Repeat the password:";
            // 
            // exceptionLabel
            // 
            this.exceptionLabel.AutoSize = true;
            this.exceptionLabel.Location = new System.Drawing.Point(384, 300);
            this.exceptionLabel.Name = "exceptionLabel";
            this.exceptionLabel.Size = new System.Drawing.Size(0, 13);
            this.exceptionLabel.TabIndex = 8;
            // 
            // registrationHeaderLabel
            // 
            this.registrationHeaderLabel.AutoSize = true;
            this.registrationHeaderLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.registrationHeaderLabel.Location = new System.Drawing.Point(406, 50);
            this.registrationHeaderLabel.Name = "registrationHeaderLabel";
            this.registrationHeaderLabel.Size = new System.Drawing.Size(63, 13);
            this.registrationHeaderLabel.TabIndex = 9;
            this.registrationHeaderLabel.Text = "Registration";
            // 
            // RegisterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 361);
            this.Controls.Add(this.registrationHeaderLabel);
            this.Controls.Add(this.exceptionLabel);
            this.Controls.Add(this.passwordRepeatInputLabel);
            this.Controls.Add(this.passwordInputLabel);
            this.Controls.Add(this.loginInputLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.passwordRepeatInputTextbox);
            this.Controls.Add(this.passwordInputTextbox);
            this.Controls.Add(this.loginInputTextbox);
            this.Name = "RegisterView";
            this.Text = "Flowchart Editor";
            this.Load += new System.EventHandler(this.RegisterView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginInputTextbox;
        private System.Windows.Forms.TextBox passwordInputTextbox;
        private System.Windows.Forms.TextBox passwordRepeatInputTextbox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label loginInputLabel;
        private System.Windows.Forms.Label passwordInputLabel;
        private System.Windows.Forms.Label passwordRepeatInputLabel;
        private System.Windows.Forms.Label exceptionLabel;
        private System.Windows.Forms.Label registrationHeaderLabel;
    }
}