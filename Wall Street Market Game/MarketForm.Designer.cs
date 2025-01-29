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
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            SuspendLayout();
            // 
            // lstMarket
            // 
            lstMarket.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lstMarket.FormattingEnabled = true;
            lstMarket.ItemHeight = 17;
            lstMarket.Location = new Point(320, 41);
            lstMarket.Name = "lstMarket";
            lstMarket.Size = new Size(360, 276);
            lstMarket.TabIndex = 0;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(554, 336);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(126, 23);
            numQuantity.TabIndex = 1;
            // 
            // btnBuy
            // 
            btnBuy.BackColor = Color.MediumSpringGreen;
            btnBuy.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            btnBuy.Location = new Point(320, 336);
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
            btnSell.Location = new Point(437, 336);
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
            lblBalance.Location = new Point(118, 33);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(85, 30);
            lblBalance.TabIndex = 4;
            lblBalance.Text = "Balance";
            // 
            // lstInventory
            // 
            lstInventory.FormattingEnabled = true;
            lstInventory.ItemHeight = 15;
            lstInventory.Location = new Point(12, 148);
            lstInventory.Name = "lstInventory";
            lstInventory.SelectionMode = SelectionMode.None;
            lstInventory.Size = new Size(302, 169);
            lstInventory.TabIndex = 5;
            // 
            // lblInventory
            // 
            lblInventory.AutoSize = true;
            lblInventory.Location = new Point(12, 130);
            lblInventory.Name = "lblInventory";
            lblInventory.Size = new Size(57, 15);
            lblInventory.TabIndex = 6;
            lblInventory.Text = "Inventory";
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.Location = new Point(12, 12);
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
            btnHighScores.Location = new Point(118, 66);
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
            btnExitGame.Location = new Point(687, 400);
            btnExitGame.Name = "btnExitGame";
            btnExitGame.Size = new Size(101, 38);
            btnExitGame.TabIndex = 9;
            btnExitGame.Text = "EXIT";
            btnExitGame.UseVisualStyleBackColor = false;
            btnExitGame.Click += btnExitGame_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(38, 320);
            label1.Name = "label1";
            label1.Size = new Size(235, 30);
            label1.TabIndex = 10;
            label1.Text = "LATEST MARKET NEWS";
            // 
            // lblNews
            // 
            lblNews.AutoSize = true;
            lblNews.Location = new Point(31, 367);
            lblNews.Name = "lblNews";
            lblNews.Size = new Size(38, 15);
            lblNews.TabIndex = 11;
            lblNews.Text = "label2";
            // 
            // MarketForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNews);
            Controls.Add(label1);
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
            Name = "MarketForm";
            Text = "MarketForm";
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
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
    }
}