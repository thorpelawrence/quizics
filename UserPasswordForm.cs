using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace quizics
{
    public partial class UserPasswordForm : Form
    {
        public UserPasswordForm()
        {
            InitializeComponent();
        }

        void ChangePassword()
        {
            //Check that the user has confirmed their new password correctly
            if (confirmPasswordTextBox.Text == newPasswordTextBox.Text)
            {
                using (SQLiteConnection connection = new SQLiteConnection(Tools.connectionString))
                {
                    //Check if user entered current password matches actual current password
                    string password = "";
                    try
                    {
                        password = (string)Tools.GetUserData(MainMDI.userID)["password"];
                    }
                    catch { return; }
                    if (currentPasswordTextBox.Text == password)
                    {
                        if (MessageBox.Show("Are you sure you want to change password?", "Change password",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            using (SQLiteCommand command = new SQLiteCommand("UPDATE Users SET password=@password WHERE userID=@userID", connection))
                            {
                                command.Parameters.AddWithValue("password", newPasswordTextBox.Text);
                                command.Parameters.AddWithValue("userID", MainMDI.userID);
                                try
                                {
                                    connection.Open();
                                    command.ExecuteNonQuery();
                                    connection.Close();
                                }
                                catch (Exception ex) { MessageBox.Show(ex.Message); }
                                finally { connection.Close(); }
                            }
                            //Close the form when done
                            Close();
                        }
                    }
                    else
                    {
                        //Focus the password textbox so the user can correct it quickly
                        currentPasswordTextBox.Focus();
                        MessageBox.Show("Current password was not entered correctly", "Incorrect password");
                    }
                }
            }
            else
            {
                //Clear both new password textboxes
                newPasswordTextBox.Clear();
                confirmPasswordTextBox.Clear();
                MessageBox.Show("Passwords do not match", "Password confirmation failed");
            }
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ChangePassword();
        }
    }
}
