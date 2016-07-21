using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace quizics
{
    public partial class AddTextbookQuestionForm : Form
    {
        string questionName;

        public AddTextbookQuestionForm()
        {
            InitializeComponent();
            //Force the question name to update
            questionName_Changed(null, null);
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            //Make sure question name is up to date before adding to database
            questionName_Changed(null, null);
            if (!string.IsNullOrWhiteSpace(imageFileLocationTextBox.Text) &&
                !string.IsNullOrWhiteSpace(answerTextBox.Text) &&
                !string.IsNullOrWhiteSpace(marksTextBox.Text) &&
                !string.IsNullOrWhiteSpace(textbookNameTextBox.Text)
                )
            {
                using (SQLiteConnection connection = new SQLiteConnection(Tools.connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Questions VALUES "
                        + "(@questionImage, @questionName, @questionAnswer, @questionMarks)", connection))
                    {
                        command.Parameters.AddWithValue("questionImage", Tools.ImageToByteArray(Image.FromFile(imageFileLocationTextBox.Text)));
                        command.Parameters.AddWithValue("questionName", questionName);
                        if (Tools.IsFloat(answerTextBox.Text))
                            command.Parameters.AddWithValue("questionAnswer", Tools.To2DP(answerTextBox.Text));
                        else
                        {
                            Tools.NonNumericAnswerMessage();
                            return;
                        }
                        if (Tools.IsInt(marksTextBox.Text))
                            command.Parameters.AddWithValue("questionMarks", marksTextBox.Text);
                        else
                        {
                            MessageBox.Show("# marks must be numerical", "Invalid # marks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
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
            //Show message if something is missing
            else if (string.IsNullOrWhiteSpace(imageFileLocationTextBox.Text))
            {
                MessageBox.Show("An image location must be provided",
                    "No image provided",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrWhiteSpace(answerTextBox.Text))
            {
                MessageBox.Show("An answer must be provided",
                    "No answer provided",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrWhiteSpace(marksTextBox.Text))
            {
                MessageBox.Show("# marks must be provided",
                    "# marks not provided",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrWhiteSpace(textbookNameTextBox.Text))
            {
                MessageBox.Show("Textbook name must be provided",
                    "No textbook name was provided",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Close form when finished
            Close();
        }

        private void imageFileLocationBrowseButton_Click(object sender, EventArgs e)
        {
            //Open a dialog to set the question image file location
            OpenFileDialog imageFileDialog = new OpenFileDialog();
            imageFileDialog.Filter = "Image files (*.png, *.jpg, *.bmp)|*.png; *.jpg; *.bmp";
            if (imageFileDialog.ShowDialog() == DialogResult.OK)
                imageFileLocationTextBox.Text = imageFileDialog.FileName;
        }

        /// <summary>
        /// Update question name as it is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void questionName_Changed(object sender, EventArgs e)
        {
            questionName = (
                "p" + pageNumberUpDown.Value
                //If parts are specified, add comma and part to question name
                + (string.IsNullOrWhiteSpace(questionComboBox1.Text) ? "" : "," + questionComboBox1.Text)
                + (string.IsNullOrWhiteSpace(questionComboBox2.Text) ? "" : "," + questionComboBox2.Text)
                + "_"
                + textbookNameTextBox.Text
                );
            questionNameLabelText = questionName;
        }

        string questionNameLabelText
        {
            set { questionNameLabel.Text = "Question Name:\r\n" + value; }
        }
    }
}
