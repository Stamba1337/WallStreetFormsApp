using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Wall_Street_Market_Game
{
    public partial class RegisterForm : Form
    {
        private string selectedImagePath = null;

        public RegisterForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
            numStartingMoney.Minimum = 100;
            numStartingMoney.Maximum = 10000;
            numStartingMoney.Value = 1000;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            int money = (int)numStartingMoney.Value;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Username can only contain letters and numbers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string profilePicturePath = selectedImagePath ?? Path.Combine(Application.StartupPath, "default.png");

            string savedProfilePicturePath = Path.Combine(Application.StartupPath, "ProfilePicture.png");
            try
            {
                if (File.Exists(profilePicturePath)) // Ensure file exists
                {
                    File.Copy(profilePicturePath, savedProfilePicturePath, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving profile picture: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            User newUser = new User(username, password, money, savedProfilePicturePath);

            if (UserManager.RegisterUser(newUser))
            {
                MessageBox.Show($"User {username} registered with ${money}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                btnSelectImage.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void eCITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
