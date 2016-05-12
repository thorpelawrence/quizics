using System;
using System.Windows.Forms;

namespace quizics
{
    public partial class MainMDI : Form
    {
        public static int userID;

        public MainMDI()
        {
            InitializeComponent();
            //Start with the MDI hidden
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }

        /// <summary>
        /// Show the login form when loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMDI_Load(object sender, EventArgs e)
        {
            using (UserLoginForm userLoginForm = new UserLoginForm())
            {
                //If user is valid the login dialog will close with DialogResult.OK
                if (userLoginForm.ShowDialog() == DialogResult.OK)
                {
                    userID = userLoginForm.userID;
                    //Check if user is a teacher
                    if (userLoginForm.teacherUser)
                    {
                        //If teacher, show the username as teacher
                        try
                        {
                            usernameToolStripMenuItem.Text = Tools.GetUserData(userID)["username"] + ": Teacher";
                        }
                        catch { return; }
                    }
                    else
                    {
                        //If not teacher (student), show the username as student
                        try
                        {
                            usernameToolStripMenuItem.Text = Tools.GetUserData(userID)["username"] + ": Student "
                                + "(Year " + Tools.GetUserData(userID)["yearGroup"] + ")";
                        }
                        catch { return; }
                        //Hide settings
                        settingsToolStripMenuItem.Visible = false;
                    }
                    //MDI starts minimized - if logged in, restore it
                    WindowState = FormWindowState.Maximized;
                    ShowInTaskbar = true;
                }
                //Otherwise, exit application
                else Application.Exit();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close program
            Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display information about program
            MessageBox.Show("Quizics: Physics Quiz\r\nCOMP4\r\nLawrence Thorpe 2015-16",
                "Quizics",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void suvatQuizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open new form with MDI parent
            new SUVATQuizForm { MdiParent = this }.Show();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check which child form to call print method from
            if (ActiveMdiChild != null)
            {
                switch (ActiveMdiChild.Name)
                {
                    //Cast to correct form so its Print method is called
                    case "QuizForm":
                        ((QuizForm)ActiveMdiChild).Print();
                        break;
                    case "SUVATQuizForm":
                        ((SUVATQuizForm)ActiveMdiChild).Print();
                        break;
                    case "AddUserForm":
                        ((AddUserForm)ActiveMdiChild).Print();
                        break;
                    case "UserProgressForm":
                        ((UserProgressForm)ActiveMdiChild).Print();
                        break;
                    default:
                        //If not one of the above forms, show message
                        Tools.NothingToPrintMessage();
                        break;
                }
            }
            //If no form is active, show message
            else Tools.NothingToPrintMessage();
        }

        private void quizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Gets the number of questions to use from manipulating the menu item text (first 2 characters, remove whitespace)
            int numberOfQuestions = int.Parse(sender.ToString().Substring(0,2).Trim());
            //Open new form with MDI parent
            new QuizForm(numberOfQuestions) { MdiParent = this }.Show();
        }

        private void editQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditQuestionsForm editQuestionsForm = new EditQuestionsForm();
            //Check if an instance is already open - only allow 1 at a time
            if (Application.OpenForms[editQuestionsForm.Name] == null)
            {
                editQuestionsForm.MdiParent = this;
                editQuestionsForm.Show();
            }
            else
            {
                //If an instance is already open, focus it
                Application.OpenForms[editQuestionsForm.Name].Focus();
                Tools.AlreadyOpenMessage();
            }
        }

        private void editUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUsersForm editUsersForm = new EditUsersForm();
            //Check if an instance is already open - only allow 1 at a time
            if (Application.OpenForms[editUsersForm.Name] == null)
            {
                editUsersForm.MdiParent = this;
                editUsersForm.Show();
            }
            else
            {
                //If an instance is already open, focus it
                Application.OpenForms[editUsersForm.Name].Focus();
                Tools.AlreadyOpenMessage();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserPasswordForm userPasswordForm = new UserPasswordForm();
            //Check if an instance is already open - only allow 1 at a time
            if (Application.OpenForms[userPasswordForm.Name] == null)
            {
                userPasswordForm.MdiParent = this;
                userPasswordForm.Show();
            }
            else
            {
                //If an instance is already open, focus it
                Application.OpenForms[userPasswordForm.Name].Focus();
                Tools.AlreadyOpenMessage();
            }
        }
    }
}
