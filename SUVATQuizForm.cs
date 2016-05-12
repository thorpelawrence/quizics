using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

namespace quizics
{
    public partial class SUVATQuizForm : Form
    {
        //Array to store the questions and their answers
        string[,] questionsAnswers;
        //Array to store the parts of each question
        int[,] suvatParts;

        public SUVATQuizForm()
        {
            InitializeComponent();
        }

        void GenerateQuestions()
        {
            Panel panel = randQuestionsPanel;
            panel.AutoScroll = true;
            resetRandomQuestionsButton.Visible = true;
            checkRandomQuestionsAnswersButton.Visible = true;
            numberOfRandomQuestions.Visible = false;
            numberOfRandomQuestionsLabel.Visible = false;
            int questionspacing = 70;
            panel.Controls.Clear();
            int numberOfQuestions = (int)numberOfRandomQuestions.Value;
            questionsAnswers = new string[numberOfQuestions, 2];
            suvatParts = new int[numberOfQuestions, 5];
            for (int questionIndex = 0; questionIndex < numberOfQuestions; questionIndex++)
            {
                Label questionlabel = new Label();
                Label answerlabel = new Label();
                answerlabel.Top = questionspacing * questionIndex + 25;
                answerlabel.Left = 20;
                do
                {
                    string question = RandomQuestion(questionIndex);
                    questionsAnswers[questionIndex, 0] = question.Split(',')[0];
                    questionlabel.Text = question.Split(',')[0];
                    answerlabel.Text = question.Split(',')[1];
                    //Repeat making sure that the question is not the same as the last one
                } while (questionIndex > 0 && questionsAnswers[questionIndex, 0] == questionsAnswers[questionIndex - 1, 0]);
                //Set the part to be solved for to the first character of the answer, one of (s,u,v,a,t)
                char solvefor = answerlabel.Text[0];
                questionsAnswers[questionIndex, 1] = CalculateAnswer(solvefor, questionIndex, suvatParts);
                if (questionsAnswers[questionIndex, 1] == "0") { questionIndex--; }
                else
                {
                    questionlabel.Width = TextRenderer.MeasureText(questionlabel.Text, questionlabel.Font).Width;
                    answerlabel.Width = TextRenderer.MeasureText(answerlabel.Text, answerlabel.Font).Width;
                    questionlabel.Top = questionspacing * questionIndex;
                    TextBox answertextbox = new TextBox();
                    answertextbox.Top = questionspacing * questionIndex + 25;
                    answertextbox.Left = 60;
                    panel.Controls.Add(questionlabel);
                    panel.Controls.Add(answerlabel);
                    panel.Controls.Add(answertextbox);
                }
            }
        }

        string RandomQuestion(int questionIndex)
        {
            Random random = new Random();
            string parts = "";
            string question = "";
            int maxValue = 100;
            for (int partIndex = 0; partIndex < 4; partIndex++)
            {
                bool repeat = false;
                string part = "";
                int value;
                switch (random.Next(5))
                {
                    case 0:
                        //Check if question already contains the part
                        if (parts.Contains("s=")) { partIndex--; repeat = true; break; }
                        //Check if part is last part to be added
                        if (partIndex < 3)
                        {
                            //Set the value of the part to a value between 1 and maxValue
                            value = (random.Next(maxValue) + 1);
                            part = "s=" + value;
                            //Add the value to the array so it can be used to calculate answer
                            suvatParts[questionIndex, 0] = value;
                        }
                        //If last part, set the question to be this part
                        else { question = "s=?"; };
                        break;
                    case 1:
                        if (parts.Contains("u=")) { partIndex--; repeat = true; break; }
                        if (partIndex < 3)
                        {
                            value = (random.Next(maxValue) + 1);
                            part = "u=" + value;
                            suvatParts[questionIndex, 1] = value;
                        }
                        else { question = "u=?"; };
                        break;
                    case 2:
                        if (parts.Contains("v=")) { partIndex--; repeat = true; break; }
                        if (partIndex < 3)
                        {
                            value = (random.Next(maxValue) + 1);
                            part = "v=" + value;
                            suvatParts[questionIndex, 2] = value;
                        }
                        else { question = "v=?"; };
                        break;
                    case 3:
                        if (parts.Contains("a=")) { partIndex--; repeat = true; break; }
                        if (partIndex < 3)
                        {
                            value = (random.Next(maxValue) + 1);
                            part = "a=" + value;
                            suvatParts[questionIndex, 3] = value;
                        }
                        else { question = "a=?"; };
                        break;
                    case 4:
                        if (parts.Contains("t=")) { partIndex--; repeat = true; break; }
                        if (partIndex < 3)
                        {
                            value = (random.Next(maxValue) + 1);
                            part = "t=" + value;
                            suvatParts[questionIndex, 4] = value;
                        }
                        else { question = "t=?"; };
                        break;
                }
                //If the part does not already exist, add it to the question
                if (!repeat)
                {
                    parts += part;
                    //Add space after each but last part
                    if (partIndex < 2)
                        parts += "    ";
                }
            }
            return parts + "," + question;
        }

