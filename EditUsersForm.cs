using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;


namespace quizics
{
    public partial class EditUsersForm : Form
    {
        public EditUsersForm()
        {
            InitializeComponent();
            UpdateGrid();
        }

        //Updates the DataGridView to show the data in the database
        void UpdateGrid()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Tools.connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Users", connection))
                {
                    try
                    {
                        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        userDataGridView.DataSource = dataTable;
                        //Set headers
                        userDataGridView.Columns["username"].HeaderText = "Username";
                        userDataGridView.Columns["password"].HeaderText = "Password";
                        userDataGridView.Columns["yearGroup"].HeaderText = "Year Group";
                        userDataGridView.Columns["userID"].Visible = false;
                        //Add the delete checkbox column if it doesn't already exist
                        if (!userDataGridView.Columns.Contains("deleteCheckBox"))
                            userDataGridView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "deleteCheckBox", HeaderText = "Delete?" });
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            //Open new form with MDI parent
            AddUserForm addUserForm = new AddUserForm { MdiParent = this.MdiParent };
            //Update the grid when the form is closed
            addUserForm.FormClosed += delegate { UpdateGrid(); };
            addUserForm.Show();
            UpdateGrid();
        }

        private void userDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //If row index is -1, grid is still updating so do not update database
            //Only update database if value changed, not when delete checkbox checked
            if (e.RowIndex != -1 && userDataGridView.Columns[e.ColumnIndex].Name != "deleteCheckBox")
            {
                using (SQLiteConnection connection = new SQLiteConnection(Tools.connectionString))
                {
                    string changedColumn = userDataGridView.Columns[e.ColumnIndex].Name;
                    using (SQLiteCommand command = new SQLiteCommand("UPDATE Users SET " + changedColumn + "=@newValue WHERE userID=@userID", connection))
                    {
                        command.Parameters.AddWithValue("newValue", userDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        command.Parameters.AddWithValue("userID", Convert.ToInt32(userDataGridView.Rows[e.RowIndex].Cells["userID"].Value));
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
            bool currentUserDeleted = false;
            foreach (DataGridViewRow row in userDataGridView.Rows)
            {
                //Check if delete checkbox is checked
                if (Convert.ToBoolean(row.Cells["deleteCheckBox"].Value))
                {
                    using (SQLiteConnection connection = new SQLiteConnection(Tools.connectionString))
                    {
                        using (SQLiteCommand command = new SQLiteCommand("DELETE FROM UserQuestion WHERE userID=@userID; DELETE FROM Users WHERE userID=@userID", connection))
                        {
                            command.Parameters.AddWithValue("userID", row.Cells["userID"].Value);
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
                    //Current user was deleted if the ID of a checked user is the same as the current logged in user's ID
                    currentUserDeleted = (Convert.ToInt32(row.Cells["userID"].Value) == MainMDI.userID);
                }
            }
            //If the current user was deleted, exit
            if (currentUserDeleted) Application.Exit();
            //Update data in grid to show changes
            UpdateGrid();
        }

        private void studentProgressButton_Click(object sender, EventArgs e)
        {
            //Get the ID of the user currently selected
            int userID = Convert.ToInt32(userDataGridView.Rows[userDataGridView.CurrentCell.RowIndex].Cells["userID"].Value);
            new UserProgressForm(userID) { MdiParent = MdiParent }.Show();
        }
    }
}
