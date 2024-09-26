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
    public partial class EditQuestionForm : Form
    {
        public EditQuestionForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        // Method to edit the question in the database
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string questionId = txtQuestionId.Text;
            string questionText = txtQuestion.Text;
            string correctAnswer = txtCorrectAnswer.Text;
            string wrongAnswer1 = txtWrongAnswer1.Text;
            string wrongAnswer2 = txtWrongAnswer2.Text;
            string wrongAnswer3 = txtWrongAnswer3.Text;

            if (string.IsNullOrEmpty(questionId) || string.IsNullOrEmpty(questionText) || string.IsNullOrEmpty(correctAnswer))
            {
                MessageBox.Show("Question ID, Question Text, and Correct Answer fields cannot be empty.");
                return;
            }

            string connectionString = "Server=localhost;Database=quizmester;Uid=root;";  // Update with your connection string
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE questions SET question_text = @question_text, correct_answer = @correct_answer, " +
                                   "wrong_answer1 = @wrong_answer1, wrong_answer2 = @wrong_answer2, wrong_answer3 = @wrong_answer3 " +
                                   "WHERE id = @question_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@question_id", questionId);
                    cmd.Parameters.AddWithValue("@question_text", questionText);
                    cmd.Parameters.AddWithValue("@correct_answer", correctAnswer);
                    cmd.Parameters.AddWithValue("@wrong_answer1", wrongAnswer1);
                    cmd.Parameters.AddWithValue("@wrong_answer2", wrongAnswer2);
                    cmd.Parameters.AddWithValue("@wrong_answer3", wrongAnswer3);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Question updated successfully!");
                    this.Close();  // Close the form after updating the question
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating question: {ex.Message}");
                }
            }
        }
    }
}