        string CalculateAnswer(char solvefor, int questionIndex, int[,] suvatParts)
        {
            float answer = 0;
            char unknownPart = ' ';
            float s = suvatParts[questionIndex, 0];
            float u = suvatParts[questionIndex, 1];
            float v = suvatParts[questionIndex, 2];
            float a = suvatParts[questionIndex, 3];
            float t = suvatParts[questionIndex, 4];

            char[] suvatChars = { 's', 'u', 'v', 'a', 't' };

            for (int i = 0; i < 5; i++)
            {
                if (suvatChars[i] != solvefor && suvatParts[questionIndex, i] == 0)
                    unknownPart = suvatChars[i];
            }

            switch (solvefor)
            {
                case 's':
                    if (unknownPart != 'u' && unknownPart != 'v' && unknownPart != 't')
                        answer = ((u + v) / 2) * t;
                    else if (unknownPart != 'v' && unknownPart != 'u' && unknownPart != 'a')
                        answer = ((v * v) - (u * u)) / (2 * a);
                    else if (unknownPart != 'u' && unknownPart != 't' && unknownPart != 'a')
                        answer = (u * t) + (0.5f * a * (t * t));
                    else if (unknownPart != 'v' && unknownPart != 't' && unknownPart != 'a')
                        answer = (v * t) - (0.5f * a * (t * t));
                    break;
                case 'u':
                    if (unknownPart != 'v' && unknownPart != 'a' && unknownPart != 't')
                        answer = v - (a * t);
                    else if (unknownPart != 'v' && unknownPart != 'a' && unknownPart != 's')
                        answer = (float)Math.Sqrt((v * v) - (2 * a * s));
                    else if (unknownPart != 'u' && unknownPart != 'v' && unknownPart != 't')
                        answer = ((2 * s) / t) - v;
                    else if (unknownPart != 's' && unknownPart != 'a' && unknownPart != 't')
                        answer = (s - (0.5f * a * t * t)) / t;
                    break;
                case 'v':
                    if (unknownPart != 'u' && unknownPart != 'a' && unknownPart != 't')
                        answer = u + (a * t);
                    else if (unknownPart != 's' && unknownPart != 't' && unknownPart != 'u')
                        answer = ((2 * s) / t) - u;
                    else if (unknownPart != 'u' && unknownPart != 'a' && unknownPart != 's')
                        answer = (float)Math.Sqrt((u * u) + (2 * a * s));
                    else if (unknownPart != 's' && unknownPart != 'a' && unknownPart != 't')
                        answer = (s + (0.5f * a * t * t)) / t;
                    break;
                case 'a':
                    if (unknownPart != 'v' && unknownPart != 'u' && unknownPart != 't')
                        answer = (v - u) / t;
                    else if (unknownPart != 's' && unknownPart != 'u' && unknownPart != 't')
                        answer = (s - (u * t)) / (0.5f * t * t);
                    else if (unknownPart != 'v' && unknownPart != 'u' && unknownPart != 's')
                        answer = ((v * v) - (u * u)) / (2 * s);
                    else if (unknownPart != 's' && unknownPart != 'v' && unknownPart != 't')
                        answer = (s - (v * t)) / (-0.5f * t * t);
                    break;
                case 't':
                    if (unknownPart != 'v' && unknownPart != 'u' && unknownPart != 'a')
                        answer = (v - u) / a;
                    else if (unknownPart != 's' && unknownPart != 'u' && unknownPart != 'v')
                        answer = (2 * s) / (u + v);
                    else return "0";
                    break;
            }
            return Tools.To2DP(answer);
        }

