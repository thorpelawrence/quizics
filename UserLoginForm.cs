using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Drawing;

namespace quizics
{
    public partial class UserLoginForm : Form
    {
        public int userID;
        //Public so MainMDI can check if user is teacher
        public bool teacherUser = false;

        public UserLoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Return whether or not the entered password matches the password for the username, if not show message
        /// </summary>
        bool CheckPassword()
        {
            string password = "";
            try
            {
                password = (string)Tools.GetUserData(userID)["password"];
            }
            catch { return false; }
            if (password == passwordTextBox.Text) return true;
            else
            {
                passwordTextBox.BackColor = Color.Red;
                passwordTextBox.ForeColor = Color.White;
                MessageBox.Show("Password was not entered correctly", "Incorrect password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Focus and clear the text of the password textbox so the user can correct it quickly
                passwordTextBox.Text = "";
                passwordTextBox.Focus();
                passwordTextBox.BackColor = default(Color);
                passwordTextBox.ForeColor = default(Color);
                return false;
            }
        }

        /// <summary>
        /// Try to log in using the entered user details
        /// </summary>
        void Login()
        {
            using (SQLiteConnection connection = new SQLiteConnection(Tools.connectionString))
            {
                //Get the userID for the username given
                SQLiteCommand command = new SQLiteCommand("SELECT userID FROM Users WHERE username=@username", connection);
                command.Parameters.AddWithValue("username", usernameTextBox.Text);
                try
                {
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();
                    //There will be a row if there was a username found (SQL WHERE)
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            userID = Convert.ToInt32(reader["userID"]);
                        }
                        connection.Close();
                        //If the user has a yearGroup of 0, they are a teacher
                        try
                        {
                            if (Convert.ToInt32(Tools.GetUserData(userID)["yearGroup"]) == 0) teacherUser = true;
                            else teacherUser = false;
                        }
                        catch (Exception ex){ MessageBox.Show(ex.Message); }
                        //Check if password is correct, if not shows message
                        if (CheckPassword())
                        {
                            //Set result so MainMDI knows that login was successful
                            DialogResult = DialogResult.OK;
                            //Close form when done
                            Close();
                        }
                    }
                    else
                    {
                        //If no row, username not found so show message
                        MessageBox.Show("Username was not recognized", "Invalid username", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection.Close(); }
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Login();
        }
    }
}
