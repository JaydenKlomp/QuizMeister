using System;
using System.Windows.Forms;

namespace QuizMester
{
    public partial class LoginForm : Form
    {
        

        public LoginForm()
        {
            InitializeComponent();  // Automatically loads the design from the Designer.cs file
            CenterToScreen();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (DatabaseManager.CheckLogin(username, password))
            {
                // Get the selected difficulty from the ComboBox
                int selectedDifficulty = cbDifficulty.SelectedIndex + 1;  // 1 = Easy, 2 = Medium, 3 = Hard

                // Pass the username and difficulty to the QuizForm
                QuizForm quizForm = new QuizForm(username, selectedDifficulty);
                quizForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid login!");
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (DatabaseManager.RegisterUser(username, password))
            {
                MessageBox.Show("Registration successful!");
            }
            else
            {
                MessageBox.Show("Registration failed. Username might already exist.");
            }
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            ScoreboardForm scoreboardForm = new ScoreboardForm();
            scoreboardForm.Show();
        }


    }
}
