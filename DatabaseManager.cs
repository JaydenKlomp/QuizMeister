using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QuizMester
{
    public static class DatabaseManager
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QuizMesterDB"].ConnectionString;

        // Method to check user login credentials
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
                    return BCrypt.Net.BCrypt.Verify(password, storedPassword); // Hash comparison
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Method to register a new user
        public static bool RegisterUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO users (username, password) VALUES (@username, @password)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(password)); // Hash password for security

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
    }
}
