namespace Wall_Street_Market_Game
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            label4 = new Label();
            numStartingMoney = new NumericUpDown();
            btnRegister = new Button();
            btnCancel = new Button();
            btnSelectImage = new PictureBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numStartingMoney).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnSelectImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 147);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 181);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 215);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 2;
            label3.Text = "Confirm Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(176, 143);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(176, 177);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 4;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(176, 211);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(100, 23);
            txtConfirmPassword.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 249);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 6;
            label4.Text = "Starting Money:";
            // 
            // numStartingMoney
            // 
            numStartingMoney.Location = new Point(166, 245);
            numStartingMoney.Name = "numStartingMoney";
            numStartingMoney.Size = new Size(120, 23);
            numStartingMoney.TabIndex = 7;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(73, 282);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(177, 282);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Image = (Image)resources.GetObject("btnSelectImage.Image");
            btnSelectImage.InitialImage = (Image)resources.GetObject("btnSelectImage.InitialImage");
            btnSelectImage.Location = new Point(116, 37);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(100, 100);
            btnSelectImage.SizeMode = PictureBoxSizeMode.StretchImage;
            btnSelectImage.TabIndex = 10;
            btnSelectImage.TabStop = false;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(57, 19);
            label5.Name = "label5";
            label5.Size = new Size(243, 15);
            label5.TabIndex = 11;
            label5.Text = "CLICK THE CAT TO CHOOSE PROFILE IMAGE";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 450);
            Controls.Add(label5);
            Controls.Add(btnSelectImage);
            Controls.Add(btnCancel);
            Controls.Add(btnRegister);
            Controls.Add(numStartingMoney);
            Controls.Add(label4);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)numStartingMoney).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnSelectImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Label label4;
        private NumericUpDown numStartingMoney;
        private Button btnRegister;
        private Button btnCancel;
        private PictureBox btnSelectImage;
        private Label label5;
    }
}