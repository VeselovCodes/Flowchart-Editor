namespace FlowchartEditorMVP.View
{
    partial class NewFlowchartView
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
            this.flowchartNameLabel = new System.Windows.Forms.Label();
            this.flowchartNameInputTextbox = new System.Windows.Forms.TextBox();
            this.browseFileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.browseFileButton = new System.Windows.Forms.Button();
            this.languageLabel = new System.Windows.Forms.Label();
            this.pathTextbox = new System.Windows.Forms.TextBox();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.createButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowchartNameLabel
            // 
            this.flowchartNameLabel.AutoSize = true;
            this.flowchartNameLabel.Location = new System.Drawing.Point(248, 78);
            this.flowchartNameLabel.Name = "flowchartNameLabel";
            this.flowchartNameLabel.Size = new System.Drawing.Size(88, 13);
            this.flowchartNameLabel.TabIndex = 0;
            this.flowchartNameLabel.Text = "Flowchart name: ";
            // 
            // flowchartNameInputTextbox
            // 
            this.flowchartNameInputTextbox.Location = new System.Drawing.Point(368, 75);
            this.flowchartNameInputTextbox.Name = "flowchartNameInputTextbox";
            this.flowchartNameInputTextbox.Size = new System.Drawing.Size(250, 20);
            this.flowchartNameInputTextbox.TabIndex = 1;
            // 
            // browseFileButton
            // 
            this.browseFileButton.Location = new System.Drawing.Point(251, 126);
            this.browseFileButton.Name = "browseFileButton";
            this.browseFileButton.Size = new System.Drawing.Size(75, 23);
            this.browseFileButton.TabIndex = 2;
            this.browseFileButton.Text = "Browse file";
            this.browseFileButton.UseVisualStyleBackColor = true;
            this.browseFileButton.Click += new System.EventHandler(this.browseFileButton_Click);
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(248, 181);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(58, 13);
            this.languageLabel.TabIndex = 3;
            this.languageLabel.Text = "Language:";
            // 
            // pathTextbox
            // 
            this.pathTextbox.Location = new System.Drawing.Point(368, 128);
            this.pathTextbox.Name = "pathTextbox";
            this.pathTextbox.Size = new System.Drawing.Size(250, 20);
            this.pathTextbox.TabIndex = 1;
            // 
            // languageComboBox
            // 
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Location = new System.Drawing.Point(368, 178);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(250, 21);
            this.languageComboBox.TabIndex = 4;
            this.languageComboBox.SelectedIndexChanged += new System.EventHandler(this.languageComboBox_SelectedIndexChanged);
            // 
            // createButton
            // 
            this.createButton.Enabled = false;
            this.createButton.Location = new System.Drawing.Point(453, 233);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 2;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(453, 304);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // NewFlowchartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 361);
            this.Controls.Add(this.languageComboBox);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.browseFileButton);
            this.Controls.Add(this.pathTextbox);
            this.Controls.Add(this.flowchartNameInputTextbox);
            this.Controls.Add(this.flowchartNameLabel);
            this.Name = "NewFlowchartView";
            this.Text = "Flowchart Editor";
            this.Load += new System.EventHandler(this.NewFlowchartView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label flowchartNameLabel;
        private System.Windows.Forms.TextBox flowchartNameInputTextbox;
        private System.Windows.Forms.OpenFileDialog browseFileOpenFileDialog;
        private System.Windows.Forms.Button browseFileButton;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.TextBox pathTextbox;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button backButton;
    }
}