namespace quizics
{
    partial class UserProgressForm
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
            this.totalMarksLabel = new System.Windows.Forms.Label();
            this.userProgressDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.userProgressDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // totalMarksLabel
            // 
            this.totalMarksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalMarksLabel.AutoSize = true;
            this.totalMarksLabel.Location = new System.Drawing.Point(454, 506);
            this.totalMarksLabel.Name = "totalMarksLabel";
            this.totalMarksLabel.Size = new System.Drawing.Size(69, 13);
            this.totalMarksLabel.TabIndex = 1;
            this.totalMarksLabel.Text = "Total Marks: ";
            // 
            // userProgressDataGridView
            // 
            this.userProgressDataGridView.AllowUserToAddRows = false;
            this.userProgressDataGridView.AllowUserToDeleteRows = false;
            this.userProgressDataGridView.AllowUserToResizeRows = false;
            this.userProgressDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userProgressDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userProgressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.userProgressDataGridView.Location = new System.Drawing.Point(13, 13);
            this.userProgressDataGridView.Name = "userProgressDataGridView";
            this.userProgressDataGridView.ReadOnly = true;
            this.userProgressDataGridView.RowHeadersVisible = false;
            this.userProgressDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userProgressDataGridView.Size = new System.Drawing.Size(563, 485);
            this.userProgressDataGridView.TabIndex = 0;
            // 
            // UserProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 528);
            this.Controls.Add(this.totalMarksLabel);
            this.Controls.Add(this.userProgressDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(410, 250);
            this.Name = "UserProgressForm";
            this.Text = "View Progress";
            this.Load += new System.EventHandler(this.UserProgressForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userProgressDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label totalMarksLabel;
        private System.Windows.Forms.DataGridView userProgressDataGridView;
    }
}