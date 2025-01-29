using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace Wall_Street_Market_Game
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
            numStartingMoney.Minimum = 100;
            numStartingMoney.Maximum = 10000;
            numStartingMoney.Value = 1000;

        }
        private string selectedImagePath = "default.png"; // Default image


        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int money = (int)numStartingMoney.Value;
            string profilepicture = selectedImagePath;

            User newUser = new User(username, password, money, profilepicture);
            List<User> users = LoadUsers();

            if (users.Exists(u => u.Username == username))
            {
                MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            users.Add(newUser);
            SaveUsers(users);

            MessageBox.Show($"User {username} registered with ${money}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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

        private void SaveUsers(List<User> users)
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("users.json", json);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                btnSelectImage.Image = Image.FromFile(selectedImagePath);
            }
        }
    }
}
