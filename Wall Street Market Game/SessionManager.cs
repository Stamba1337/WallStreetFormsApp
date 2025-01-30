using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Wall_Street_Market_Game
{
    public static class SessionManager
    {
        private static readonly string ProfilePicturePath = Path.Combine(Application.StartupPath, "ProfilePicture.png");

        public static User CurrentUser { get; private set; }

        public static void SetUser(User user)
        {
            CurrentUser = user ?? throw new ArgumentNullException(nameof(user));
            EnsureProfilePictureExists(); 
        }

        public static Image GetUserProfileImage()
        {
            string profilePicturePath = Path.Combine(Application.StartupPath, "ProfilePicture.png");

            try
            {
                if (File.Exists(profilePicturePath))
                {
                    using (var stream = new FileStream(profilePicturePath, FileMode.Open, FileAccess.Read))
                    {
                        return Image.FromStream(stream);
                    }
                }
                else
                {
                    return Image.FromFile(Path.Combine(Application.StartupPath, "default.png"));
                }
            }
            catch
            {
                return new Bitmap(100, 100);
            }
        }


        public static void UpdateProfilePicture(string newImagePath)
        {
            try
            {
                if (File.Exists(newImagePath))
                {
                    string profilePicturePath = Path.Combine(Application.StartupPath, "ProfilePicture.png");

                    
                    if (File.Exists(profilePicturePath))
                    {
                        using (var img = Image.FromFile(profilePicturePath))
                        {
                            img.Dispose(); 
                        }
                        File.Delete(profilePicturePath);
                    }

                   
                    File.Copy(newImagePath, profilePicturePath, true);
                    CurrentUser.ProfilePicturePath = profilePicturePath;
                    UpdateUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile picture: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private static void EnsureProfilePictureExists()
        {
            string defaultImagePath = Path.Combine(Application.StartupPath, "default.png");

            // 🔥 Check if the default image exists in the app directory
            if (!File.Exists(defaultImagePath))
            {
                MessageBox.Show("Default profile picture not found! Please place 'default.png' in the application folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Copy default image only if profile picture is missing
            if (!File.Exists(ProfilePicturePath))
            {
                File.Copy(defaultImagePath, ProfilePicturePath, true);
            }
        }


        public static void UpdateUser()
        {
            if (CurrentUser != null)
            {
                UserManager.UpdateUser(CurrentUser);
            }
        }

        
        public static void Logout()
        {
            UpdateUser();
            CurrentUser = null;

            foreach (Form form in Application.OpenForms)
            {
                if (form is MarketForm)
                {
                    form.Close();
                    break;
                }
            }

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
