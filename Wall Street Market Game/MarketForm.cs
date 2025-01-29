using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace Wall_Street_Market_Game
{
    public partial class MarketForm : Form
    {
        private Dictionary<string, int> playerInventory = new Dictionary<string, int>();
        private Dictionary<string, int> marketPrices;
        private User currentUser;
        private System.Windows.Forms.Timer marketTimer;
        private Random random = new Random();
        private System.Windows.Forms.Timer autoSaveTimer;
        public MarketForm(User user)
        {
            currentUser = user;
            InitializeComponent();
            InitializeMarketPrices();
            LoadUsers();
            PopulateMarketList();
            UpdateUI();

            // Load Profile Picture
            if (File.Exists(currentUser.ProfilePicturePath))
            {
                pictureBoxProfile.Image = Image.FromFile(currentUser.ProfilePicturePath);
            }
            else
            {
                pictureBoxProfile.Image = Image.FromFile("default.png");
            }

            // Make Profile Picture Clickable for Editing
            pictureBoxProfile.Click += new EventHandler(ChangeProfilePicture);

            // Start Market Price Timer
            marketTimer = new System.Windows.Forms.Timer();
            marketTimer.Interval = 5000; // Updates prices every 5 seconds
            marketTimer.Tick += MarketTimer_Tick;
            marketTimer.Start();
            lblNews.Text = "";

        }

        private void ChangeProfilePicture(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentUser.ProfilePicturePath = openFileDialog.FileName;
                pictureBoxProfile.Image = Image.FromFile(openFileDialog.FileName);
                SaveUsers(); // Save updated profile picture path
            }
        }

        private void InitializeMarketPrices()
        {
            marketPrices = new Dictionary<string, int>()
            {
                { "Apple Stocks", random.Next(100, 200) },
                { "Gold", random.Next(1700, 1900) },
                { "Oil", random.Next(50, 100) },
                { "Tesla Stocks", random.Next(600, 700) },
                { "Bitcoin", random.Next(40000, 45000) }
            };
        }



        private void PopulateMarketList()
        {
            lstMarket.Items.Clear();
            foreach (var item in marketPrices)
            {
                lstMarket.Items.Add($"{item.Key} - ${item.Value}");
            }
        }

        private List<User> LoadUsers()
        {
            if (!File.Exists("users.json")) return new List<User>();

            string json = File.ReadAllText("users.json");

            if (string.IsNullOrWhiteSpace(json)) return new List<User>();

            try
            {
                List<User> users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();

                // Ensure each user has an inventory (prevent null issues)
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

        private void SaveUsers()
        {
            List<User> users = new List<User>();

            if (File.Exists("users.json"))
            {
                string json = File.ReadAllText("users.json");
                users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }

            User existingUser = users.FirstOrDefault(u => u.Username == currentUser.Username);
            if (existingUser != null)
            {
                existingUser.Money = currentUser.Money;
                existingUser.Inventory = currentUser.Inventory;
                existingUser.ProfilePicturePath = currentUser.ProfilePicturePath;
            }
            else
            {
                users.Add(currentUser);
            }

            File.WriteAllText("users.json", JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }));
        }
        private void InitializeAutoSave()
        {
            autoSaveTimer = new System.Windows.Forms.Timer();
            autoSaveTimer.Interval = 10000; // Auto-save every 10 seconds
            autoSaveTimer.Tick += AutoSave_Tick;
            autoSaveTimer.Start();
        }
        private void AutoSave_Tick(object sender, EventArgs e)
        {
            SaveUsers();
        }
        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (lstMarket.SelectedItem == null) return;

            string selectedItem = lstMarket.SelectedItem.ToString();
            string item = selectedItem.Split('-')[0].Trim();
            int quantity = (int)numQuantity.Value;

            if (!marketPrices.ContainsKey(item))
            {
                MessageBox.Show("Invalid selection. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cost = marketPrices[item] * quantity;

            if (currentUser.Money >= cost)
            {
                currentUser.Money -= cost;

                // Ensure Inventory is properly updated
                if (currentUser.Inventory == null)
                    currentUser.Inventory = new Dictionary<string, int>();

                if (currentUser.Inventory.ContainsKey(item))
                    currentUser.Inventory[item] += quantity;
                else
                    currentUser.Inventory[item] = quantity;

                SaveUsers(); // Save updated inventory
                UpdateUI();  // Refresh UI to show changes
            }
            else
            {
                MessageBox.Show("Not enough money!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (lstMarket.SelectedItem == null) return;

            string selectedItem = lstMarket.SelectedItem.ToString();
            string item = selectedItem.Split('-')[0].Trim();
            int quantity = (int)numQuantity.Value;

            if (!marketPrices.ContainsKey(item))
            {
                MessageBox.Show("Invalid selection. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentUser.Inventory.ContainsKey(item) && currentUser.Inventory[item] >= quantity)
            {
                int earnings = marketPrices[item] * quantity;
                currentUser.Money += earnings;

                currentUser.Inventory[item] -= quantity;
                if (currentUser.Inventory[item] <= 0) // Remove item if quantity is 0
                    currentUser.Inventory.Remove(item);

                SaveUsers();
                UpdateUI();
            }
            else
            {
                MessageBox.Show("Not enough stock to sell!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateUI()
        {
            lblBalance.Text = "Balance: $" + currentUser.Money;
            lstInventory.Items.Clear();

            if (currentUser.Inventory == null)
                currentUser.Inventory = new Dictionary<string, int>(); // Ensure it's initialized

            foreach (var item in currentUser.Inventory)
            {
                lstInventory.Items.Add($"{item.Key}: {item.Value}"); // Show items in inventory list
            }
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            List<User> users = LoadUsers(); // Ensure this returns List<User>

            if (users.Count == 0)
            {
                MessageBox.Show("No players found!", "Leaderboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Sort players by money (Descending)
            var sortedUsers = users.OrderByDescending(u => u.Money).ToList();

            // Create leaderboard string
            StringBuilder leaderboard = new StringBuilder();
            leaderboard.AppendLine("🏆 High Scores 🏆\n");

            int rank = 1;
            foreach (var user in sortedUsers)
            {
                leaderboard.AppendLine($"{rank}. {user.Username} - ${user.Money}");
                rank++;
            }

            // Show leaderboard
            MessageBox.Show(leaderboard.ToString(), "Leaderboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MarketTimer_Tick(object sender, EventArgs e)
        {
            // Update market prices
            foreach (var item in marketPrices.Keys.ToList())
            {
                int change = random.Next(-50, 51);
                marketPrices[item] = Math.Max(1, marketPrices[item] + change);
            }

            // Introduce random events (20% chance)
            int eventChance = random.Next(0, 100);
            if (eventChance < 20)
            {
                ApplyRandomEvent();
            }

            PopulateMarketList();
            SaveUsers();
        }

        private void ApplyRandomEvent()
        {
            string[] events = {
                "📈 Apple launches a new iPhone → Apple Stocks increase!",
                "🚨 Bitcoin gets banned → Bitcoin crashes!",
                "🏅 Gold market uncertainty → Gold prices rise!",
                "🛢️ Oil supply shortage → Oil prices skyrocket!",
                "⚡ Tesla announces layoffs → Tesla Stocks drop!"
            };

            int eventIndex = random.Next(events.Length);
            string selectedEvent = events[eventIndex];
            
            // Display event in lblNews
            lblNews.Text = selectedEvent;

            // Adjust market prices based on event
            if (selectedEvent.Contains("Apple")) marketPrices["Apple Stocks"] += random.Next(50, 100);
            if (selectedEvent.Contains("Bitcoin")) marketPrices["Bitcoin"] -= random.Next(5000, 10000);
            if (selectedEvent.Contains("Gold")) marketPrices["Gold"] += random.Next(50, 150);
            if (selectedEvent.Contains("Oil")) marketPrices["Oil"] += random.Next(20, 50);
            if (selectedEvent.Contains("Tesla")) marketPrices["Tesla Stocks"] -= random.Next(50, 100);

            // Optional: Make the news disappear after 5 seconds
            var newsTimer = new System.Windows.Forms.Timer();
            newsTimer.Interval = 5000; // 5 seconds
            newsTimer.Tick += (sender, e) =>
            {
                lblNews.Text = ""; // Clear news after 5 seconds
                newsTimer.Stop();
            };
            newsTimer.Start();
        }
        private void btnExitGame_Click(object sender, EventArgs e)
        {
            SaveUsers(); // Save progress before exiting
            Application.Exit();
        }
    }
}
