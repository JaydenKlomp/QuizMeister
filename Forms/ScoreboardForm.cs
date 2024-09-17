using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuizMester
{
    public partial class ScoreboardForm : Form
    {
        public ScoreboardForm()
        {
            InitializeComponent();
            LoadScoreboard();  // Load top 10 scores from the database
        }

        private void LoadScoreboard()
        {
            string connectionString = "Server=localhost;Database=quizmester;Uid=root;";  // Update with your connection string

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT username, score, date_played FROM scores ORDER BY score DESC LIMIT 10";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Clear any existing items in the ListView
                    lvScores.Items.Clear();

                    while (reader.Read())
                    {
                        // Add each score to the ListView
                        ListViewItem item = new ListViewItem(reader.GetString("username"));
                        item.SubItems.Add(reader.GetInt32("score").ToString());
                        item.SubItems.Add(reader.GetDateTime("date_played").ToString("yyyy-MM-dd HH:mm:ss"));
                        lvScores.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading scoreboard: {ex.Message}");
                }
            }
        }

        private void InitializeComponent()
        {
            this.lvScores = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvScores
            // 
            this.lvScores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvScores.HideSelection = false;
            this.lvScores.Location = new System.Drawing.Point(12, 12);
            this.lvScores.Name = "lvScores";
            this.lvScores.Size = new System.Drawing.Size(360, 240);
            this.lvScores.TabIndex = 0;
            this.lvScores.UseCompatibleStateImageBehavior = false;
            this.lvScores.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Score";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date Played";
            this.columnHeader3.Width = 140;
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(101, 284);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(191, 284);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Quit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // ScoreboardForm
            // 
            this.ClientSize = new System.Drawing.Size(384, 319);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lvScores);
            this.Name = "ScoreboardForm";
            this.Text = "Leaderboard";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ListView lvScores;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private Button btnRestart;
        private Button btnClose;
        private System.Windows.Forms.ColumnHeader columnHeader3;

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Closes the application
        }


        private void btnRestart_Click(object sender, EventArgs e)
        {
            // Hide the current quiz form
            this.Hide();

            // Create a new instance of the LoginForm
            LoginForm loginForm = new LoginForm();

            // Show the login form
            loginForm.Show();

            // Optionally, you could close the QuizForm entirely by using `this.Close()`, 
            // but only after showing the login form, so the app doesn't terminate.
        }

    }
}
