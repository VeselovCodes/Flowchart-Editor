using System;
using FlowchartEditorMVP.Model;

namespace FlowchartEditorMVP.View
{
    partial class MasterView
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
            this.codeTextbox = new System.Windows.Forms.TextBox();
            this.toCodeButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.editBlockButton = new System.Windows.Forms.Button();
            this.addBlockButton = new System.Windows.Forms.Button();
            this.flowchartPictureBox = new System.Windows.Forms.PictureBox();
            this.backButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.reviewsDataGridView = new System.Windows.Forms.DataGridView();
            this.loginColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewsHeaderPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.declineButton = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.actionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flowchartPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reviewsDataGridView)).BeginInit();
            this.reviewsHeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionsGroupBox
            // 
            this.actionsGroupBox.Controls.Add(this.blockContainsTextBox);
            this.actionsGroupBox.Controls.Add(this.toDatabaseButton);
            this.actionsGroupBox.Controls.Add(this.codeTextbox);
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
            this.blockContainsTextBox.Location = new System.Drawing.Point(6, 236);
            this.blockContainsTextBox.Name = "blockContainsTextBox";
            this.blockContainsTextBox.ReadOnly = true;
            this.blockContainsTextBox.Size = new System.Drawing.Size(152, 233);
            this.blockContainsTextBox.TabIndex = 10;
            this.blockContainsTextBox.Text = "";
            // 
            // toDatabaseButton
            // 
            this.toDatabaseButton.Location = new System.Drawing.Point(6, 475);
            this.toDatabaseButton.Name = "toDatabaseButton";
            this.toDatabaseButton.Size = new System.Drawing.Size(152, 60);
            this.toDatabaseButton.TabIndex = 7;
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
            this.backButton.Location = new System.Drawing.Point(342, 619);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(152, 60);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.reviewsDataGridView, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(678, 62);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(303, 550);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // reviewsDataGridView
            // 
            this.reviewsDataGridView.AllowUserToAddRows = false;
            this.reviewsDataGridView.AllowUserToResizeColumns = false;
            this.reviewsDataGridView.AllowUserToResizeRows = false;
            this.reviewsDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.reviewsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reviewsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reviewsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loginColumn,
            this.reviewColumn});
            this.reviewsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.reviewsDataGridView.Name = "reviewsDataGridView";
            this.reviewsDataGridView.Size = new System.Drawing.Size(297, 476);
            this.reviewsDataGridView.TabIndex = 0;
            this.reviewsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.reviewsDataGridView_CellDoubleClick);
            // 
            // loginColumn
            // 
            this.loginColumn.FillWeight = 101.5228F;
            this.loginColumn.HeaderText = "Login";
            this.loginColumn.Name = "loginColumn";
            // 
            // reviewColumn
            // 
            this.reviewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reviewColumn.FillWeight = 98.47716F;
            this.reviewColumn.HeaderText = "Review";
            this.reviewColumn.Name = "reviewColumn";
            // 
            // reviewsHeaderPanel
            // 
            this.reviewsHeaderPanel.Controls.Add(this.label1);
            this.reviewsHeaderPanel.Location = new System.Drawing.Point(678, 12);
            this.reviewsHeaderPanel.Name = "reviewsHeaderPanel";
            this.reviewsHeaderPanel.Size = new System.Drawing.Size(303, 47);
            this.reviewsHeaderPanel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reviews";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(678, 618);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(145, 60);
            this.applyButton.TabIndex = 7;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // declineButton
            // 
            this.declineButton.Location = new System.Drawing.Point(836, 618);
            this.declineButton.Name = "declineButton";
            this.declineButton.Size = new System.Drawing.Size(145, 60);
            this.declineButton.TabIndex = 7;
            this.declineButton.Text = "Decline";
            this.declineButton.UseVisualStyleBackColor = true;
            this.declineButton.Click += new System.EventHandler(this.declineButton_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(658, 12);
            this.vScrollBar1.Maximum = 1000;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 600);
            this.vScrollBar1.SmallChange = 2;
            this.vScrollBar1.TabIndex = 9;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // MasterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 691);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.reviewsHeaderPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.declineButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.flowchartPictureBox);
            this.Controls.Add(this.actionsGroupBox);
            this.Name = "MasterView";
            this.Text = "Flowchart Editor";
            this.Load += new System.EventHandler(this.MasterView_Load);
            this.actionsGroupBox.ResumeLayout(false);
            this.actionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flowchartPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reviewsDataGridView)).EndInit();
            this.reviewsHeaderPanel.ResumeLayout(false);
            this.reviewsHeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.GroupBox actionsGroupBox;
        private System.Windows.Forms.TextBox codeTextbox;
        private System.Windows.Forms.Button toCodeButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button editBlockButton;
        private System.Windows.Forms.Button addBlockButton;
        private System.Windows.Forms.PictureBox flowchartPictureBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView reviewsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewColumn;
        private System.Windows.Forms.Panel reviewsHeaderPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button declineButton;
        private System.Windows.Forms.Button toDatabaseButton;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.RichTextBox blockContainsTextBox;
    }
}