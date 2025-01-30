using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Wall_Street_Market_Game
{
    public partial class MarketForm : Form
    {
        private Dictionary<string, int> marketPrices;
        private User currentUser = SessionManager.CurrentUser;
        private System.Windows.Forms.Timer marketTimer;
        private Random random = new Random();
        private System.Windows.Forms.Timer autoSaveTimer;

        public MarketForm()
        {
            InitializeComponent();

            if (currentUser == null)
            {
                MessageBox.Show("No user is logged in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            InitializeMarketPrices();
            PopulateMarketList();
            UpdateUI();

            // Load Profile Picture

            pictureBoxProfile.Image = SessionManager.GetUserProfileImage();
            pictureBoxProfile.Click += new EventHandler(ChangeProfilePicture);

            // Start Market Price Timer
            marketTimer = new System.Windows.Forms.Timer();
            marketTimer.Interval = 5000;
            marketTimer.Tick += MarketTimer_Tick;
            marketTimer.Start();

            lblNews.Text = "";

            InitializeAutoSave();
        }

        private void ChangeProfilePicture(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentUser.ProfilePicturePath = openFileDialog.FileName;
                pictureBoxProfile.Image = Image.FromFile(openFileDialog.FileName);
                SessionManager.UpdateUser();
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

        private void InitializeAutoSave()
        {
            autoSaveTimer = new System.Windows.Forms.Timer();
            autoSaveTimer.Interval = 10000; // Auto-save every 10 seconds
            autoSaveTimer.Tick += AutoSave_Tick;
            autoSaveTimer.Start();
        }

        private void AutoSave_Tick(object sender, EventArgs e)
        {
            SessionManager.UpdateUser();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (lstMarket.SelectedItem == null) return;

            string selectedItem = lstMarket.SelectedItem.ToString();
            string item = selectedItem.Split('-')[0].Trim();
            int quantity = (int)numQuantity.Value;

            // ❌ Prevent buying zero or negative quantities
            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!marketPrices.ContainsKey(item))
            {
                MessageBox.Show("Invalid selection. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cost = marketPrices[item] * quantity;

            // ❌ Ensure the user has enough money
            if (currentUser.Money >= cost)
            {
                currentUser.Money -= cost;

                if (!currentUser.Inventory.ContainsKey(item))
                    currentUser.Inventory[item] = 0;

                currentUser.Inventory[item] += quantity;

                SessionManager.UpdateUser();
                UpdateUI();
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

            // ❌ Prevent selling zero or negative quantities
            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!marketPrices.ContainsKey(item))
            {
                MessageBox.Show("Invalid selection. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ❌ Ensure user owns enough stock to sell
            if (currentUser.Inventory.ContainsKey(item) && currentUser.Inventory[item] >= quantity)
            {
                int earnings = marketPrices[item] * quantity;
                currentUser.Money += earnings;
                currentUser.Inventory[item] -= quantity;

                if (currentUser.Inventory[item] <= 0)
                    currentUser.Inventory.Remove(item);

                SessionManager.UpdateUser();
                UpdateUI();
            }
            else
            {
                MessageBox.Show("Not enough stock to sell!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateUI()
        {
            lblBalance.Text = $"Balance: ${currentUser.Money}";
            lstInventory.Items.Clear();

            foreach (var item in currentUser.Inventory)
            {
                lstInventory.Items.Add($"{item.Key}: {item.Value}");
            }
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            List<User> users = UserManager.LoadUsers();

            if (users.Count == 0)
            {
                MessageBox.Show("No players found!", "Leaderboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sortedUsers = users.OrderByDescending(u => u.Money).ToList();
            StringBuilder leaderboard = new StringBuilder();
            leaderboard.AppendLine("🏆 High Scores 🏆\n");

            int rank = 1;
            foreach (var user in sortedUsers)
            {
                leaderboard.AppendLine($"{rank}. {user.Username} - ${user.Money}");
                rank++;
            }

            MessageBox.Show(leaderboard.ToString(), "Leaderboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MarketTimer_Tick(object sender, EventArgs e)
        {
            foreach (var item in marketPrices.Keys.ToList())
            {
                int change = random.Next(-50, 51);
                marketPrices[item] = Math.Max(1, marketPrices[item] + change);
            }

            int eventChance = random.Next(0, 100);
            if (eventChance < 20) // 20% chance of a market event occurring
            {
                ApplyRandomEvent();
            }

            PopulateMarketList();
            SessionManager.UpdateUser(); // Use SessionManager instead of UserManager
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

            lblNews.Text = selectedEvent;

            if (selectedEvent.Contains("Apple")) marketPrices["Apple Stocks"] += random.Next(50, 100);
            if (selectedEvent.Contains("Bitcoin")) marketPrices["Bitcoin"] -= random.Next(5000, 10000);
            if (selectedEvent.Contains("Gold")) marketPrices["Gold"] += random.Next(50, 150);
            if (selectedEvent.Contains("Oil")) marketPrices["Oil"] += random.Next(20, 50);
            if (selectedEvent.Contains("Tesla")) marketPrices["Tesla Stocks"] -= random.Next(50, 100);

            var newsTimer = new System.Windows.Forms.Timer
            {
                Interval = 5000 // 5 seconds
            };
            newsTimer.Tick += (sender, e) =>
            {
                lblNews.Text = "";
                newsTimer.Stop();
            };
            newsTimer.Start();
        }

        private void btnExitGame_Click(object sender, EventArgs e)
        {
            SessionManager.UpdateUser();
            Application.Exit();
        }
    }
}
