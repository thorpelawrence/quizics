namespace quizics
{
    partial class QuizForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.questionImageDisplay = new System.Windows.Forms.PictureBox();
            this.questionNameLabel = new System.Windows.Forms.Label();
            this.questionIndexLabel = new System.Windows.Forms.Label();
            this.workingAreaColorLabel = new System.Windows.Forms.Label();
            this.penSizeLabel = new System.Windows.Forms.Label();
            this.marksLabel = new System.Windows.Forms.Label();
            this.backgroundColorButton = new System.Windows.Forms.Button();
            this.penSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.workingAreaBox = new System.Windows.Forms.PictureBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.checkAnswerButton = new System.Windows.Forms.Button();
            this.clearWorkingAreaButton = new System.Windows.Forms.Button();
            this.penColorButton = new System.Windows.Forms.Button();
            this.nextQuestionButton = new System.Windows.Forms.Button();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionImageDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workingAreaBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel1.Controls.Add(this.questionImageDisplay);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.Controls.Add(this.questionNameLabel);
            this.splitContainer.Panel2.Controls.Add(this.questionIndexLabel);
            this.splitContainer.Panel2.Controls.Add(this.workingAreaColorLabel);
            this.splitContainer.Panel2.Controls.Add(this.penSizeLabel);
            this.splitContainer.Panel2.Controls.Add(this.marksLabel);
            this.splitContainer.Panel2.Controls.Add(this.backgroundColorButton);
            this.splitContainer.Panel2.Controls.Add(this.penSizeUpDown);
            this.splitContainer.Panel2.Controls.Add(this.workingAreaBox);
            this.splitContainer.Panel2.Controls.Add(this.timerLabel);
            this.splitContainer.Panel2.Controls.Add(this.checkAnswerButton);
            this.splitContainer.Panel2.Controls.Add(this.clearWorkingAreaButton);
            this.splitContainer.Panel2.Controls.Add(this.penColorButton);
            this.splitContainer.Panel2.Controls.Add(this.nextQuestionButton);
            this.splitContainer.Panel2.Controls.Add(this.answerTextBox);
            this.splitContainer.Panel2MinSize = 210;
            this.splitContainer.Size = new System.Drawing.Size(607, 581);
            this.splitContainer.SplitterDistance = 363;
            this.splitContainer.TabIndex = 1;
            // 
            // questionImageDisplay
            // 
            this.questionImageDisplay.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.questionImageDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionImageDisplay.Location = new System.Drawing.Point(0, 0);
            this.questionImageDisplay.Name = "questionImageDisplay";
            this.questionImageDisplay.Size = new System.Drawing.Size(605, 361);
            this.questionImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.questionImageDisplay.TabIndex = 0;
            this.questionImageDisplay.TabStop = false;
            this.questionImageDisplay.Click += new System.EventHandler(this.questionImageDisplay_Click);
            // 
            // questionNameLabel
            // 
            this.questionNameLabel.AutoSize = true;
            this.questionNameLabel.Location = new System.Drawing.Point(4, 4);
            this.questionNameLabel.Name = "questionNameLabel";
            this.questionNameLabel.Size = new System.Drawing.Size(75, 13);
            this.questionNameLabel.TabIndex = 15;
            this.questionNameLabel.Text = "questionName";
            // 
            // questionIndexLabel
            // 
            this.questionIndexLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.questionIndexLabel.AutoSize = true;
            this.questionIndexLabel.Location = new System.Drawing.Point(500, 103);
            this.questionIndexLabel.Name = "questionIndexLabel";
            this.questionIndexLabel.Size = new System.Drawing.Size(73, 13);
            this.questionIndexLabel.TabIndex = 14;
            this.questionIndexLabel.Text = "questionIndex";
            // 
            // workingAreaColorLabel
            // 
            this.workingAreaColorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.workingAreaColorLabel.AutoSize = true;
            this.workingAreaColorLabel.Location = new System.Drawing.Point(497, 7);
            this.workingAreaColorLabel.Name = "workingAreaColorLabel";
            this.workingAreaColorLabel.Size = new System.Drawing.Size(107, 13);
            this.workingAreaColorLabel.TabIndex = 13;
            this.workingAreaColorLabel.Text = "Working Area Colors:";
            // 
            // penSizeLabel
            // 
            this.penSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.penSizeLabel.AutoSize = true;
            this.penSizeLabel.Location = new System.Drawing.Point(497, 54);
            this.penSizeLabel.Name = "penSizeLabel";
            this.penSizeLabel.Size = new System.Drawing.Size(52, 13);
            this.penSizeLabel.TabIndex = 12;
            this.penSizeLabel.Text = "Pen Size:";
            // 
            // marksLabel
            // 
            this.marksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.marksLabel.AutoSize = true;
            this.marksLabel.Location = new System.Drawing.Point(500, 120);
            this.marksLabel.Name = "marksLabel";
            this.marksLabel.Size = new System.Drawing.Size(35, 13);
            this.marksLabel.TabIndex = 11;
            this.marksLabel.Text = "marks";
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroundColorButton.Location = new System.Drawing.Point(554, 23);
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(48, 23);
            this.backgroundColorButton.TabIndex = 4;
            this.backgroundColorButton.Text = "Back";
            this.backgroundColorButton.UseVisualStyleBackColor = true;
            this.backgroundColorButton.Click += new System.EventHandler(this.backgroundColorButton_Click);
            // 
            // penSizeUpDown
            // 
            this.penSizeUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.penSizeUpDown.Location = new System.Drawing.Point(569, 50);
            this.penSizeUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.penSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.penSizeUpDown.Name = "penSizeUpDown";
            this.penSizeUpDown.Size = new System.Drawing.Size(32, 20);
            this.penSizeUpDown.TabIndex = 8;
            this.penSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.penSizeUpDown.ValueChanged += new System.EventHandler(this.penSizeUpDown_ValueChanged);
            // 
            // workingAreaBox
            // 
            this.workingAreaBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workingAreaBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workingAreaBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.workingAreaBox.Location = new System.Drawing.Point(5, 23);
            this.workingAreaBox.Name = "workingAreaBox";
            this.workingAreaBox.Size = new System.Drawing.Size(489, 156);
            this.workingAreaBox.TabIndex = 7;
            this.workingAreaBox.TabStop = false;
            this.workingAreaBox.Paint += new System.Windows.Forms.PaintEventHandler(this.workingAreaBox_Paint);
            this.workingAreaBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.workingAreaBox_MouseMove);
            // 
            // timerLabel
            // 
            this.timerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(500, 137);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(29, 13);
            this.timerLabel.TabIndex = 6;
            this.timerLabel.Text = "timer";
            // 
            // checkAnswerButton
            // 
            this.checkAnswerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAnswerButton.Location = new System.Drawing.Point(500, 183);
            this.checkAnswerButton.Name = "checkAnswerButton";
            this.checkAnswerButton.Size = new System.Drawing.Size(102, 23);
            this.checkAnswerButton.TabIndex = 2;
            this.checkAnswerButton.Text = "Check Answer";
            this.checkAnswerButton.UseVisualStyleBackColor = true;
            this.checkAnswerButton.Click += new System.EventHandler(this.checkAnswerButton_Click);
            // 
            // clearWorkingAreaButton
            // 
            this.clearWorkingAreaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearWorkingAreaButton.Location = new System.Drawing.Point(500, 74);
            this.clearWorkingAreaButton.Name = "clearWorkingAreaButton";
            this.clearWorkingAreaButton.Size = new System.Drawing.Size(102, 23);
            this.clearWorkingAreaButton.TabIndex = 5;
            this.clearWorkingAreaButton.Text = "Clear Working";
            this.clearWorkingAreaButton.UseVisualStyleBackColor = true;
            this.clearWorkingAreaButton.Click += new System.EventHandler(this.clearWorkingAreaButton_Click);
            // 
            // penColorButton
            // 
            this.penColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.penColorButton.Location = new System.Drawing.Point(500, 23);
            this.penColorButton.Name = "penColorButton";
            this.penColorButton.Size = new System.Drawing.Size(48, 23);
            this.penColorButton.TabIndex = 3;
            this.penColorButton.Text = "Fore";
            this.penColorButton.UseVisualStyleBackColor = true;
            this.penColorButton.Click += new System.EventHandler(this.penColorButton_Click);
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextQuestionButton.Location = new System.Drawing.Point(500, 156);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(102, 23);
            this.nextQuestionButton.TabIndex = 0;
            this.nextQuestionButton.Text = "Next Question";
            this.nextQuestionButton.UseVisualStyleBackColor = true;
            this.nextQuestionButton.Click += new System.EventHandler(this.nextQuestionButton_Click);
            // 
            // answerTextBox
            // 
            this.answerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answerTextBox.Location = new System.Drawing.Point(5, 185);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(489, 20);
            this.answerTextBox.TabIndex = 1;
            this.answerTextBox.TextChanged += new System.EventHandler(this.answerTextBox_TextChanged);
            this.answerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.answerTextBox_KeyDown);
            // 
            // QuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 581);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(290, 600);
            this.Name = "QuizForm";
            this.Text = "Quiz";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionImageDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workingAreaBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        public System.Windows.Forms.PictureBox questionImageDisplay;
        public System.Windows.Forms.Label marksLabel;
        public System.Windows.Forms.Button backgroundColorButton;
        public System.Windows.Forms.NumericUpDown penSizeUpDown;
        public System.Windows.Forms.PictureBox workingAreaBox;
        public System.Windows.Forms.Label timerLabel;
        public System.Windows.Forms.Button checkAnswerButton;
        public System.Windows.Forms.Button clearWorkingAreaButton;
        public System.Windows.Forms.Button penColorButton;
        public System.Windows.Forms.Button nextQuestionButton;
        public System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.Label workingAreaColorLabel;
        private System.Windows.Forms.Label penSizeLabel;
        private System.Windows.Forms.Label questionIndexLabel;
        private System.Windows.Forms.Label questionNameLabel;
    }
}