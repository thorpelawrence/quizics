namespace quizics
{
    partial class AddTextbookQuestionForm
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
            this.marksLabel = new System.Windows.Forms.Label();
            this.marksTextBox = new System.Windows.Forms.TextBox();
            this.answerLabel = new System.Windows.Forms.Label();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.addQuestionButton = new System.Windows.Forms.Button();
            this.fileLocationLabel = new System.Windows.Forms.Label();
            this.imageFileLocationBrowseButton = new System.Windows.Forms.Button();
            this.imageFileLocationTextBox = new System.Windows.Forms.TextBox();
            this.textbookNameLabel = new System.Windows.Forms.Label();
            this.textbookNameTextBox = new System.Windows.Forms.TextBox();
            this.pageNumberLabel = new System.Windows.Forms.Label();
            this.questionComboBox2 = new System.Windows.Forms.ComboBox();
            this.questionComboBox1 = new System.Windows.Forms.ComboBox();
            this.pageNumberUpDown = new System.Windows.Forms.NumericUpDown();
            this.questionNumberLabel = new System.Windows.Forms.Label();
            this.questionNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // marksLabel
            // 
            this.marksLabel.AutoSize = true;
            this.marksLabel.Location = new System.Drawing.Point(311, 61);
            this.marksLabel.Name = "marksLabel";
            this.marksLabel.Size = new System.Drawing.Size(45, 13);
            this.marksLabel.TabIndex = 32;
            this.marksLabel.Text = "# marks";
            // 
            // marksTextBox
            // 
            this.marksTextBox.Location = new System.Drawing.Point(311, 77);
            this.marksTextBox.Name = "marksTextBox";
            this.marksTextBox.Size = new System.Drawing.Size(126, 20);
            this.marksTextBox.TabIndex = 7;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Location = new System.Drawing.Point(311, 9);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(45, 13);
            this.answerLabel.TabIndex = 31;
            this.answerLabel.Text = "Answer:";
            // 
            // answerTextBox
            // 
            this.answerTextBox.Location = new System.Drawing.Point(311, 25);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(126, 20);
            this.answerTextBox.TabIndex = 6;
            // 
            // addQuestionButton
            // 
            this.addQuestionButton.Location = new System.Drawing.Point(347, 107);
            this.addQuestionButton.Name = "addQuestionButton";
            this.addQuestionButton.Size = new System.Drawing.Size(90, 23);
            this.addQuestionButton.TabIndex = 8;
            this.addQuestionButton.Text = "Add Question";
            this.addQuestionButton.UseVisualStyleBackColor = true;
            this.addQuestionButton.Click += new System.EventHandler(this.addQuestionButton_Click);
            // 
            // fileLocationLabel
            // 
            this.fileLocationLabel.AutoSize = true;
            this.fileLocationLabel.Location = new System.Drawing.Point(12, 9);
            this.fileLocationLabel.Name = "fileLocationLabel";
            this.fileLocationLabel.Size = new System.Drawing.Size(83, 13);
            this.fileLocationLabel.TabIndex = 28;
            this.fileLocationLabel.Text = "Image Location:";
            // 
            // imageFileLocationBrowseButton
            // 
            this.imageFileLocationBrowseButton.Location = new System.Drawing.Point(222, 24);
            this.imageFileLocationBrowseButton.Name = "imageFileLocationBrowseButton";
            this.imageFileLocationBrowseButton.Size = new System.Drawing.Size(60, 22);
            this.imageFileLocationBrowseButton.TabIndex = 1;
            this.imageFileLocationBrowseButton.Text = "Browse...";
            this.imageFileLocationBrowseButton.UseVisualStyleBackColor = true;
            this.imageFileLocationBrowseButton.Click += new System.EventHandler(this.imageFileLocationBrowseButton_Click);
            // 
            // imageFileLocationTextBox
            // 
            this.imageFileLocationTextBox.Location = new System.Drawing.Point(15, 25);
            this.imageFileLocationTextBox.Name = "imageFileLocationTextBox";
            this.imageFileLocationTextBox.Size = new System.Drawing.Size(201, 20);
            this.imageFileLocationTextBox.TabIndex = 0;
            // 
            // textbookNameLabel
            // 
            this.textbookNameLabel.AutoSize = true;
            this.textbookNameLabel.Location = new System.Drawing.Point(12, 96);
            this.textbookNameLabel.Name = "textbookNameLabel";
            this.textbookNameLabel.Size = new System.Drawing.Size(86, 13);
            this.textbookNameLabel.TabIndex = 33;
            this.textbookNameLabel.Text = "Textbook Name:";
            // 
            // textbookNameTextBox
            // 
            this.textbookNameTextBox.Location = new System.Drawing.Point(15, 112);
            this.textbookNameTextBox.MaxLength = 15;
            this.textbookNameTextBox.Name = "textbookNameTextBox";
            this.textbookNameTextBox.Size = new System.Drawing.Size(142, 20);
            this.textbookNameTextBox.TabIndex = 3;
            this.textbookNameTextBox.TextChanged += new System.EventHandler(this.questionName_Changed);
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.AutoSize = true;
            this.pageNumberLabel.Location = new System.Drawing.Point(12, 52);
            this.pageNumberLabel.Name = "pageNumberLabel";
            this.pageNumberLabel.Size = new System.Drawing.Size(45, 13);
            this.pageNumberLabel.TabIndex = 35;
            this.pageNumberLabel.Text = "Page #:";
            // 
            // questionComboBox2
            // 
            this.questionComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.questionComboBox2.FormattingEnabled = true;
            this.questionComboBox2.Items.AddRange(new object[] {
            "",
            "i",
            "ii",
            "iii",
            "iv",
            "v",
            "vi"});
            this.questionComboBox2.Location = new System.Drawing.Point(201, 68);
            this.questionComboBox2.Name = "questionComboBox2";
            this.questionComboBox2.Size = new System.Drawing.Size(35, 21);
            this.questionComboBox2.TabIndex = 5;
            this.questionComboBox2.TextChanged += new System.EventHandler(this.questionName_Changed);
            // 
            // questionComboBox1
            // 
            this.questionComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.questionComboBox1.FormattingEnabled = true;
            this.questionComboBox1.Items.AddRange(new object[] {
            "",
            "a",
            "b",
            "c",
            "d",
            "e"});
            this.questionComboBox1.Location = new System.Drawing.Point(165, 68);
            this.questionComboBox1.Name = "questionComboBox1";
            this.questionComboBox1.Size = new System.Drawing.Size(30, 21);
            this.questionComboBox1.TabIndex = 4;
            this.questionComboBox1.TextChanged += new System.EventHandler(this.questionName_Changed);
            // 
            // pageNumberUpDown
            // 
            this.pageNumberUpDown.Location = new System.Drawing.Point(15, 69);
            this.pageNumberUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.pageNumberUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pageNumberUpDown.Name = "pageNumberUpDown";
            this.pageNumberUpDown.Size = new System.Drawing.Size(44, 20);
            this.pageNumberUpDown.TabIndex = 2;
            this.pageNumberUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pageNumberUpDown.ValueChanged += new System.EventHandler(this.questionName_Changed);
            // 
            // questionNumberLabel
            // 
            this.questionNumberLabel.AutoSize = true;
            this.questionNumberLabel.Location = new System.Drawing.Point(166, 52);
            this.questionNumberLabel.Name = "questionNumberLabel";
            this.questionNumberLabel.Size = new System.Drawing.Size(79, 13);
            this.questionNumberLabel.TabIndex = 40;
            this.questionNumberLabel.Text = "Question Parts:";
            // 
            // questionNameLabel
            // 
            this.questionNameLabel.AutoSize = true;
            this.questionNameLabel.Location = new System.Drawing.Point(166, 96);
            this.questionNameLabel.Name = "questionNameLabel";
            this.questionNameLabel.Size = new System.Drawing.Size(83, 13);
            this.questionNameLabel.TabIndex = 41;
            this.questionNameLabel.Text = "Question Name:";
            // 
            // AddTextbookQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 142);
            this.Controls.Add(this.questionNameLabel);
            this.Controls.Add(this.questionNumberLabel);
            this.Controls.Add(this.questionComboBox2);
            this.Controls.Add(this.questionComboBox1);
            this.Controls.Add(this.pageNumberUpDown);
            this.Controls.Add(this.pageNumberLabel);
            this.Controls.Add(this.textbookNameTextBox);
            this.Controls.Add(this.textbookNameLabel);
            this.Controls.Add(this.marksLabel);
            this.Controls.Add(this.marksTextBox);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.addQuestionButton);
            this.Controls.Add(this.fileLocationLabel);
            this.Controls.Add(this.imageFileLocationBrowseButton);
            this.Controls.Add(this.imageFileLocationTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddTextbookQuestionForm";
            this.Text = "Add Textbook Question";
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label marksLabel;
        private System.Windows.Forms.TextBox marksTextBox;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.Button addQuestionButton;
        private System.Windows.Forms.Label fileLocationLabel;
        private System.Windows.Forms.Button imageFileLocationBrowseButton;
        private System.Windows.Forms.TextBox imageFileLocationTextBox;
        private System.Windows.Forms.Label textbookNameLabel;
        private System.Windows.Forms.TextBox textbookNameTextBox;
        private System.Windows.Forms.Label pageNumberLabel;
        private System.Windows.Forms.ComboBox questionComboBox2;
        private System.Windows.Forms.ComboBox questionComboBox1;
        private System.Windows.Forms.NumericUpDown pageNumberUpDown;
        private System.Windows.Forms.Label questionNumberLabel;
        private System.Windows.Forms.Label questionNameLabel;

    }
}