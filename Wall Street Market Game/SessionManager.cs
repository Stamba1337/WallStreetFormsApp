using System;

namespace Wall_Street_Market_Game
{
    public static class SessionManager
    {
        public static User CurrentUser { get; private set; } // Holds the logged-in user

        // Method to set the current user (called during login)
        public static void SetUser(User user)
        {
            CurrentUser = user ?? throw new ArgumentNullException(nameof(user));
        }

        // Method to update user details (e.g., when money or inventory changes)
        public static void UpdateUser()
        {
            if (CurrentUser != null)
            {
                UserManager.UpdateUser(CurrentUser); // Saves changes to the JSON file
            }
        }
        public static Image GetUserProfileImage()
        {
            if (CurrentUser != null && File.Exists(CurrentUser.ProfilePicturePath))
            {
                return Image.FromFile(CurrentUser.ProfilePicturePath);
            }
            return Image.FromFile("default.png");
        }
        // Optional: Logout method (clears the user session)
        public static void Logout()
        {
            CurrentUser = null;
            Application.Restart(); // Restarts the app to clear session data
        }
    }
}
