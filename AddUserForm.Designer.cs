namespace quizics
{
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addUserButton = new System.Windows.Forms.Button();
            this.teacherCheckBox = new System.Windows.Forms.CheckBox();
            this.initialLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.firstInitialTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.yearGroupLabel = new System.Windows.Forms.Label();
            this.yearGroupComboBox = new System.Windows.Forms.ComboBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(111, 190);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(66, 23);
            this.addUserButton.TabIndex = 5;
            this.addUserButton.Text = "Add User";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // teacherCheckBox
            // 
            this.teacherCheckBox.AutoSize = true;
            this.teacherCheckBox.Location = new System.Drawing.Point(12, 128);
            this.teacherCheckBox.Name = "teacherCheckBox";
            this.teacherCheckBox.Size = new System.Drawing.Size(66, 17);
            this.teacherCheckBox.TabIndex = 3;
            this.teacherCheckBox.Text = "Teacher";
            this.teacherCheckBox.UseVisualStyleBackColor = true;
            this.teacherCheckBox.CheckedChanged += new System.EventHandler(this.teacherCheckBox_CheckedChanged);
            // 
            // initialLabel
            // 
            this.initialLabel.AutoSize = true;
            this.initialLabel.Location = new System.Drawing.Point(12, 9);
            this.initialLabel.Name = "initialLabel";
            this.initialLabel.Size = new System.Drawing.Size(34, 13);
            this.initialLabel.TabIndex = 7;
            this.initialLabel.Text = "Initial:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 63);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "Password:";
            // 
            // firstInitialTextBox
            // 
            this.firstInitialTextBox.Location = new System.Drawing.Point(12, 25);
            this.firstInitialTextBox.MaxLength = 1;
            this.firstInitialTextBox.Name = "firstInitialTextBox";
            this.firstInitialTextBox.Size = new System.Drawing.Size(53, 20);
            this.firstInitialTextBox.TabIndex = 0;
            this.firstInitialTextBox.TextChanged += new System.EventHandler(this.username_Changed);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(12, 79);
            this.passwordTextBox.MaxLength = 50;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(165, 20);
            this.passwordTextBox.TabIndex = 2;
            // 
            // yearGroupLabel
            // 
            this.yearGroupLabel.AutoSize = true;
            this.yearGroupLabel.Location = new System.Drawing.Point(12, 152);
            this.yearGroupLabel.Name = "yearGroupLabel";
            this.yearGroupLabel.Size = new System.Drawing.Size(64, 13);
            this.yearGroupLabel.TabIndex = 7;
            this.yearGroupLabel.Text = "Year Group:";
            // 
            // yearGroupComboBox
            // 
            this.yearGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearGroupComboBox.FormattingEnabled = true;
            this.yearGroupComboBox.Items.AddRange(new object[] {
            "12",
            "13"});
            this.yearGroupComboBox.Location = new System.Drawing.Point(82, 149);
            this.yearGroupComboBox.Name = "yearGroupComboBox";
            this.yearGroupComboBox.Size = new System.Drawing.Size(38, 21);
            this.yearGroupComboBox.TabIndex = 4;
            this.yearGroupComboBox.SelectedIndexChanged += new System.EventHandler(this.username_Changed);
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(74, 25);
            this.lastNameTextBox.MaxLength = 11;
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(103, 20);
            this.lastNameTextBox.TabIndex = 1;
            this.lastNameTextBox.TextChanged += new System.EventHandler(this.username_Changed);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(74, 9);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.lastNameLabel.TabIndex = 9;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 180);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 10;
            this.usernameLabel.Text = "Username:";
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 225);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.yearGroupComboBox);
            this.Controls.Add(this.yearGroupLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.firstInitialTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.initialLabel);
            this.Controls.Add(this.teacherCheckBox);
            this.Controls.Add(this.addUserButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddUserForm";
            this.Text = "Add User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.CheckBox teacherCheckBox;
        private System.Windows.Forms.Label initialLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox firstInitialTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label yearGroupLabel;
        private System.Windows.Forms.ComboBox yearGroupComboBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label usernameLabel;
    }
}