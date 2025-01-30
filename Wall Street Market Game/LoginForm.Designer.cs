namespace Wall_Street_Market_Game
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            pictureBoxProfile = new PictureBox();
            menuStrip1 = new MenuStrip();
            eXITToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 164);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 193);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(164, 190);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(108, 23);
            txtPassword.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(164, 161);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(108, 23);
            txtUsername.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(86, 230);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(83, 28);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(175, 230);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(83, 28);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.Location = new Point(115, 55);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(100, 100);
            pictureBoxProfile.TabIndex = 6;
            pictureBoxProfile.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { eXITToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(345, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // eXITToolStripMenuItem
            // 
            eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            eXITToolStripMenuItem.Size = new Size(42, 20);
            eXITToolStripMenuItem.Text = "EXIT";
            eXITToolStripMenuItem.Click += eXITToolStripMenuItem_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 450);
            Controls.Add(pictureBoxProfile);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "LoginForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Button btnLogin;
        private Button btnRegister;
        private PictureBox pictureBoxProfile;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem eXITToolStripMenuItem;
    }
}
