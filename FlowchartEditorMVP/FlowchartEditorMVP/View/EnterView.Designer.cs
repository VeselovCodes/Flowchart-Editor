namespace FlowchartEditorMVP
{
    partial class EnterView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginInputTextbox = new System.Windows.Forms.TextBox();
            this.passwordInputTextbox = new System.Windows.Forms.TextBox();
            this.loginInputLabel = new System.Windows.Forms.Label();
            this.passwordInputLabel = new System.Windows.Forms.Label();
            this.exceptionLabel = new System.Windows.Forms.Label();
            this.enterButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.loginHeaderLabel = new System.Windows.Forms.Label();
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
            // loginInputLabel
            // 
            this.loginInputLabel.AutoSize = true;
            this.loginInputLabel.Location = new System.Drawing.Point(265, 103);
            this.loginInputLabel.Name = "loginInputLabel";
            this.loginInputLabel.Size = new System.Drawing.Size(36, 13);
            this.loginInputLabel.TabIndex = 2;
            this.loginInputLabel.Text = "Login:";
            // 
            // passwordInputLabel
            // 
            this.passwordInputLabel.AutoSize = true;
            this.passwordInputLabel.Location = new System.Drawing.Point(245, 153);
            this.passwordInputLabel.Name = "passwordInputLabel";
            this.passwordInputLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordInputLabel.TabIndex = 3;
            this.passwordInputLabel.Text = "Password:";
            // 
            // exceptionLabel
            // 
            this.exceptionLabel.AutoSize = true;
            this.exceptionLabel.Location = new System.Drawing.Point(550, 205);
            this.exceptionLabel.Name = "exceptionLabel";
            this.exceptionLabel.Size = new System.Drawing.Size(0, 13);
            this.exceptionLabel.TabIndex = 4;
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(446, 200);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(74, 23);
            this.enterButton.TabIndex = 5;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(446, 250);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(74, 23);
            this.registerButton.TabIndex = 6;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // loginHeaderLabel
            // 
            this.loginHeaderLabel.AutoSize = true;
            this.loginHeaderLabel.Location = new System.Drawing.Point(432, 50);
            this.loginHeaderLabel.Name = "loginHeaderLabel";
            this.loginHeaderLabel.Size = new System.Drawing.Size(36, 13);
            this.loginHeaderLabel.TabIndex = 7;
            this.loginHeaderLabel.Text = "Log in";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 361);
            this.Controls.Add(this.loginHeaderLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.exceptionLabel);
            this.Controls.Add(this.passwordInputLabel);
            this.Controls.Add(this.loginInputLabel);
            this.Controls.Add(this.passwordInputTextbox);
            this.Controls.Add(this.loginInputTextbox);
            this.Name = "Form1";
            this.Text = "FlowchartEditor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginInputTextbox;
        private System.Windows.Forms.TextBox passwordInputTextbox;
        private System.Windows.Forms.Label loginInputLabel;
        private System.Windows.Forms.Label passwordInputLabel;
        private System.Windows.Forms.Label exceptionLabel;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label loginHeaderLabel;
    }
}

