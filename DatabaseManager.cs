using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QuizMester
{
    public static class DatabaseManager
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QuizMesterDB"].ConnectionString;

        // Method to check user login credentials (without encryption)
        public static bool CheckLogin(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT password FROM users WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                try
                {
                    conn.Open();
                    string storedPassword = (string)cmd.ExecuteScalar();
                    return password == storedPassword;  // Direct comparison of plain text password
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Method to register a new user (without password encryption)
        public static bool RegisterUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO users (username, password) VALUES (@username, @password)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);  // Store the raw password as plain text

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Method to save quiz score
        public static void SaveScore(string username, int score)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO scores (username, score) VALUES (@username, @score)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@score", score);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Method to retrieve the top 10 scores
        public static DataTable GetTopScores()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT username, score, date_played FROM scores ORDER BY score DESC LIMIT 10";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                DataTable scoresTable = new DataTable();
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    scoresTable.Load(reader);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                return scoresTable;
            }
        }

        // Method to check if the user is an admin (without encryption)
        public static bool CheckAdminLogin(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))  // Use the global connection string
            {
                string query = "SELECT password FROM users WHERE username = @username AND is_admin = 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                try
                {
                    conn.Open();
                    string storedPassword = (string)cmd.ExecuteScalar();

                    // Direct comparison of plain text password for admin login
                    return password == storedPassword;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
