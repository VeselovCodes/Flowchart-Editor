namespace FlowchartEditorMVP.View
{
    partial class ChooseFlowchartView
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
            this.flowchartDataGridView = new System.Windows.Forms.DataGridView();
            this.flowchartColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openButton = new System.Windows.Forms.Button();
            this.createNewButton = new System.Windows.Forms.Button();
            this.changeUserButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.flowchartDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // flowchartDataGridView
            // 
            this.flowchartDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.flowchartDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flowchartDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flowchartDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flowchartColumn,
            this.loginColumn});
            this.flowchartDataGridView.Location = new System.Drawing.Point(300, 50);
            this.flowchartDataGridView.Name = "flowchartDataGridView";
            this.flowchartDataGridView.Size = new System.Drawing.Size(400, 600);
            this.flowchartDataGridView.TabIndex = 0;
            // 
            // flowchartColumn
            // 
            this.flowchartColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.flowchartColumn.HeaderText = "Flowchart";
            this.flowchartColumn.Name = "flowchartColumn";
            // 
            // loginColumn
            // 
            this.loginColumn.HeaderText = "Login";
            this.loginColumn.Name = "loginColumn";
            this.loginColumn.Width = 150;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(715, 50);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(122, 43);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // createNewButton
            // 
            this.createNewButton.Location = new System.Drawing.Point(849, 50);
            this.createNewButton.Name = "createNewButton";
            this.createNewButton.Size = new System.Drawing.Size(122, 43);
            this.createNewButton.TabIndex = 1;
            this.createNewButton.Text = "Create new";
            this.createNewButton.UseVisualStyleBackColor = true;
            this.createNewButton.Click += new System.EventHandler(this.createNewButton_Click);
            // 
            // changeUserButton
            // 
            this.changeUserButton.Location = new System.Drawing.Point(84, 50);
            this.changeUserButton.Name = "changeUserButton";
            this.changeUserButton.Size = new System.Drawing.Size(122, 43);
            this.changeUserButton.TabIndex = 1;
            this.changeUserButton.Text = "Change user";
            this.changeUserButton.UseVisualStyleBackColor = true;
            this.changeUserButton.Click += new System.EventHandler(this.changeUserButton_Click);
            // 
            // ChooseFlowchartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 741);
            this.Controls.Add(this.createNewButton);
            this.Controls.Add(this.changeUserButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.flowchartDataGridView);
            this.Name = "ChooseFlowchartView";
            this.Text = "Flowchart Editor";
            this.Load += new System.EventHandler(this.ChooseFlowchartView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flowchartDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView flowchartDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn flowchartColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginColumn;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button createNewButton;
        private System.Windows.Forms.Button changeUserButton;
    }
}