using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  //import mysql

namespace QuizMester
{
    public partial class QuizForm : Form
    {
        private string username;
        private int difficulty;  // difficulty is eig genre 

        private List<string> questionsText = new List<string>();  // lijst
        private List<List<string>> answers = new List<List<string>>();  // voor alle
        private List<string> correctAnswers = new List<string>();  // opgeslagen vragen en antwoorden
        private int currentQuestionIndex = 0;
        private int score = 0;
        private Random random = new Random();
        private string selectedAnswer = "";  // gekozen antwoord 
        private int timeLeft = 10;       
        private int jokerUses = 0;  

       
        public QuizForm(string username, int difficulty)
        {
            this.username = username;
            this.difficulty = difficulty;  
            InitializeComponent();
            LoadQuestions();  // vragen inladen
            CenterToScreen();
            this.FormClosing += new FormClosingEventHandler(QuizForm_FormClosing);

            questionTimer = new Timer();
            questionTimer.Interval = 1000;  // 1 seconden
            questionTimer.Tick += new EventHandler(TimerTick);  
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            LoadNextQuestion();
        }

        private void LoadQuestions()
        {
            string connectionString = "Server=localhost;Database=quizmester;Uid=root;"; 

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT question_text, correct_answer, wrong_answer1, wrong_answer2, wrong_answer3 FROM questions WHERE difficulty = @difficulty";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@difficulty", this.difficulty); 
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

                        
                        questionsText.Add(questionText); 
                        answers.Add(ShuffleAnswers(allAnswers)); 
                        correctAnswers.Add(correctAnswer);  
                    }

                    
                    ShuffleQuestions();  // shuffelt vragen nadat ze zijn ingeladen
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
                // als alle vragen zijn geweest (nummer van vragen = huidige vraag)
                SaveScore();
                ShowLeaderboard();
                return;
            }

            timeLeft = 10;
            lblTimeRemaining.Text = $"Time Left: {timeLeft}s";
            progressBar.Value = timeLeft;

            questionTimer.Start();

            lblQuestionProgress.Text = $"Question {currentQuestionIndex + 1}/{questionsText.Count}";

            lblQuestion.Text = questionsText[currentQuestionIndex];
            selectedAnswer = "";
            ResetButtonColors();

            btnOption1.Text = answers[currentQuestionIndex][0];
            btnOption2.Text = answers[currentQuestionIndex][1];
            btnOption3.Text = answers[currentQuestionIndex][2];
            btnOption4.Text = answers[currentQuestionIndex][3];

            currentQuestionIndex++; 
        }


        private void ResetButtonColors()
        {
            btnOption1.BackColor = SystemColors.Control;
            btnOption2.BackColor = SystemColors.Control;
            btnOption3.BackColor = SystemColors.Control;
            btnOption4.BackColor = SystemColors.Control;
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            ResetButtonColors();

            Button selectedButton = (Button)sender;
            selectedButton.BackColor = Color.LightBlue;

            selectedAnswer = selectedButton.Text;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedAnswer))
            {
                MessageBox.Show("Please select an answer before submitting.");
                return;
            }

            questionTimer.Stop();

            string correctAnswer = correctAnswers[currentQuestionIndex - 1];

            if (selectedAnswer == correctAnswer)
            {
                score += 1;  
                MessageBox.Show("Correct!");
            }
            else
            {
                if (score > 0)
                {
                    score -= 1;
                }
                MessageBox.Show($"Incorrect! The correct answer was: {correctAnswer}");
            }

            lblScore.Text = $"Score: {score}";

            LoadNextQuestion();
        }


        private void SaveScore()
        {
            string connectionString = "Server=localhost;Database=quizmester;Uid=root;"; 

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO scores (username, score, difficulty) VALUES (@username, @score, @difficulty)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.Parameters.AddWithValue("@difficulty", difficulty);

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
            ScoreboardForm scoreboardForm = new ScoreboardForm();
            scoreboardForm.Show();
            this.Close();  
        }

        private void ShuffleQuestions()
        {
            Random random = new Random();  
            for (int i = questionsText.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                string tempQuestion = questionsText[i];
                questionsText[i] = questionsText[j];
                questionsText[j] = tempQuestion;

                List<string> tempAnswers = answers[i];
                answers[i] = answers[j];
                answers[j] = tempAnswers;

                string tempCorrect = correctAnswers[i];
                correctAnswers[i] = correctAnswers[j];
                correctAnswers[j] = tempCorrect;
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                lblTimeRemaining.Text = $"Time Left: {timeLeft}s";
                progressBar.Value = timeLeft;

                if (timeLeft <= 3)
                {
                    lblTimeRemaining.Text = $"Time Left: {timeLeft}s - Time's almost up!";
                }
            }
            else
            {
                
                questionTimer.Stop();  
                MessageBox.Show("Time's up! You didn't answer in time.");

                
                if (score > 0)
                {
                    score--;
                }

                lblScore.Text = $"Score: {score}";
                LoadNextQuestion();
            }
        }

        private void btnJoker_Click(object sender, EventArgs e)
        {
            if (jokerUses < 3) 
            {
                jokerUses++;  
                score += 1;  
                lblScore.Text = $"Score: {score}";  

                
                MessageBox.Show($"You used THE JOKER! You have {3 - jokerUses} Joker(s) left.");

                
                LoadNextQuestion();
            }

            
            if (jokerUses >= 3)
            {
                btnJoker.Enabled = false;  
                MessageBox.Show("You have used all your JOKER skips.");
            }
        }

        private void QuizForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close the entire application when this form is closed
            Application.Exit();
        }


    }
}
