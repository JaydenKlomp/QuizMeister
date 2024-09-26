using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizMeister
{
    public partial class ManageUsersForm : Form
    {
        public ManageUsersForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = Prompt.ShowDialog("Enter new username:", "Add User");
            string password = Prompt.ShowDialog("Enter password:", "Add User");

            string connectionString = "Server=localhost;Database=quizmester;Uid=root;";  // Update with your connection string
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO users (username, password, is_admin) VALUES (@username, @password, 0)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding user: {ex.Message}");
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            string username = Prompt.ShowDialog("Enter username to edit:", "Edit User");
            string newPassword = Prompt.ShowDialog("Enter new password:", "Edit User");

            string connectionString = "Server=localhost;Database=quizmester;Uid=root;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE users SET password = @password WHERE username = @username";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", newPassword);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating user: {ex.Message}");
                }
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string username = Prompt.ShowDialog("Enter username to delete:", "Delete User");

            string connectionString = "Server=localhost;Database=quizmester;Uid=root;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM users WHERE username = @username";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}");
                }
            }
        }

        // Prompt dialog helper class
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    Text = caption
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "OK", Left = 350, Width = 100, Top = 70 };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;

                prompt.ShowDialog();
                return inputBox.Text;
            }
        }
    }
}

