using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace quizics
{
    public partial class AddUserForm : Form
    {
        int yearGroup;
        string username;

        public AddUserForm()
        {
            InitializeComponent();
            yearGroupComboBox.Text = "13";
            yearGroup = 13;
        }

        /// <summary>
        /// Print the details of the user being added
        /// </summary>
        public void Print()
        {
            PrintPreviewDialog PrintPreviewDialog = new PrintPreviewDialog();
            PrintDocument printDocument = new PrintDocument();
            //Declare anonymous method that triggers when the document is printed
            printDocument.PrintPage += delegate(object sender, PrintPageEventArgs e)
            {
                e.Graphics.DrawString("Username: " + username,
                    new Font("Arial", 12), Brushes.Black, 20, 20);
                e.Graphics.DrawString("Password: " + passwordTextBox.Text,
                    new Font("Arial", 12), Brushes.Black, 20, 40);
            };
            PrintPreviewDialog.Document = printDocument;
            PrintPreviewDialog.ShowDialog();
        }

        string usernameLabelText
        {
            set { usernameLabel.Text = "Username:\r\n" + value; }
        }

        private void teacherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //If teacher, disable yeargroup setting
            yearGroupLabel.Enabled = !teacherCheckBox.Checked;
            yearGroupComboBox.Enabled = !teacherCheckBox.Checked;
            //Update username
            username_Changed(null, null);
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            //Check that the username and password are long enough - maximum length already handled by textbox properties
            if (username.Length >= 5 && passwordTextBox.Text.Length >= 8)
            {
                    using (SqlConnection connection = new SqlConnection(Tools.connectionString))
                    {
                        using (SqlCommand command = new SqlCommand("INSERT INTO Users VALUES "
                            + "(@username, @password, @yearGroup)", connection))
                        {
                            command.Parameters.AddWithValue("username", username);
                            command.Parameters.AddWithValue("password", passwordTextBox.Text);
                            command.Parameters.AddWithValue("yearGroup", yearGroup);
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
            else if (username.Length < 5)
            {
                MessageBox.Show("Username must be at least 5 characters", "Username too short",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (passwordTextBox.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters", "Password too short", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Print the details of the user added?", "User added", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
                Print();
            //Close form when finished
            Close();
        }

        /// <summary>
        /// Update the username label as it is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void username_Changed(object sender, EventArgs e)
        {
            //Convert to lower case
            username = (firstInitialTextBox.Text + lastNameTextBox.Text).ToLower();
            usernameLabelText = username;
            if (teacherCheckBox.Checked) yearGroup = 0;
            else yearGroup = int.Parse(yearGroupComboBox.Text);
        }
    }
}
