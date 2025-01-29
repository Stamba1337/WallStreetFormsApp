using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;

namespace Wall_Street_Market_Game
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            List<User> users = LoadUsers();
            User user = users.Find(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(user.ProfilePicturePath))
            {
                pictureBoxProfile.Image = Image.FromFile(user.ProfilePicturePath);
            }
            MarketForm marketForm = new MarketForm(user);
            marketForm.Show();
            this.Hide();
        }

        private List<User> LoadUsers()
        {
            if (!File.Exists("users.json")) return new List<User>();

            string json = File.ReadAllText("users.json");

            if (string.IsNullOrWhiteSpace(json)) // Check if the file is empty
                return new List<User>();

            try
            {
                return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch (JsonException)
            {
                MessageBox.Show("Error loading user data! The file may be corrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<User>();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}
