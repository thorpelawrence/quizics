namespace quizics
{
    partial class AddExamQuestionForm
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
            this.imageFileLocationTextBox = new System.Windows.Forms.TextBox();
            this.imageFileLocationBrowseButton = new System.Windows.Forms.Button();
            this.fileLocationLabel = new System.Windows.Forms.Label();
            this.paperLabel = new System.Windows.Forms.Label();
            this.questionLabel = new System.Windows.Forms.Label();
            this.questionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.questionComboBox1 = new System.Windows.Forms.ComboBox();
            this.questionComboBox2 = new System.Windows.Forms.ComboBox();
            this.questionComboBox3 = new System.Windows.Forms.ComboBox();
            this.questionNameLabel = new System.Windows.Forms.Label();
            this.addQuestionButton = new System.Windows.Forms.Button();
            this.marksLabel = new System.Windows.Forms.Label();
            this.marksTextBox = new System.Windows.Forms.TextBox();
            this.answerLabel = new System.Windows.Forms.Label();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.questionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // imageFileLocationTextBox
            // 
            this.imageFileLocationTextBox.Location = new System.Drawing.Point(12, 25);
            this.imageFileLocationTextBox.Name = "imageFileLocationTextBox";
            this.imageFileLocationTextBox.Size = new System.Drawing.Size(201, 20);
            this.imageFileLocationTextBox.TabIndex = 0;
            this.imageFileLocationTextBox.TextChanged += new System.EventHandler(this.questionName_Changed);
            // 
            // imageFileLocationBrowseButton
            // 
            this.imageFileLocationBrowseButton.Location = new System.Drawing.Point(219, 24);
            this.imageFileLocationBrowseButton.Name = "imageFileLocationBrowseButton";
            this.imageFileLocationBrowseButton.Size = new System.Drawing.Size(60, 22);
            this.imageFileLocationBrowseButton.TabIndex = 1;
            this.imageFileLocationBrowseButton.Text = "Browse...";
            this.imageFileLocationBrowseButton.UseVisualStyleBackColor = true;
            this.imageFileLocationBrowseButton.Click += new System.EventHandler(this.imageFileLocationBrowseButton_Click);
            // 
            // fileLocationLabel
            // 
            this.fileLocationLabel.AutoSize = true;
            this.fileLocationLabel.Location = new System.Drawing.Point(9, 9);
            this.fileLocationLabel.Name = "fileLocationLabel";
            this.fileLocationLabel.Size = new System.Drawing.Size(83, 13);
            this.fileLocationLabel.TabIndex = 9;
            this.fileLocationLabel.Text = "Image Location:";
            // 
            // paperLabel
            // 
            this.paperLabel.AutoSize = true;
            this.paperLabel.Location = new System.Drawing.Point(9, 54);
            this.paperLabel.Name = "paperLabel";
            this.paperLabel.Size = new System.Drawing.Size(38, 13);
            this.paperLabel.TabIndex = 4;
            this.paperLabel.Text = "Paper:";
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(9, 80);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(52, 13);
            this.questionLabel.TabIndex = 5;
            this.questionLabel.Text = "Question:";
            // 
            // questionNumericUpDown
            // 
            this.questionNumericUpDown.Location = new System.Drawing.Point(70, 77);
            this.questionNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.questionNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.questionNumericUpDown.Name = "questionNumericUpDown";
            this.questionNumericUpDown.Size = new System.Drawing.Size(44, 20);
            this.questionNumericUpDown.TabIndex = 4;
            this.questionNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.questionNumericUpDown.ValueChanged += new System.EventHandler(this.questionName_Changed);
            // 
            // questionComboBox1
            // 
            this.questionComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.questionComboBox1.FormattingEnabled = true;
            this.questionComboBox1.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e"});
            this.questionComboBox1.Location = new System.Drawing.Point(120, 76);
            this.questionComboBox1.Name = "questionComboBox1";
            this.questionComboBox1.Size = new System.Drawing.Size(30, 21);
            this.questionComboBox1.TabIndex = 5;
            this.questionComboBox1.TextChanged += new System.EventHandler(this.questionName_Changed);
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
            this.questionComboBox2.Location = new System.Drawing.Point(156, 76);
            this.questionComboBox2.Name = "questionComboBox2";
            this.questionComboBox2.Size = new System.Drawing.Size(33, 21);
            this.questionComboBox2.TabIndex = 6;
            this.questionComboBox2.TextChanged += new System.EventHandler(this.questionName_Changed);
            // 
            // questionComboBox3
            // 
            this.questionComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.questionComboBox3.FormattingEnabled = true;
            this.questionComboBox3.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4"});
            this.questionComboBox3.Location = new System.Drawing.Point(195, 76);
            this.questionComboBox3.Name = "questionComboBox3";
            this.questionComboBox3.Size = new System.Drawing.Size(30, 21);
            this.questionComboBox3.TabIndex = 7;
            this.questionComboBox3.TextChanged += new System.EventHandler(this.questionName_Changed);
            // 
            // questionNameLabel
            // 
            this.questionNameLabel.AutoSize = true;
            this.questionNameLabel.Location = new System.Drawing.Point(67, 109);
            this.questionNameLabel.Name = "questionNameLabel";
            this.questionNameLabel.Size = new System.Drawing.Size(83, 13);
            this.questionNameLabel.TabIndex = 10;
            this.questionNameLabel.Text = "Question Name:";
            // 
            // addQuestionButton
            // 
            this.addQuestionButton.Location = new System.Drawing.Point(344, 106);
            this.addQuestionButton.Name = "addQuestionButton";
            this.addQuestionButton.Size = new System.Drawing.Size(90, 23);
            this.addQuestionButton.TabIndex = 10;
            this.addQuestionButton.Text = "Add Question";
            this.addQuestionButton.UseVisualStyleBackColor = true;
            this.addQuestionButton.Click += new System.EventHandler(this.addQuestionButton_Click);
            // 
            // marksLabel
            // 
            this.marksLabel.AutoSize = true;
            this.marksLabel.Location = new System.Drawing.Point(308, 61);
            this.marksLabel.Name = "marksLabel";
            this.marksLabel.Size = new System.Drawing.Size(45, 13);
            this.marksLabel.TabIndex = 15;
            this.marksLabel.Text = "# marks";
            // 
            // marksTextBox
            // 
            this.marksTextBox.Location = new System.Drawing.Point(308, 77);
            this.marksTextBox.Name = "marksTextBox";
            this.marksTextBox.Size = new System.Drawing.Size(126, 20);
            this.marksTextBox.TabIndex = 9;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Location = new System.Drawing.Point(308, 9);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(45, 13);
            this.answerLabel.TabIndex = 13;
            this.answerLabel.Text = "Answer:";
            // 
            // answerTextBox
            // 
            this.answerTextBox.Location = new System.Drawing.Point(308, 25);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(126, 20);
            this.answerTextBox.TabIndex = 8;
            // 
            // yearNumericUpDown
            // 
            this.yearNumericUpDown.Location = new System.Drawing.Point(120, 50);
            this.yearNumericUpDown.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.yearNumericUpDown.Minimum = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            this.yearNumericUpDown.Name = "yearNumericUpDown";
            this.yearNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.yearNumericUpDown.TabIndex = 3;
            this.yearNumericUpDown.Value = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            this.yearNumericUpDown.ValueChanged += new System.EventHandler(this.questionName_Changed);
            // 
            // monthComboBox
            // 
            this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Items.AddRange(new object[] {
            "Jan",
            "Jun"});
            this.monthComboBox.Location = new System.Drawing.Point(70, 50);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(44, 21);
            this.monthComboBox.TabIndex = 2;
            this.monthComboBox.TextChanged += new System.EventHandler(this.questionName_Changed);
            // 
            // AddExamQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 142);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.yearNumericUpDown);
            this.Controls.Add(this.marksLabel);
            this.Controls.Add(this.marksTextBox);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.addQuestionButton);
            this.Controls.Add(this.questionNameLabel);
            this.Controls.Add(this.questionComboBox3);
            this.Controls.Add(this.questionComboBox2);
            this.Controls.Add(this.questionComboBox1);
            this.Controls.Add(this.questionNumericUpDown);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.paperLabel);
            this.Controls.Add(this.fileLocationLabel);
            this.Controls.Add(this.imageFileLocationBrowseButton);
            this.Controls.Add(this.imageFileLocationTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "AddExamQuestionForm";
            this.Text = "Add Exam Question";
            ((System.ComponentModel.ISupportInitialize)(this.questionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox imageFileLocationTextBox;
        private System.Windows.Forms.Button imageFileLocationBrowseButton;
        private System.Windows.Forms.Label fileLocationLabel;
        private System.Windows.Forms.Label paperLabel;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.NumericUpDown questionNumericUpDown;
        private System.Windows.Forms.ComboBox questionComboBox1;
        private System.Windows.Forms.ComboBox questionComboBox2;
        private System.Windows.Forms.ComboBox questionComboBox3;
        private System.Windows.Forms.Label questionNameLabel;
        private System.Windows.Forms.Button addQuestionButton;
        private System.Windows.Forms.Label marksLabel;
        private System.Windows.Forms.TextBox marksTextBox;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.NumericUpDown yearNumericUpDown;
        private System.Windows.Forms.ComboBox monthComboBox;
    }
}