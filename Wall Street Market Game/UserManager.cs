using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Wall_Street_Market_Game
{
    public static class UserManager
    {
        private static readonly string FilePath = "users.json";

        // Load users from JSON file
        public static List<User> LoadUsers()
        {
            if (!File.Exists(FilePath))
                return new List<User>();

            string json = File.ReadAllText(FilePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<User>();

            try
            {
                List<User> users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();

                // Ensure inventory is initialized to avoid null errors
                foreach (var user in users)
                {
                    if (user.Inventory == null)
                        user.Inventory = new Dictionary<string, int>();
                }

                return users;
            }
            catch (JsonException)
            {
                MessageBox.Show("Error loading user data! The file may be corrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<User>();
            }
        }

        // Save users to JSON file
        public static void SaveUsers(List<User> users)
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        // Register a new user
        public static bool RegisterUser(User newUser)
        {
            List<User> users = LoadUsers();

            if (users.Exists(u => u.Username == newUser.Username))
            {
                MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            users.Add(newUser);
            SaveUsers(users);
            return true;
        }

        // Verify user login
        public static User VerifyUser(string username, string password)
        {
            List<User> users = LoadUsers();
            return users.Find(u => u.Username == username && u.Password == password);
        }
        public static void UpdateUser(User updatedUser)
        {
            List<User> users = LoadUsers();
            User existingUser = users.Find(u => u.Username == updatedUser.Username);

            if (existingUser != null)
            {
                existingUser.Money = updatedUser.Money;
                existingUser.Inventory = updatedUser.Inventory;
                existingUser.ProfilePicturePath = updatedUser.ProfilePicturePath;
                SaveUsers(users);
            }
        }
    }
}
