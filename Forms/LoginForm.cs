using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuizMeister;


namespace QuizMester
{
    public partial class LoginForm : Form
    {
        

        public LoginForm()
        {
            InitializeComponent();

            CenterToScreen();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // admin check
            bool isAdmin = DatabaseManager.CheckAdminLogin(username, password);

            // check voor difficulty voor niet admin users
            if (!isAdmin && cbDifficulty.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a difficulty level.");
                return;
            }

            if (isAdmin)
            {
                // als admin login succesvol is, alert box
                DialogResult result = MessageBox.Show("Do you want to go to the Admin Panel?", "Admin Login", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // als ja open admin panel
                    MessageBox.Show("Admin login successful!");
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else
                {
                    // als nee, start quiz
                    int selectedDifficulty = cbDifficulty.SelectedIndex + 1;  // gekozen genre

                    // sla username en genre op voor tijdens de quiz
                    QuizForm quizForm = new QuizForm(username, selectedDifficulty);
                    quizForm.Show();
                    this.Hide();
                }
            }
            else if (DatabaseManager.CheckLogin(username, password))
            {
                // hetzelfde als hierboven, maar dan voor non admins
                int selectedDifficulty = cbDifficulty.SelectedIndex + 1;  

                
                QuizForm quizForm = new QuizForm(username, selectedDifficulty);
                quizForm.Show();
                this.Hide();  
            }
            else
            {
                // als fout dan
                MessageBox.Show("Invalid login! Please check your username and password.");
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

        private void btnAutoLogin_Click(object sender, EventArgs e)
        {
            // debug knop
            txtUsername.Text = "jayden";
            txtPassword.Text = "test";

           
            btnLogin_Click(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gemaakt door: Jayden Klomp");
        }
    }
}
