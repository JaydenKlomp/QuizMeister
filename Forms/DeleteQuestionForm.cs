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
    public partial class DeleteQuestionForm : Form
    {
        public DeleteQuestionForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        // Method to delete the question from the database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string questionId = txtQuestionId.Text;

            if (string.IsNullOrEmpty(questionId))
            {
                MessageBox.Show("Question ID cannot be empty.");
                return;
            }

            string connectionString = "Server=localhost;Database=quizmester;Uid=root;";  // Update with your connection string
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM questions WHERE id = @question_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@question_id", questionId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Question deleted successfully!");
                    this.Close();  // Close the form after deleting the question
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting question: {ex.Message}");
                }
            }
        }
    }
}
