using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QuizMester
{
    public partial class QuizForm : Form
    {
        private Label lblQuestion;
        private Button btnOption1;
        private Button btnOption2;
        private Button btnOption3;
        private Button btnOption4;
        private Button btnSubmit;
        private string username;

        private List<string> questionsText = new List<string>();  // List to store questions
        private List<List<string>> answers = new List<List<string>>();  // List of answer sets
        private List<string> correctAnswers = new List<string>();  // List to store correct answers
        private int currentQuestionIndex = 0;
        private int score = 0;
        private Random random = new Random();
        private string selectedAnswer = "";  // Track the selected answer

        public QuizForm(string username)
        {
            this.username = username;
            InitializeComponent();
            LoadQuestions();  // Load all questions from the database
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            LoadNextQuestion();
        }

        // Load questions and answers from the database
        private void LoadQuestions()
        {
            string connectionString = "Server=localhost;Database=quizmester;Uid=root;";  // Replace with your connection string

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT question_text, correct_answer, wrong_answer1, wrong_answer2, wrong_answer3 FROM questions";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
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
                    string query = "INSERT INTO scores (username, score) VALUES (@username, @score)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@score", score);

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

        private void InitializeComponent()
        {
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnOption1 = new System.Windows.Forms.Button();
            this.btnOption2 = new System.Windows.Forms.Button();
            this.btnOption3 = new System.Windows.Forms.Button();
            this.btnOption4 = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(183, 100);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(60, 13);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Question?";
            // 
            // btnOption1
            // 
            this.btnOption1.Location = new System.Drawing.Point(160, 150);
            this.btnOption1.Name = "btnOption1";
            this.btnOption1.Size = new System.Drawing.Size(100, 30);
            this.btnOption1.TabIndex = 1;
            this.btnOption1.Text = "Option 1";
            this.btnOption1.UseVisualStyleBackColor = true;
            this.btnOption1.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnOption2
            // 
            this.btnOption2.Location = new System.Drawing.Point(160, 190);
            this.btnOption2.Name = "btnOption2";
            this.btnOption2.Size = new System.Drawing.Size(100, 30);
            this.btnOption2.TabIndex = 2;
            this.btnOption2.Text = "Option 2";
            this.btnOption2.UseVisualStyleBackColor = true;
            this.btnOption2.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnOption3
            // 
            this.btnOption3.Location = new System.Drawing.Point(160, 230);
            this.btnOption3.Name = "btnOption3";
            this.btnOption3.Size = new System.Drawing.Size(100, 30);
            this.btnOption3.TabIndex = 3;
            this.btnOption3.Text = "Option 3";
            this.btnOption3.UseVisualStyleBackColor = true;
            this.btnOption3.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnOption4
            // 
            this.btnOption4.Location = new System.Drawing.Point(160, 270);
            this.btnOption4.Name = "btnOption4";
            this.btnOption4.Size = new System.Drawing.Size(100, 30);
            this.btnOption4.TabIndex = 4;
            this.btnOption4.Text = "Option 4";
            this.btnOption4.UseVisualStyleBackColor = true;
            this.btnOption4.Click += new System.EventHandler(this.btnOption_Click);
            //
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(160, 320);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 30);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // 
            // QuizForm
            // 
            this.ClientSize = new System.Drawing.Size(433, 401);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnOption4);
            this.Controls.Add(this.btnOption3);
            this.Controls.Add(this.btnOption2);
            this.Controls.Add(this.btnOption1);
            this.Controls.Add(this.lblQuestion);
            this.Name = "QuizForm";
            this.Load += new System.EventHandler(this.QuizForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
