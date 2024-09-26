using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QuizMeister
{
    public partial class AddQuestionForm : Form
    {
        public AddQuestionForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string questionText = txtQuestion.Text;
            string correctAnswer = txtCorrectAnswer.Text;
            string wrongAnswer1 = txtWrongAnswer1.Text;
            string wrongAnswer2 = txtWrongAnswer2.Text;
            string wrongAnswer3 = txtWrongAnswer3.Text;

            if (string.IsNullOrEmpty(questionText) || string.IsNullOrEmpty(correctAnswer))
            {
                MessageBox.Show("Question and correct answer fields cannot be empty.");
                return;
            }

            string connectionString = "Server=localhost;Database=quizmester;Uid=root;";  // Update with your connection string
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO questions (question_text, correct_answer, wrong_answer1, wrong_answer2, wrong_answer3, difficulty) " +
                                   "VALUES (@question_text, @correct_answer, @wrong_answer1, @wrong_answer2, @wrong_answer3, 1)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@question_text", questionText);
                    cmd.Parameters.AddWithValue("@correct_answer", correctAnswer);
                    cmd.Parameters.AddWithValue("@wrong_answer1", wrongAnswer1);
                    cmd.Parameters.AddWithValue("@wrong_answer2", wrongAnswer2);
                    cmd.Parameters.AddWithValue("@wrong_answer3", wrongAnswer3);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Question added successfully!");
                    this.Close();  // Close the form after the question is added
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding question: {ex.Message}");
                }
            }
        }
    }
}
