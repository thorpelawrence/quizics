using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace quizics
{
    public partial class EditQuestionsForm : Form
    {
        public EditQuestionsForm()
        {
            InitializeComponent();
            UpdateGrid();
        }

        //Updates the DataGridView to show the data in the database
        void UpdateGrid()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Tools.connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand("SELECT questionID, questionName, questionAnswer, questionMarks "
                    + "FROM Questions", connection))
                {
                    try
                    {
                        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        questionDataGridView.DataSource = dataTable;
                        //Set headers
                        questionDataGridView.Columns["questionName"].HeaderText = "Name";
                        questionDataGridView.Columns["questionAnswer"].HeaderText = "Answer";
                        questionDataGridView.Columns["questionMarks"].HeaderText = "Marks";
                        questionDataGridView.Columns["questionID"].Visible = false;
                        //Add the delete checkbox column if it doesn't already exist
                        if (!questionDataGridView.Columns.Contains("deleteCheckBox"))
                            questionDataGridView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "deleteCheckBox", HeaderText = "Delete?" });
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
            }
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Exam Question");
            contextMenu.Items.Add("Textbook Question");
            contextMenu.ItemClicked += delegate(object senderObject, ToolStripItemClickedEventArgs eventArgs)
            {
                Form form;
                switch (eventArgs.ClickedItem.Text)
                {
                    //Open appropriate form
                    case "Exam Question":
                        form = new AddExamQuestionForm { MdiParent = this.MdiParent };
                        form.FormClosed += delegate { UpdateGrid(); };
                        form.Show();
                        break;
                    case "Textbook Question":
                        form = new AddTextbookQuestionForm { MdiParent = this.MdiParent };
                        form.FormClosed += delegate { UpdateGrid(); };
                        form.Show();
                        break;
                }
            };
            contextMenu.Show(Cursor.Position);
        }

        private void questionDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //If row index is -1, grid is still updating so do not update database
            //Only update database if value changed, not when delete checkbox checked
            if (e.RowIndex != -1 && questionDataGridView.Columns[e.ColumnIndex].Name != "deleteCheckBox")
            {
                    using (SQLiteConnection connection = new SQLiteConnection(Tools.connectionString))
                    {
                        string changedColumn = questionDataGridView.Columns[e.ColumnIndex].Name;
                        using (SQLiteCommand command = new SQLiteCommand("UPDATE Questions SET " + changedColumn + "=@newValue WHERE questionID=@questionID", connection))
                        {
                            command.Parameters.AddWithValue("newValue", questionDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                            command.Parameters.AddWithValue("questionID", Convert.ToInt32(questionDataGridView.Rows[e.RowIndex].Cells["questionID"].Value));
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
                //Make sure data in grid is up to date in case of changes
                UpdateGrid();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in questionDataGridView.Rows)
            {
                //Check if delete checkbox is checked
                if (Convert.ToBoolean(row.Cells["deleteCheckBox"].Value))
                {
                        using (SQLiteConnection connection = new SQLiteConnection(Tools.connectionString))
                        {
                            using (SQLiteCommand command = new SQLiteCommand("DELETE FROM UserQuestion WHERE questionID=@questionID;"
                                + "DELETE FROM QuizQuestions WHERE questionID=@questionID;"
                                + "DELETE FROM Questions WHERE questionID=@questionID", connection))
                            {
                                command.Parameters.AddWithValue("questionID", row.Cells["questionID"].Value);
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
            }
            //Update data in grid to show changes
            UpdateGrid();
        }

        private void viewQuestionButton_Click(object sender, EventArgs e)
        {
            Form viewQuestionForm = new Form { FormBorderStyle = FormBorderStyle.SizableToolWindow, Width = 500, Height = 300, MdiParent = MdiParent };
            PictureBox questionImageBox = new PictureBox { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom };
            viewQuestionForm.Controls.Add(questionImageBox);
            int questionID = Convert.ToInt32(questionDataGridView.Rows[questionDataGridView.CurrentCell.RowIndex].Cells["questionID"].Value);
            questionImageBox.Image = Tools.ByteArrayToImage((byte[])Tools.GetQuestionData(questionID)["questionImage"]);
            viewQuestionForm.Show();
        }
    }
}
