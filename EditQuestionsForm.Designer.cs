namespace quizics
{
    partial class EditQuestionsForm
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
            this.addQuestionButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.questionDataGridView = new System.Windows.Forms.DataGridView();
            this.viewQuestionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.questionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addQuestionButton
            // 
            this.addQuestionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addQuestionButton.Location = new System.Drawing.Point(12, 277);
            this.addQuestionButton.Name = "addQuestionButton";
            this.addQuestionButton.Size = new System.Drawing.Size(91, 23);
            this.addQuestionButton.TabIndex = 1;
            this.addQuestionButton.Text = "Add Question";
            this.addQuestionButton.UseVisualStyleBackColor = true;
            this.addQuestionButton.Click += new System.EventHandler(this.addQuestionButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(330, 277);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(112, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete Selected";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // questionDataGridView
            // 
            this.questionDataGridView.AllowUserToAddRows = false;
            this.questionDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.questionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionDataGridView.Location = new System.Drawing.Point(12, 12);
            this.questionDataGridView.MultiSelect = false;
            this.questionDataGridView.Name = "questionDataGridView";
            this.questionDataGridView.RowHeadersVisible = false;
            this.questionDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.questionDataGridView.Size = new System.Drawing.Size(430, 259);
            this.questionDataGridView.TabIndex = 0;
            this.questionDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.questionDataGridView_CellValueChanged);
            // 
            // viewQuestionButton
            // 
            this.viewQuestionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewQuestionButton.Location = new System.Drawing.Point(109, 277);
            this.viewQuestionButton.Name = "viewQuestionButton";
            this.viewQuestionButton.Size = new System.Drawing.Size(99, 23);
            this.viewQuestionButton.TabIndex = 3;
            this.viewQuestionButton.Text = "View Question";
            this.viewQuestionButton.UseVisualStyleBackColor = true;
            this.viewQuestionButton.Click += new System.EventHandler(this.viewQuestionButton_Click);
            // 
            // EditQuestionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 312);
            this.Controls.Add(this.viewQuestionButton);
            this.Controls.Add(this.addQuestionButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.questionDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(350, 250);
            this.Name = "EditQuestionsForm";
            this.Text = "View/Edit Questions";
            ((System.ComponentModel.ISupportInitialize)(this.questionDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addQuestionButton;
        public System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView questionDataGridView;
        private System.Windows.Forms.Button viewQuestionButton;
    }
}