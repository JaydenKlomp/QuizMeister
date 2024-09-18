using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  // Import MySQL client

namespace QuizMester
{
    public partial class QuizForm : Form
    {
        private string username;
        private int difficulty;  // Store difficulty level

        private List<string> questionsText = new List<string>();  // List to store questions
        private List<List<string>> answers = new List<List<string>>();  // List of answer sets
        private List<string> correctAnswers = new List<string>();  // List to store correct answers
        private int currentQuestionIndex = 0;
        private int score = 0;
        private Random random = new Random();
        private string selectedAnswer = "";  // Track the selected answer

        // Updated constructor to take both username and difficulty
        public QuizForm(string username, int difficulty)
        {
            this.username = username;
            this.difficulty = difficulty;  // Save the selected difficulty
            InitializeComponent();
            LoadQuestions();  // Load questions based on the difficulty
            CenterToScreen();
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            LoadNextQuestion();
        }

        private void LoadQuestions()
        {
            string connectionString = "Server=localhost;Database=quizmester;Uid=root;";  // Replace with your connection string

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT question_text, correct_answer, wrong_answer1, wrong_answer2, wrong_answer3 " +
                                   "FROM questions WHERE difficulty = @difficulty";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@difficulty", this.difficulty);  // Use the selected difficulty
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string questionText = reader.GetString("question_text");
                        string correctAnswer = reader.GetString("correct_answer");
                        List<string> allAnswers = new List<string>
                        {
                            correctAnswer,
                            reader.GetString("wrong_answer1"),
                            reader.GetString("wrong_answer2"),
                            reader.GetString("wrong_answer3")
                        };

                        // Add question and answers to respective lists
                        questionsText.Add(questionText);
                        answers.Add(ShuffleAnswers(allAnswers));
                        correctAnswers.Add(correctAnswer);  // Save the correct answer for scoring
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading questions from database: {ex.Message}");
                }
            }
        }

        private List<string> ShuffleAnswers(List<string> answerList)
        {
            for (int i = answerList.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = answerList[i];
                answerList[i] = answerList[j];
                answerList[j] = temp;
            }
            return answerList;
        }

        private void LoadNextQuestion()
        {
            if (currentQuestionIndex >= questionsText.Count)
            {
                // Quiz is over, show leaderboard
                SaveScore();
                ShowLeaderboard();
                return;
            }

            // Update the question progress label
            lblQuestionProgress.Text = $"Question {currentQuestionIndex + 1}/{questionsText.Count}";

            // Load the current question
            lblQuestion.Text = questionsText[currentQuestionIndex];

            // Clear selected answer
            selectedAnswer = "";

            // Reset button colors (remove any selected state)
            ResetButtonColors();

            // Assign the options (which have already been shuffled)
            btnOption1.Text = answers[currentQuestionIndex][0];
            btnOption2.Text = answers[currentQuestionIndex][1];
            btnOption3.Text = answers[currentQuestionIndex][2];
            btnOption4.Text = answers[currentQuestionIndex][3];

            currentQuestionIndex++;  // Move to the next question for the next round
        }


        private void ResetButtonColors()
        {
            btnOption1.BackColor = SystemColors.Control;
            btnOption2.BackColor = SystemColors.Control;
            btnOption3.BackColor = SystemColors.Control;
            btnOption4.BackColor = SystemColors.Control;
        }

        // Set the selected state of the button when clicked
        private void btnOption_Click(object sender, EventArgs e)
        {
            // Reset all button colors
            ResetButtonColors();

            // Set the selected button's color to show it's selected
            Button selectedButton = (Button)sender;
            selectedButton.BackColor = Color.LightBlue;

            // Store the selected answer
            selectedAnswer = selectedButton.Text;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Ensure an answer is selected
            if (string.IsNullOrEmpty(selectedAnswer))
            {
                MessageBox.Show("Please select an answer before submitting.");
                return;
            }

            // Get the correct answer for the current question
            string correctAnswer = correctAnswers[currentQuestionIndex - 1];

            // Check if the selected answer is correct
            if (selectedAnswer == correctAnswer)
            {
                score += 1;  // Increment score if correct
                MessageBox.Show("Correct!");
            }
            else
            {
                // Show a message with the user's selected answer and the correct answer
                MessageBox.Show($"Incorrect! The correct answer was: {correctAnswer}");
            }

            // Load the next question
            LoadNextQuestion();
        }

        private void SaveScore()
        {
            string connectionString = "Server=localhost;Database=quizmester;Uid=root;";  // Update with your connection string

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO scores (username, score, difficulty) VALUES (@username, @score, @difficulty)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.Parameters.AddWithValue("@difficulty", difficulty);  // Save the difficulty level

                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Your final score of {score} has been saved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving score: {ex.Message}");
                }
            }
        }


        private void ShowLeaderboard()
        {
            // Open the leaderboard form
            ScoreboardForm scoreboardForm = new ScoreboardForm();
            scoreboardForm.Show();
            this.Close();  // Close the current quiz form
        }
    }
}
