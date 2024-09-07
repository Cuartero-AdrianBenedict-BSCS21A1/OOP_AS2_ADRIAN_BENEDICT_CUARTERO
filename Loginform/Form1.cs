using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Loginform
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class UserManager
    {
        private List<User> users;
        private string filePath = "C:\\Users\\ghoul\\source\\repos\\Loginform\\Loginform\\users.json";

        public UserManager()
        {
            LoadUsersFromJson();
        }
        private void LoadUsersFromJson()
        {
            try
            {
                string json = File.ReadAllText(filePath);
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message);
                users = new List<User>(); // Ensure users is not null
            }
        }
        public bool IsValidUser(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public partial class login : Form
    {
        private UserManager userManager;

        public login()
        {
            InitializeComponent();
            userManager = new UserManager();
        }

        private void enter_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtpassword.Text;

            if (userManager.IsValidUser(username, password))
            {
                MessageBox.Show("Login successful!");
                new login().Show(); // Show new form
                this.Hide(); // Hide the current form
            }
            else
            {
                MessageBox.Show("User input invalid! Try again.");
                txtUserName.Clear();
                txtpassword.Clear();
                txtUserName.Focus();
            }
        }

        private void exit_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("System Exited");
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void password_Click(object sender, EventArgs e) { }
        private void txtUserName_TextChanged(object sender, EventArgs e) { }
        private void txtpassword_TextChanged(object sender, EventArgs e) { }
    }
}

