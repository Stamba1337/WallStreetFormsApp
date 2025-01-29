using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_Street_Market_Game
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Money { get; set; }
        public Dictionary<string, int> Inventory { get; set; }
        public string ProfilePicturePath { get; set; }

        // Parameterless constructor
        public User()
        {
            Inventory = new Dictionary<string, int>();
        }

        // Parameterized constructor
        public User(string username, string password, int money, string profilePicturePath)
        {
            Username = username;
            Password = password;
            Money = money;
            ProfilePicturePath = profilePicturePath;
            Inventory = new Dictionary<string, int>();
        }
    }

}
