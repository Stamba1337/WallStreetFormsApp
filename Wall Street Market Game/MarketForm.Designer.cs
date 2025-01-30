namespace Wall_Street_Market_Game
{
    partial class MarketForm
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
            lstMarket = new ListBox();
            numQuantity = new NumericUpDown();
            btnBuy = new Button();
            btnSell = new Button();
            lblBalance = new Label();
            lstInventory = new ListBox();
            lblInventory = new Label();
            pictureBoxProfile = new PictureBox();
            btnHighScores = new Button();
            btnExitGame = new Button();
            label1 = new Label();
            lblNews = new Label();
            menuStrip1 = new MenuStrip();
            eXITToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lstMarket
            // 
            lstMarket.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lstMarket.FormattingEnabled = true;
            lstMarket.ItemHeight = 30;
            lstMarket.Location = new Point(320, 50);
            lstMarket.Name = "lstMarket";
            lstMarket.Size = new Size(360, 274);
            lstMarket.TabIndex = 0;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(554, 345);
            numQuantity.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(126, 23);
            numQuantity.TabIndex = 1;
            // 
            // btnBuy
            // 
            btnBuy.BackColor = Color.MediumSpringGreen;
            btnBuy.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            btnBuy.Location = new Point(320, 345);
            btnBuy.Name = "btnBuy";
            btnBuy.Size = new Size(111, 46);
            btnBuy.TabIndex = 2;
            btnBuy.Text = "BUY";
            btnBuy.UseVisualStyleBackColor = false;
            btnBuy.Click += btnBuy_Click;
            // 
            // btnSell
            // 
            btnSell.BackColor = Color.Red;
            btnSell.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            btnSell.Location = new Point(437, 345);
            btnSell.Name = "btnSell";
            btnSell.Size = new Size(111, 46);
            btnSell.TabIndex = 3;
            btnSell.Text = "SELL";
            btnSell.UseVisualStyleBackColor = false;
            btnSell.Click += btnSell_Click;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBalance.Location = new Point(118, 42);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(85, 30);
            lblBalance.TabIndex = 4;
            lblBalance.Text = "Balance";
            // 
            // lstInventory
            // 
            lstInventory.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstInventory.FormattingEnabled = true;
            lstInventory.ItemHeight = 25;
            lstInventory.Location = new Point(12, 170);
            lstInventory.Name = "lstInventory";
            lstInventory.SelectionMode = SelectionMode.None;
            lstInventory.Size = new Size(302, 154);
            lstInventory.TabIndex = 5;
            // 
            // lblInventory
            // 
            lblInventory.AutoSize = true;
            lblInventory.Location = new Point(12, 152);
            lblInventory.Name = "lblInventory";
            lblInventory.Size = new Size(57, 15);
            lblInventory.TabIndex = 6;
            lblInventory.Text = "Inventory";
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.Location = new Point(12, 21);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(100, 100);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxProfile.TabIndex = 7;
            pictureBoxProfile.TabStop = false;
            // 
            // btnHighScores
            // 
            btnHighScores.BackColor = SystemColors.MenuHighlight;
            btnHighScores.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHighScores.Location = new Point(118, 75);
            btnHighScores.Name = "btnHighScores";
            btnHighScores.Size = new Size(155, 46);
            btnHighScores.TabIndex = 8;
            btnHighScores.Text = "SHOW LEADERBOARD";
            btnHighScores.UseVisualStyleBackColor = false;
            btnHighScores.Click += btnHighScores_Click;
            // 
            // btnExitGame
            // 
            btnExitGame.BackColor = SystemColors.ActiveCaptionText;
            btnExitGame.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExitGame.ForeColor = SystemColors.ButtonFace;
            btnExitGame.Location = new Point(687, 409);
            btnExitGame.Name = "btnExitGame";
            btnExitGame.Size = new Size(101, 38);
            btnExitGame.TabIndex = 9;
            btnExitGame.Text = "Logout";
            btnExitGame.UseVisualStyleBackColor = false;
            btnExitGame.Click += btnExitGame_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 5);
            label1.Name = "label1";
            label1.Size = new Size(235, 30);
            label1.TabIndex = 10;
            label1.Text = "LATEST MARKET NEWS";
            // 
            // lblNews
            // 
            lblNews.AutoSize = true;
            lblNews.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNews.Location = new Point(3, 38);
            lblNews.MaximumSize = new Size(289, 0);
            lblNews.Name = "lblNews";
            lblNews.Size = new Size(52, 21);
            lblNews.TabIndex = 11;
            lblNews.Text = "label2";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { eXITToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // eXITToolStripMenuItem
            // 
            eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            eXITToolStripMenuItem.Size = new Size(42, 20);
            eXITToolStripMenuItem.Text = "EXIT";
            eXITToolStripMenuItem.Click += eXITToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblNews);
            panel1.Location = new Point(12, 330);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 108);
            panel1.TabIndex = 13;
            // 
            // MarketForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(btnExitGame);
            Controls.Add(btnHighScores);
            Controls.Add(pictureBoxProfile);
            Controls.Add(lblInventory);
            Controls.Add(lstInventory);
            Controls.Add(lblBalance);
            Controls.Add(btnSell);
            Controls.Add(btnBuy);
            Controls.Add(numQuantity);
            Controls.Add(lstMarket);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "MarketForm";
            Text = "MarketForm";
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstMarket;
        private NumericUpDown numQuantity;
        private Button btnBuy;
        private Button btnSell;
        private Label lblBalance;
        private ListBox lstInventory;
        private Label lblInventory;
        private PictureBox pictureBoxProfile;
        private Button btnHighScores;
        private Button btnExitGame;
        private Label label1;
        private Label lblNews;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem eXITToolStripMenuItem;
        private Panel panel1;
    }
}