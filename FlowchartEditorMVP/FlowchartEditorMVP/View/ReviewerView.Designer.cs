namespace FlowchartEditorMVP.View
{
    partial class ReviewerView
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
            this.flowchartPictureBox = new System.Windows.Forms.PictureBox();
            this.actionsGroupBox = new System.Windows.Forms.GroupBox();
            this.toDatabaseButton = new System.Windows.Forms.Button();
            this.codeTextbox = new System.Windows.Forms.TextBox();
            this.toCodeButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.editBlockButton = new System.Windows.Forms.Button();
            this.addBlockButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.commentLabel = new System.Windows.Forms.Label();
            this.commentRichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.flowchartPictureBox)).BeginInit();
            this.actionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowchartPictureBox
            // 
            this.flowchartPictureBox.Location = new System.Drawing.Point(172, 12);
            this.flowchartPictureBox.Name = "flowchartPictureBox";
            this.flowchartPictureBox.Size = new System.Drawing.Size(500, 600);
            this.flowchartPictureBox.TabIndex = 1;
            this.flowchartPictureBox.TabStop = false;
            this.flowchartPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flowchartPictureBox_MouseClick);
            // 
            // actionsGroupBox
            // 
            this.actionsGroupBox.Controls.Add(this.toDatabaseButton);
            this.actionsGroupBox.Controls.Add(this.codeTextbox);
            this.actionsGroupBox.Controls.Add(this.toCodeButton);
            this.actionsGroupBox.Controls.Add(this.removeButton);
            this.actionsGroupBox.Controls.Add(this.editBlockButton);
            this.actionsGroupBox.Controls.Add(this.addBlockButton);
            this.actionsGroupBox.Location = new System.Drawing.Point(3, 6);
            this.actionsGroupBox.Name = "actionsGroupBox";
            this.actionsGroupBox.Size = new System.Drawing.Size(164, 607);
            this.actionsGroupBox.TabIndex = 2;
            this.actionsGroupBox.TabStop = false;
            this.actionsGroupBox.Text = "Actions";
            // 
            // toDatabaseButton
            // 
            this.toDatabaseButton.Location = new System.Drawing.Point(6, 475);
            this.toDatabaseButton.Name = "toDatabaseButton";
            this.toDatabaseButton.Size = new System.Drawing.Size(152, 60);
            this.toDatabaseButton.TabIndex = 8;
            this.toDatabaseButton.Text = "To Database";
            this.toDatabaseButton.UseVisualStyleBackColor = true;
            this.toDatabaseButton.Click += new System.EventHandler(this.toDatabaseButton_Click);
            // 
            // codeTextbox
            // 
            this.codeTextbox.Enabled = false;
            this.codeTextbox.Location = new System.Drawing.Point(6, 144);
            this.codeTextbox.Name = "codeTextbox";
            this.codeTextbox.Size = new System.Drawing.Size(152, 20);
            this.codeTextbox.TabIndex = 6;
            // 
            // toCodeButton
            // 
            this.toCodeButton.Location = new System.Drawing.Point(6, 541);
            this.toCodeButton.Name = "toCodeButton";
            this.toCodeButton.Size = new System.Drawing.Size(152, 60);
            this.toCodeButton.TabIndex = 5;
            this.toCodeButton.Text = "To Code";
            this.toCodeButton.UseVisualStyleBackColor = true;
            this.toCodeButton.Click += new System.EventHandler(this.toCodeButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(6, 170);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(152, 60);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // editBlockButton
            // 
            this.editBlockButton.Enabled = false;
            this.editBlockButton.Location = new System.Drawing.Point(88, 78);
            this.editBlockButton.Name = "editBlockButton";
            this.editBlockButton.Size = new System.Drawing.Size(70, 60);
            this.editBlockButton.TabIndex = 2;
            this.editBlockButton.Text = "Edit block";
            this.editBlockButton.UseVisualStyleBackColor = true;
            this.editBlockButton.Click += new System.EventHandler(this.editBlockButton_Click);
            // 
            // addBlockButton
            // 
            this.addBlockButton.Enabled = false;
            this.addBlockButton.Location = new System.Drawing.Point(6, 78);
            this.addBlockButton.Name = "addBlockButton";
            this.addBlockButton.Size = new System.Drawing.Size(70, 60);
            this.addBlockButton.TabIndex = 1;
            this.addBlockButton.Text = "Add block";
            this.addBlockButton.UseVisualStyleBackColor = true;
            this.addBlockButton.Click += new System.EventHandler(this.addBlockButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(520, 618);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(152, 60);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(12, 616);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(51, 13);
            this.commentLabel.TabIndex = 7;
            this.commentLabel.Text = "Comment";
            // 
            // commentRichTextBox
            // 
            this.commentRichTextBox.Location = new System.Drawing.Point(69, 618);
            this.commentRichTextBox.Name = "commentRichTextBox";
            this.commentRichTextBox.Size = new System.Drawing.Size(445, 60);
            this.commentRichTextBox.TabIndex = 9;
            this.commentRichTextBox.Text = "";
            // 
            // ReviewerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 691);
            this.Controls.Add(this.commentRichTextBox);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.actionsGroupBox);
            this.Controls.Add(this.flowchartPictureBox);
            this.Name = "ReviewerView";
            this.Text = "Flowchart Editor";
            this.Load += new System.EventHandler(this.ReviewerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flowchartPictureBox)).EndInit();
            this.actionsGroupBox.ResumeLayout(false);
            this.actionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox flowchartPictureBox;
        private System.Windows.Forms.GroupBox actionsGroupBox;
        private System.Windows.Forms.Button editBlockButton;
        private System.Windows.Forms.Button addBlockButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button toCodeButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.RichTextBox commentRichTextBox;
        private System.Windows.Forms.TextBox codeTextbox;
        private System.Windows.Forms.Button toDatabaseButton;
    }
}