        void CheckAnswers()
        {
            int questionIndex = 0;
            foreach (Control c in randQuestionsPanel.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = (TextBox)c;
                    if (Tools.IsFloat(textBox.Text))
                    {
                        if (questionsAnswers[questionIndex, 1] == Tools.To2DP(float.Parse(textBox.Text))) textBox.BackColor = Color.Lime;
                        else textBox.BackColor = Color.Red;
                    }
                    textBox.ReadOnly = true;
                    questionIndex++;
                }
            };
            checkRandomQuestionsAnswersButton.Visible = false;
            numberOfRandomQuestions.Visible = true;
            numberOfRandomQuestionsLabel.Visible = true;
        }

        void ResetQuestions()
        {
            Panel panel = randQuestionsPanel;
            resetRandomQuestionsButton.Visible = false;
            checkRandomQuestionsAnswersButton.Visible = false;
            numberOfRandomQuestions.Visible = true;
            numberOfRandomQuestionsLabel.Visible = true;
            panel.Controls.Clear();
        }

        void EquationsDialog()
        {
            Form suvatEquDialog = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                TopMost = true
            };
            if (Application.OpenForms[suvatEquDialog.Name] == null)
            {
                TextBox suvatEquText = new TextBox
                {
                    ReadOnly = true,
                    Multiline = true,
                    BorderStyle = BorderStyle.None,
                    Font = new Font("Consolas", 20),
                };
                suvatEquText.AppendText("v=u+at");
                suvatEquText.AppendText("\r\ns=((u+v)/2)t");
                suvatEquText.AppendText("\r\nv²=u²+2as");
                suvatEquText.AppendText("\r\ns=ut+½at²");
                suvatEquText.AppendText("\r\ns=vt-½at²");
                suvatEquText.Size = new Size(210, 200);
                suvatEquDialog.Size = suvatEquText.Size;
                suvatEquDialog.Controls.Add(suvatEquText);
                suvatEquDialog.Show();
            }
            else Application.OpenForms[suvatEquDialog.Name].Focus();
        }

        /// <summary>
        /// Print the generated questions
        /// </summary>
        public void Print()
        {
            List<string> printList = new List<string>();
            int index = 0;
            int questionNumber = 1;
            foreach (Control control in randQuestionsPanel.Controls)
            {
                if (control is Label)
                {
                    //Add each label's text to print list, add line break after every question (every 2 labels)
                    Label label = (Label)control;
                    if (index % 2 == 0)
                    {
                        printList.Add("\r\n" + questionNumber + ".  ");
                        questionNumber++;
                    }
                    printList.Add(label.Text + "\r\n");
                    index++;
                }
            }
            //Check that there is something to print
            if (printList.Count > 0)
            {
                PrintPreviewDialog PrintPreviewDialog = new PrintPreviewDialog();
                PrintDocument printDocument = new PrintDocument();
                //Declare anonymous method that triggers when the document is printed
                printDocument.PrintPage += delegate (object sender, PrintPageEventArgs e)
                {
                    //Draw short date onto page
                    e.Graphics.DrawString(DateTime.Now.ToShortDateString(),
                        new Font("Arial", 9, FontStyle.Italic), Brushes.Black, 300, 20);
                    //Join list into one string to draw onto page
                    e.Graphics.DrawString(string.Join("", printList.ToArray()),
                        new Font("Arial", 11), Brushes.Black, 20, 20);
                };
                PrintPreviewDialog.Document = printDocument;
                PrintPreviewDialog.ShowDialog();
            }
            else Tools.NothingToPrintMessage();
        }

        private void generateRandomQuestionsButton_Click(object sender, EventArgs e)
        {
            GenerateQuestions();
        }

        private void resetRandomQuestionsButton_Click(object sender, EventArgs e)
        {
            ResetQuestions();
        }

        private void checkRandomQuestionsAnswersButton_Click(object sender, EventArgs e)
        {
            CheckAnswers();
        }

        private void suvatDialogButton_Click(object sender, EventArgs e)
        {
            EquationsDialog();
        }

    }
}
