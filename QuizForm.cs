using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace quizics
{
    partial class QuizForm : Form
    {
        //Timer used to record time spent on questions
        Timer timer = new Timer();
        //ID of current quiz
        int quizID;
        int quizQuestionCount;
        int quizMaximumMarks;
        int quizQuestionIndex;
        int timerSeconds;
        int marksAchieved;

        public QuizForm(int numberOfQuestions)
        {
            InitializeComponent();
            questionControlsVisible = false;
            nextQuestionButton.Text = "Start Questions";
            checkAnswerButton.Visible = false;
            answerTextBox.Visible = false;
            nextQuestionButton.BackColor = Color.Lime;
            timerLabel.Visible = false;
            marksLabel.Visible = false;
            InitializeWorkingArea();
            GenerateQuiz(numberOfQuestions);
        }

        /// <summary>
        /// Sets whether all the controls used for questions are visible or not
        /// </summary>
        bool questionControlsVisible
        {
            set
            {
                checkAnswerButton.Visible = value;
                answerTextBox.Visible = value;
                questionImageDisplay.Visible = value;
                workingAreaBox.Visible = value;
                penColorButton.Visible = value;
                backgroundColorButton.Visible = value;
                penSizeUpDown.Visible = value;
                clearWorkingAreaButton.Visible = value;
                penSizeLabel.Visible = value;
                workingAreaColorLabel.Visible = value;
                marksLabel.Visible = value;
                questionIndexLabel.Visible = value;
                questionNameLabel.Visible = value;
            }

        }

        #region Events
        private void questionImageDisplay_Click(object sender, EventArgs e)
        {
            ZoomQuestionImage();
        }

        private void workingAreaBox_MouseMove(object sender, MouseEventArgs e)
        {
            DrawWorking(e);
        }

        private void penColorButton_Click(object sender, EventArgs e)
        {
            pen.Color = ColorDialog(sender);
        }

        private void backgroundColorButton_Click(object sender, EventArgs e)
        {
            if (ClearWorkingAreaCheck())
                workingAreaBox.BackColor = ColorDialog(sender);
        }

        private void penSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            penSize = (float)penSizeUpDown.Value;
        }

        private void clearWorkingAreaButton_Click(object sender, EventArgs e)
        {
            ClearWorkingAreaCheck();
        }

        private void checkAnswerButton_Click(object sender, EventArgs e)
        {
            CheckAnswer();
        }

        private void workingAreaBox_Paint(object sender, PaintEventArgs e)
        {
            PaintWorking();
            ResizeWorking();
        }

        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            NextQuestionCheck();
        }

        private void answerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!answerTextBox.ReadOnly)
                {
                    CheckAnswer();
                }
                else NextQuestionCheck();
            }
        }

        private void answerTextBox_TextChanged(object sender, EventArgs e)
        {
            answerTextBox.BackColor = Color.White;
            answerTextBox.ForeColor = Color.Black;
        }
        #endregion

        /// <summary>
        /// Create a quiz with a set number of questions
        /// </summary>
        /// <param name="numberOfQuestions"></param>
        void GenerateQuiz(int numberOfQuestions)
        {
            using (SqlConnection connection = new SqlConnection(Tools.connectionString))
            {
                string quizName = "";
                try
                {
                    quizName = (string)Tools.GetUserData(MainMDI.userID)["username"];
                }
                catch { return; }
                //Select the number of unique quizIDs for the user, to get a count of number of quizzes completed 
                using (SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT quizID) FROM UserQuestion WHERE userID=@userID", connection))
                {
                    command.Parameters.AddWithValue("userID", MainMDI.userID);
                    try
                    {
                        connection.Open();
                        //The next quiz will the the (n+1) quiz so add 1 and add this number to the quiz name
                        quizName += (int)command.ExecuteScalar() + 1;
                        connection.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
                using (SqlCommand command = new SqlCommand("INSERT INTO Quiz VALUES (@quizDateTime, @quizName)", connection))
                {
                    command.Parameters.AddWithValue("quizDateTime", DateTime.Now);
                    command.Parameters.AddWithValue("quizName", quizName);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
                //Get the last added quizID
                using (SqlCommand command = new SqlCommand("SELECT MAX(quizID) FROM Quiz", connection))
                {
                    try
                    {
                        connection.Open();
                        quizID = (int)command.ExecuteScalar();
                        connection.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
                int questionIDCount = 0;
                //Get number of question IDs in database
                using (SqlCommand command = new SqlCommand("SELECT COUNT(questionID) FROM Questions", connection))
                {
                    try
                    {
                        connection.Open();
                        questionIDCount = (int)command.ExecuteScalar();
                        connection.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
                //Make sure that it does not try to choose more questions than exists in the database
                if (numberOfQuestions > questionIDCount)
                {
                    MessageBox.Show("Cannot use " + numberOfQuestions + " questions\r\nNot enough questions exist\r\nOnly " + questionIDCount + " questions will be used",
                        "Too many questions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //If less questions in the database than user requested, reduce number of questions to number of existing questions
                    numberOfQuestions = questionIDCount;
                }
                //Set the number of questions in the quiz to the number of questions whether changed or not
                quizQuestionCount = numberOfQuestions;
                //List used to temporarily store questionIDs to check which are used
                List<int> randomQuestionIDList = new List<int>();
                //Select a random list of questions from the database
                using (SqlCommand command = new SqlCommand("SELECT TOP (@numberOfQuestions) questionID FROM Questions ORDER BY (NEWID())", connection))
                {
                    command.Parameters.AddWithValue("numberOfQuestions", numberOfQuestions);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                randomQuestionIDList.Add(reader.GetInt32(0));
                            }
                        }
                        connection.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
                //Add all the random IDs and indexes to the QuizQuestions table with the current quiz ID
                int questionIndex = 0;
                foreach (int randomQuestionID in randomQuestionIDList)
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO QuizQuestions VALUES "
                        + "(@quizID, @questionID, @questionIndex)", connection))
                    {
                        command.Parameters.AddWithValue("quizID", quizID);
                        command.Parameters.AddWithValue("questionID", randomQuestionID);
                        command.Parameters.AddWithValue("questionIndex", questionIndex);
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                        finally { connection.Close(); }
                        //Sum marks for each question to set maximum marks available for quiz
                        try
                        {
                            quizMaximumMarks += (int)Tools.GetQuestionData(quizID, questionIndex)["questionMarks"];
                        }
                        catch { return; }
                        questionIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// Check if questions need to be started or whether to just show next question
        /// </summary>
        void NextQuestionCheck()
        {
            if (nextQuestionButton.Text == "Start Questions")
            {
                StartQuestions();
            }
            else if (nextQuestionButton.Text == "End Quiz")
            {
                Close();
            }
            else
            {
                NextQuestion(true);
            }
        }

        /// <summary>
        /// Start to show the questions
        /// </summary>
        void StartQuestions()
        {
            nextQuestionButton.Text = "Next Question";
            questionControlsVisible = true;
            marksLabelText = "0";
            questionIndexLabelText = "0";
            marksAchieved = 0;
            nextQuestionButton.UseVisualStyleBackColor = true;
            //Start question index at -1 so when the first NextQuestion call is made below the first question shown is index 0
            quizQuestionIndex = -1;
            NextQuestion();
        }

        /// <summary>
        /// Check if user's answer is correct for current question
        /// </summary>
        /// <returns></returns>
        bool CheckAnswer()
        {
            bool answerCorrect;
            if (Tools.IsFloat(answerTextBox.Text))
            {
                string questionAnswer = "0";
                try
                {
                    questionAnswer = (string)Tools.GetQuestionData(quizID, quizQuestionIndex)["questionAnswer"];
                }
                catch { return false; }
                if (Tools.To2DP(questionAnswer)
                    == Tools.To2DP(answerTextBox.Text))
                {
                    answerCorrect = true;
                    //Add marks for question
                    try
                    {
                        marksAchieved += (int)Tools.GetQuestionData(quizID, quizQuestionIndex)["questionMarks"];
                    }
                    catch { return false; }
                    checkAnswerButton.Visible = false;
                    answerTextBox.ReadOnly = true;
                    answerTextBox.BackColor = Color.Lime;
                    answerTextBox.ForeColor = Color.Black;
                    timer.Stop();
                    //Update number of marks achieved displayed to user
                    marksLabelText = marksAchieved.ToString();
                }
                else
                {
                    answerCorrect = false;
                    answerTextBox.BackColor = Color.Red;
                    answerTextBox.ForeColor = Color.White;
                }
                return answerCorrect;
            }
            else if (!string.IsNullOrWhiteSpace(answerTextBox.Text))
            {
                Tools.NonNumericAnswerMessage();
            }
            return false;
        }

        /// <summary>
        /// Load the next question, can use true parameter to check current answer
        /// </summary>
        /// <param name="checkingAnswer"></param>
        void NextQuestion(bool checkingAnswer = false)
        {
            //Checks if answer box is readonly - if it is it will not check and therefore not award an extra mark
            if (checkingAnswer && !answerTextBox.ReadOnly)
            {
                if (!CheckAnswer() && checkAnswerButton.Visible)
                {
                    //If the user does not want to continue, do not move on
                    if (MessageBox.Show("Current answer is incorrect\r\nContinue?",
                        "Incorrect",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)
                        == DialogResult.No)
                        return;
                }
            }
            //Add the details of the last question to the database before next question
            if (quizQuestionIndex >= 0)
            {
                using (SqlConnection connection = new SqlConnection(Tools.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO UserQuestion VALUES "
                        + "(@userID, @questionID, @quizID, @userAnswer)", connection))
                    {
                        command.Parameters.AddWithValue("userID", MainMDI.userID);
                        try
                        {
                            command.Parameters.AddWithValue("questionID", (int)Tools.GetQuestionData(quizID, quizQuestionIndex)["questionID"]);
                        }
                        catch { return; }
                        command.Parameters.AddWithValue("quizID", quizID);
                        //If a number and not blank, add answer
                        if (!string.IsNullOrWhiteSpace(answerTextBox.Text) && Tools.IsFloat(answerTextBox.Text))
                        {
                            command.Parameters.AddWithValue("userAnswer", Tools.To2DP(answerTextBox.Text));
                        }
                        //Otherwise, add as unanswered
                        else command.Parameters.AddWithValue("userAnswer", "Unanswered");
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                        finally { connection.Close(); }
                    }
                }
            }
            //Checks if 1 more than index is the same as count as it is checked before continuing so will always be 1 less
            if (quizQuestionIndex + 1 == quizQuestionCount)
            {
                EndQuestions();
                return;
            }
            quizQuestionIndex++;

            checkAnswerButton.Visible = true;
            answerTextBox.ReadOnly = false;
            answerTextBox.Clear();
            answerTextBox.BackColor = Color.White;
            answerTextBox.ForeColor = Color.Black;
            ClearWorkingArea();
            timer.Stop();
            timerLabel.Visible = true;
            timerSeconds = 0;
            timerLabel.Text = TimeSpan.FromSeconds(timerSeconds).ToString();
            //Create and start timer with 1 second interval
            timer = new Timer { Interval = 1000 };
            timer.Start();
            //Declare anonymous method that triggers every time timer ticks
            timer.Tick += delegate
            {
                timerSeconds++;
                timerLabel.Text = (TimeSpan.FromSeconds(timerSeconds)).ToString();
            };
            //Set the image by finding the data from the questionID for the current index and quiz and converting it into an image
            try
            {
                questionImageDisplay.Image = Tools.ByteArrayToImage((byte[])Tools.GetQuestionData(quizID, quizQuestionIndex)["questionImage"]);
            }
            catch { return; }
            //Display the name of the question
            try
            {
                questionNameLabel.Text = (string)Tools.GetQuestionData(quizID, quizQuestionIndex)["questionName"];
            }
            catch { return; }
            //Add 1 to question index so that the user sees questions starting from 1
            questionIndexLabelText = (quizQuestionIndex + 1).ToString();
        }

        /// <summary>
        /// Sets up GUI for end of questions
        /// </summary>
        void EndQuestions()
        {
            //Calculate and show score percentage
            MessageBox.Show(string.Format("End of questions\r\nYou scored {0}/{1} ({2}%)", marksAchieved, quizMaximumMarks,
                Math.Round(((float)marksAchieved / quizMaximumMarks) * 100, 1)),
                "End",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            timer.Stop();
            timerLabel.Visible = false;
            nextQuestionButton.Text = "End Quiz";
            nextQuestionButton.BackColor = Color.Orange;
            questionControlsVisible = false;
            questionImageDisplay.Image = null;
        }

        /// <summary>
        /// Opens a form to display the question image at full size
        /// </summary>
        void ZoomQuestionImage()
        {
            if (questionImageDisplay.Image != null)
            {
                Form questionImageDisplayZoomForm = new Form
                {
                    FormBorderStyle = FormBorderStyle.None,
                    MdiParent = MdiParent
                };
                //Only show if not already open
                if (Application.OpenForms[questionImageDisplayZoomForm.Name] == null)
                {
                    PictureBox questionImageDisplayZoomed = new PictureBox
                    {
                        Image = questionImageDisplay.Image,
                        Dock = DockStyle.Fill
                    };
                    questionImageDisplayZoomForm.Controls.Add(questionImageDisplayZoomed);
                    questionImageDisplayZoomForm.Size = questionImageDisplay.Image.Size;
                    //Declare anomymous method that triggers when the control is clicked
                    questionImageDisplayZoomed.Click += delegate { questionImageDisplayZoomForm.Close(); };
                    //Declare anomymous method that triggers when the mouse leaves the control
                    questionImageDisplayZoomed.MouseLeave += delegate { questionImageDisplayZoomForm.Close(); };
                    questionImageDisplayZoomed.Cursor = questionImageDisplay.Cursor;
                    questionImageDisplayZoomForm.Show();
                }
                //If already open, focus it
                else Application.OpenForms[questionImageDisplayZoomForm.Name].Focus();
            }
        }

        /// <summary>
        /// Sets the marks label text value
        /// </summary>
        string marksLabelText
        {
            set
            {
                marksLabel.Text = "Marks: " + value + "/" + quizMaximumMarks;
            }
        }

        /// <summary>
        /// Sets the question index label text value
        /// </summary>
        string questionIndexLabelText
        {
            set
            {
                questionIndexLabel.Text = "Question " + value + " of " + quizQuestionCount;
            }
        }

        /// <summary>
        /// Print the current question image
        /// </summary>
        public void Print()
        {
            if (questionImageDisplay.Image != null)
            {
                PrintPreviewDialog PrintPreviewDialog = new PrintPreviewDialog();
                PrintDocument printDocument = new PrintDocument();
                //Declare anonymous method that triggers when the document is printed
                printDocument.PrintPage += delegate (object sender, PrintPageEventArgs e)
                {
                    try
                    {
                        e.Graphics.DrawString((string)Tools.GetQuestionData(quizID, quizQuestionIndex)["questionName"],
                            new Font("Arial", 14), Brushes.Black, 50, 40);
                    }
                    catch { return; }
                    Image questionImage = questionImageDisplay.Image;
                    float imageScale = 700f / questionImage.Width;
                    e.Graphics.DrawImage(questionImage, 50, 70, 700, questionImage.Height * imageScale);
                };
                PrintPreviewDialog.Document = printDocument;
                PrintPreviewDialog.ShowDialog();
            }
            else Tools.NothingToPrintMessage();
        }

        #region Working area
        //Bitmap (image) used to draw working onto
        Bitmap b;
        //Pen used to draw working
        Pen pen;

        /// <summary>
        /// Sets up working area
        /// </summary>
        void InitializeWorkingArea()
        {
            penSizeUpDown.Value = 1;
            pen = new Pen(Color.White, 1);
            workingAreaBox.BackColor = Color.Black;
            penColorButton.BackColor = pen.Color;
            penColorButton.ForeColor = Tools.Invert(pen.Color);
            backgroundColorButton.BackColor = workingAreaBox.BackColor;
            backgroundColorButton.ForeColor = Tools.Invert(workingAreaBox.BackColor);
            ClearWorkingArea();
            MouseWheel += new MouseEventHandler(QuizForm_MouseWheel);
        }

        /// <summary>
        /// Change the size of the pen when the mouse wheel is scrolled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void QuizForm_MouseWheel(object sender, MouseEventArgs e)
        {
            //Increase size if scrolling up
            if (e.Delta > 0)
                penSize += 1;
            //Decrease size if scrolling down
            else penSize -= 1;
        }

        /// <summary>
        /// Gets user confirmation to clear the working area
        /// </summary>
        /// <returns></returns>
        bool ClearWorkingAreaCheck()
        {
            if (MessageBox.Show("Working will be deleted\r\nAre you sure you want to continue?",
                "Delete working",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ClearWorkingArea();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Clears the working area
        /// </summary>
        void ClearWorkingArea()
        {
            b = new Bitmap(workingAreaBox.Width, workingAreaBox.Height);
            workingAreaBox.Image = b;
            DrawText();
        }

        /// <summary>
        /// Draws the words "Working area" onto the working area in the colour inverse to the background
        /// </summary>
        void DrawText()
        {
            string text = "Working area";
            Font font = new Font("Arial", 11);
            Brush brush = new SolidBrush(Tools.Invert(workingAreaBox.BackColor));
            Size textsize = TextRenderer.MeasureText(text, font);
            using (Graphics g = Graphics.FromImage(b))
                g.DrawString(text, font, brush, new Rectangle(0, 0, textsize.Width, textsize.Height));
        }

        /// <summary>
        /// Triggers when the working area panel size changes
        /// </summary>
        void ResizeWorking()
        {
            //If new working area is larger than current bitmap, resize it and draw original back onto it
            if (b.Width < workingAreaBox.Width || b.Height < workingAreaBox.Height)
            {
                Bitmap bResized = new Bitmap(workingAreaBox.Width, workingAreaBox.Height);
                Graphics gResized = Graphics.FromImage(bResized);
                gResized.DrawImageUnscaled(b, 0, 0);
                b = bResized;
            }
        }

        //Points used for pen
        Point p, pLast;

        /// <summary>
        /// Draws onto the working area
        /// </summary>
        /// <param name="e"></param>
        void DrawWorking(MouseEventArgs e)
        {
            //Sets current point for the pen to the mouse position
            p = e.Location;
            //Check if mouse is within the bounds of the control
            if (workingAreaBox.ClientRectangle.Contains(e.Location))
            {
                //Creates graphics from bitmap to draw onto
                using (Graphics g = Graphics.FromImage(b))
                    //Checks which mouse button is being used
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            //Draw a line between last point and current point
                            g.DrawLine(pen, pLast, p);
                            break;
                        case MouseButtons.Right:
                            //Erase, draw with new pen of same colour as background and fixed width
                            g.DrawLine(new Pen(workingAreaBox.BackColor, 20), pLast, p);
                            break;
                    }
            }
            //Sets the working area's image to the bitmap used
            workingAreaBox.Image = b;
        }

        /// <summary>
        /// Triggers when working area is changed
        /// </summary>
        void PaintWorking()
        {
            //Sets the last point value to the current point value so line is continuous
            pLast = p;
        }

        /// <summary>
        /// Returns colour from a color dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        Color ColorDialog(object sender)
        {
            Color c = Color.White;
            Button buttonSender = (Button)sender;
            ColorDialog ColorDialog = new ColorDialog();
            ColorDialog.FullOpen = true;
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                c = ColorDialog.Color;
                buttonSender.BackColor = c;
                buttonSender.ForeColor = Tools.Invert(c);
            }
            return c;
        }

        /// <summary>
        /// Set size of pen
        /// </summary>
        float penSize
        {
            set
            {
                //Check if the value of the pen size is between the minimum and maximum
                if (value <= (float)penSizeUpDown.Maximum && value >= (float)penSizeUpDown.Minimum)
                {
                    //Set the width of the pen (size)
                    pen.Width = value;
                    //Ensure the pen size shown to the user is the the same as the actual pen size
                    penSizeUpDown.Value = (decimal)value;
                }
            }
            get { return pen.Width; }
        }
        #endregion
    }
}
