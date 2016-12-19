using System;
using FlowchartEditorMVP.Model;

namespace FlowchartEditorMVP.View
{
    partial class FlowchartView
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
            this.actionsGroupBox = new System.Windows.Forms.GroupBox();
            this.blockContainsTextBox = new System.Windows.Forms.RichTextBox();
            this.toDatabaseButton = new System.Windows.Forms.Button();
            this.toCodeButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.editBlockButton = new System.Windows.Forms.Button();
            this.addBlockButton = new System.Windows.Forms.Button();
            this.flowchartPictureBox = new System.Windows.Forms.PictureBox();
            this.backButton = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.declineButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.commentTextBox = new System.Windows.Forms.RichTextBox();
            this.actionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flowchartPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // actionsGroupBox
            // 
            this.actionsGroupBox.Controls.Add(this.blockContainsTextBox);
            this.actionsGroupBox.Controls.Add(this.declineButton);
            this.actionsGroupBox.Controls.Add(this.toDatabaseButton);
            this.actionsGroupBox.Controls.Add(this.applyButton);
            this.actionsGroupBox.Controls.Add(this.toCodeButton);
            this.actionsGroupBox.Controls.Add(this.removeButton);
            this.actionsGroupBox.Controls.Add(this.editBlockButton);
            this.actionsGroupBox.Controls.Add(this.addBlockButton);
            this.actionsGroupBox.Location = new System.Drawing.Point(3, 6);
            this.actionsGroupBox.Name = "actionsGroupBox";
            this.actionsGroupBox.Size = new System.Drawing.Size(164, 607);
            this.actionsGroupBox.TabIndex = 3;
            this.actionsGroupBox.TabStop = false;
            this.actionsGroupBox.Text = "Actions";
            // 
            // blockContainsTextBox
            // 
            this.blockContainsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.blockContainsTextBox.Location = new System.Drawing.Point(6, 151);
            this.blockContainsTextBox.Name = "blockContainsTextBox";
            this.blockContainsTextBox.ReadOnly = true;
            this.blockContainsTextBox.Size = new System.Drawing.Size(152, 233);
            this.blockContainsTextBox.TabIndex = 10;
            this.blockContainsTextBox.Text = "";
            // 
            // toDatabaseButton
            // 
            this.toDatabaseButton.Location = new System.Drawing.Point(6, 390);
            this.toDatabaseButton.Name = "toDatabaseButton";
            this.toDatabaseButton.Size = new System.Drawing.Size(152, 60);
            this.toDatabaseButton.TabIndex = 7;
            this.toDatabaseButton.Text = "To Database";
            this.toDatabaseButton.UseVisualStyleBackColor = true;
            this.toDatabaseButton.Click += new System.EventHandler(this.toDatabaseButton_Click);
            // 
            // toCodeButton
            // 
            this.toCodeButton.Location = new System.Drawing.Point(6, 456);
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
            this.removeButton.Location = new System.Drawing.Point(6, 85);
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
            this.editBlockButton.Location = new System.Drawing.Point(88, 19);
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
            this.addBlockButton.Location = new System.Drawing.Point(6, 19);
            this.addBlockButton.Name = "addBlockButton";
            this.addBlockButton.Size = new System.Drawing.Size(70, 60);
            this.addBlockButton.TabIndex = 1;
            this.addBlockButton.Text = "Add block";
            this.addBlockButton.UseVisualStyleBackColor = true;
            this.addBlockButton.Click += new System.EventHandler(this.addBlockButton_Click);
            // 
            // flowchartPictureBox
            // 
            this.flowchartPictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowchartPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowchartPictureBox.Location = new System.Drawing.Point(172, 12);
            this.flowchartPictureBox.Name = "flowchartPictureBox";
            this.flowchartPictureBox.Size = new System.Drawing.Size(500, 600);
            this.flowchartPictureBox.TabIndex = 4;
            this.flowchartPictureBox.TabStop = false;
            this.flowchartPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flowchartPictureBox_MouseClick);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(9, 619);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(152, 66);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(675, 13);
            this.vScrollBar1.Maximum = 1000;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 600);
            this.vScrollBar1.SmallChange = 2;
            this.vScrollBar1.TabIndex = 9;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // declineButton
            // 
            this.declineButton.Location = new System.Drawing.Point(9, 558);
            this.declineButton.Name = "declineButton";
            this.declineButton.Size = new System.Drawing.Size(149, 30);
            this.declineButton.TabIndex = 7;
            this.declineButton.Text = "Decline";
            this.declineButton.UseVisualStyleBackColor = true;
            this.declineButton.Click += new System.EventHandler(this.declineButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(6, 522);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(152, 30);
            this.applyButton.TabIndex = 7;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // commentTextBox
            // 
            this.commentTextBox.Location = new System.Drawing.Point(173, 618);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(499, 67);
            this.commentTextBox.TabIndex = 10;
            this.commentTextBox.Text = "";
            // 
            // FlowchartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 691);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.flowchartPictureBox);
            this.Controls.Add(this.actionsGroupBox);
            this.Name = "FlowchartView";
            this.Text = "Flowchart Editor";
            this.actionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flowchartPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.GroupBox actionsGroupBox;
        private System.Windows.Forms.Button toCodeButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button editBlockButton;
        private System.Windows.Forms.Button addBlockButton;
        private System.Windows.Forms.PictureBox flowchartPictureBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button toDatabaseButton;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.RichTextBox blockContainsTextBox;
        private System.Windows.Forms.Button declineButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.RichTextBox commentTextBox;
    }
}