namespace quizics
{
    partial class SUVATQuizForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SUVATQuizForm));
            this.checkRandomQuestionsAnswersButton = new System.Windows.Forms.Button();
            this.numberOfRandomQuestions = new System.Windows.Forms.NumericUpDown();
            this.resetRandomQuestionsButton = new System.Windows.Forms.Button();
            this.randQuestionsPanel = new System.Windows.Forms.Panel();
            this.generateRandomQuestionsButton = new System.Windows.Forms.Button();
            this.suvatDialogButton = new System.Windows.Forms.Button();
            this.numberOfRandomQuestionsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRandomQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // checkRandomQuestionsAnswersButton
            // 
            this.checkRandomQuestionsAnswersButton.Location = new System.Drawing.Point(408, 12);
            this.checkRandomQuestionsAnswersButton.Name = "checkRandomQuestionsAnswersButton";
            this.checkRandomQuestionsAnswersButton.Size = new System.Drawing.Size(49, 23);
            this.checkRandomQuestionsAnswersButton.TabIndex = 2;
            this.checkRandomQuestionsAnswersButton.Text = "Check";
            this.checkRandomQuestionsAnswersButton.UseVisualStyleBackColor = true;
            this.checkRandomQuestionsAnswersButton.Visible = false;
            this.checkRandomQuestionsAnswersButton.Click += new System.EventHandler(this.checkRandomQuestionsAnswersButton_Click);
            // 
            // numberOfRandomQuestions
            // 
            this.numberOfRandomQuestions.Location = new System.Drawing.Point(103, 15);
            this.numberOfRandomQuestions.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numberOfRandomQuestions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfRandomQuestions.Name = "numberOfRandomQuestions";
            this.numberOfRandomQuestions.Size = new System.Drawing.Size(40, 20);
            this.numberOfRandomQuestions.TabIndex = 1;
            this.numberOfRandomQuestions.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // resetRandomQuestionsButton
            // 
            this.resetRandomQuestionsButton.Location = new System.Drawing.Point(463, 12);
            this.resetRandomQuestionsButton.Name = "resetRandomQuestionsButton";
            this.resetRandomQuestionsButton.Size = new System.Drawing.Size(49, 23);
            this.resetRandomQuestionsButton.TabIndex = 3;
            this.resetRandomQuestionsButton.Text = "Reset";
            this.resetRandomQuestionsButton.UseVisualStyleBackColor = true;
            this.resetRandomQuestionsButton.Visible = false;
            this.resetRandomQuestionsButton.Click += new System.EventHandler(this.resetRandomQuestionsButton_Click);
            // 
            // randQuestionsPanel
            // 
            this.randQuestionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.randQuestionsPanel.Location = new System.Drawing.Point(12, 41);
            this.randQuestionsPanel.Name = "randQuestionsPanel";
            this.randQuestionsPanel.Size = new System.Drawing.Size(645, 580);
            this.randQuestionsPanel.TabIndex = 9;
            // 
            // generateRandomQuestionsButton
            // 
            this.generateRandomQuestionsButton.Location = new System.Drawing.Point(12, 12);
            this.generateRandomQuestionsButton.Name = "generateRandomQuestionsButton";
            this.generateRandomQuestionsButton.Size = new System.Drawing.Size(85, 23);
            this.generateRandomQuestionsButton.TabIndex = 0;
            this.generateRandomQuestionsButton.Text = "Generate";
            this.generateRandomQuestionsButton.UseVisualStyleBackColor = true;
            this.generateRandomQuestionsButton.Click += new System.EventHandler(this.generateRandomQuestionsButton_Click);
            // 
            // suvatDialogButton
            // 
            this.suvatDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.suvatDialogButton.Location = new System.Drawing.Point(554, 12);
            this.suvatDialogButton.Name = "suvatDialogButton";
            this.suvatDialogButton.Size = new System.Drawing.Size(103, 23);
            this.suvatDialogButton.TabIndex = 4;
            this.suvatDialogButton.Text = "SUVAT equations";
            this.suvatDialogButton.UseVisualStyleBackColor = true;
            this.suvatDialogButton.Click += new System.EventHandler(this.suvatDialogButton_Click);
            // 
            // numberOfRandomQuestionsLabel
            // 
            this.numberOfRandomQuestionsLabel.AutoSize = true;
            this.numberOfRandomQuestionsLabel.Location = new System.Drawing.Point(150, 21);
            this.numberOfRandomQuestionsLabel.Name = "numberOfRandomQuestionsLabel";
            this.numberOfRandomQuestionsLabel.Size = new System.Drawing.Size(52, 13);
            this.numberOfRandomQuestionsLabel.TabIndex = 13;
            this.numberOfRandomQuestionsLabel.Text = "questions";
            // 
            // SUVATQuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 633);
            this.Controls.Add(this.numberOfRandomQuestionsLabel);
            this.Controls.Add(this.checkRandomQuestionsAnswersButton);
            this.Controls.Add(this.numberOfRandomQuestions);
            this.Controls.Add(this.resetRandomQuestionsButton);
            this.Controls.Add(this.randQuestionsPanel);
            this.Controls.Add(this.generateRandomQuestionsButton);
            this.Controls.Add(this.suvatDialogButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SUVATQuizForm";
            this.Text = "SUVAT Quiz";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRandomQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button checkRandomQuestionsAnswersButton;
        public System.Windows.Forms.NumericUpDown numberOfRandomQuestions;
        public System.Windows.Forms.Button resetRandomQuestionsButton;
        public System.Windows.Forms.Panel randQuestionsPanel;
        private System.Windows.Forms.Button generateRandomQuestionsButton;
        private System.Windows.Forms.Button suvatDialogButton;
        private System.Windows.Forms.Label numberOfRandomQuestionsLabel;
    }
}