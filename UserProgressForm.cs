using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace quizics
{
    public partial class UserProgressForm : Form
    {
        int userID;
        public UserProgressForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;

            using (SqlConnection connection = new SqlConnection(Tools.connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "SELECT quizID, questionName, questionAnswer, userAnswer, questionMarks " +
                    "FROM UserQuestion JOIN Questions ON UserQuestion.questionID=Questions.questionID WHERE userID=@userID ORDER BY quizID DESC",
                    connection))
                {
                    command.Parameters.AddWithValue("userID", userID);
                    try
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        userProgressDataGridView.DataSource = dataTable;
                        //Set headers
                        userProgressDataGridView.Columns["quizID"].HeaderText = "Quiz";
                        userProgressDataGridView.Columns["questionName"].HeaderText = "Question";
                        userProgressDataGridView.Columns["questionAnswer"].HeaderText = "Answer";
                        userProgressDataGridView.Columns["userAnswer"].HeaderText = "Student answer";
                        userProgressDataGridView.Columns["questionMarks"].HeaderText = "Marks";
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
            }
        }

        private void UserProgressForm_Load(object sender, EventArgs e)
        {
            int totalMarks = 0;
            foreach (DataGridViewRow row in userProgressDataGridView.Rows)
            {
                //Check if user's answer is correct
                if ((string)row.Cells["userAnswer"].Value == (string)row.Cells["questionAnswer"].Value)
                {
                    //If correct, add the number of marks earned to the total
                    row.DefaultCellStyle.BackColor = Color.Lime;
                    totalMarks += (int)row.Cells["questionMarks"].Value;
                }
                else
                {
                    //Otherwise, show 0 marks earned
                    row.Cells["questionMarks"].Value = 0;
                    row.DefaultCellStyle.BackColor = Color.Crimson;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
            //Set the label text to show the total marks
            totalMarksLabel.Text += totalMarks;
        }

        /// <summary>
        /// Print the list of completed questions
        /// </summary>
        public void Print()
        {
            //Check that there is something to print
            if (userProgressDataGridView.Rows.Count > 0)
            {
                PrintPreviewDialog PrintPreviewDialog = new PrintPreviewDialog();
                PrintDocument printDocument = new PrintDocument();

                //Make sure that these values are reset every time the document is printed
                int startRow = 0;
                int rowIndex = 0;
                int pageNumber = 1;
                printDocument.BeginPrint += delegate(object sender, PrintEventArgs e)
                {
                    startRow = 0;
                    rowIndex = 0;
                    pageNumber = 1;
                };
                //Declare anonymous method that triggers when the document is printed
                printDocument.PrintPage += delegate(object sender, PrintPageEventArgs e)
                {
                    //If the start of the document add the header
                    if (startRow == 0)
                    {
                        try
                        {
                            e.Graphics.DrawString((string)Tools.GetUserData(userID)["username"]
                            + "\t\t\t\t\t\t" + DateTime.Now, new Font("Arial", 11), Brushes.Black, 50, 40);
                        }
                        catch { return; }
                    }
                    //Create a new grid with some of the rows, enough to fill page
                    DataGridView printGrid = new DataGridView
                    {
                        RowHeadersVisible = false,
                        Width = 650,
                        Height = 930,
                        AllowUserToAddRows = false,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    };
                    foreach (DataGridViewColumn column in userProgressDataGridView.Columns)
                    {
                        //Add existing columns
                        printGrid.Columns.Add((DataGridViewColumn)column.Clone());
                    }
                    for (rowIndex = startRow; rowIndex < startRow + 41; rowIndex++)
                    {
                        //Add rows between start and start+41 (41 rows per page)
                        if (rowIndex < userProgressDataGridView.Rows.Count)
                        {
                            DataGridViewRow rowClone = (DataGridViewRow)userProgressDataGridView.Rows[rowIndex].Clone();
                            //Loop through cells for each row and fill data into copy of row
                            int column = 0;
                            foreach (DataGridViewCell cell in userProgressDataGridView.Rows[rowIndex].Cells)
                            {
                                rowClone.Cells[column].Value = cell.Value;
                                column++;
                            }
                            printGrid.Rows.Add(rowClone);
                        }
                    }
                    //Set the new start to the row index so the next page starts from the next row
                    startRow = rowIndex;
                    //Create a bitmap and draw the grid onto it
                    Bitmap gridImage = new Bitmap(650, 930);
                    printGrid.DrawToBitmap(gridImage, new Rectangle(0, 0, 650, 930));
                    e.Graphics.DrawImageUnscaled(gridImage, 50, 70);
                    //Draw the page number footer on each page
                    e.Graphics.DrawString("Page " + pageNumber, new Font("Arial", 11), Brushes.Black, 50, 1050);
                    //If the row index is less than the number of rows there are more pages
                    if (rowIndex < userProgressDataGridView.Rows.Count)
                    {
                        //Repeat for next page
                        e.HasMorePages = true;
                        //Increment page number
                        pageNumber++;
                    }
                    //If last page draw the number of total marks
                    else e.Graphics.DrawString(totalMarksLabel.Text, new Font("Arial", 11), Brushes.Black, 620, 1050);
                };
                PrintPreviewDialog.Document = printDocument;
                PrintPreviewDialog.ShowDialog();
            }
            else Tools.NothingToPrintMessage();
        }
    }
}
