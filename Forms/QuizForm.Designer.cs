namespace QuizMester
{
    partial class QuizForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOption2 = new System.Windows.Forms.Button();
            this.btnOption1 = new System.Windows.Forms.Button();
            this.btnOption3 = new System.Windows.Forms.Button();
            this.btnOption4 = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblQuestionProgress = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.questionTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.btnJoker = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOption2
            // 
            this.btnOption2.Location = new System.Drawing.Point(242, 109);
            this.btnOption2.Name = "btnOption2";
            this.btnOption2.Size = new System.Drawing.Size(157, 50);
            this.btnOption2.TabIndex = 0;
            this.btnOption2.Text = "button2";
            this.btnOption2.UseVisualStyleBackColor = true;
            this.btnOption2.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnOption1
            // 
            this.btnOption1.Location = new System.Drawing.Point(79, 109);
            this.btnOption1.Name = "btnOption1";
            this.btnOption1.Size = new System.Drawing.Size(157, 50);
            this.btnOption1.TabIndex = 1;
            this.btnOption1.Text = "button1";
            this.btnOption1.UseVisualStyleBackColor = true;
            this.btnOption1.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnOption3
            // 
            this.btnOption3.Location = new System.Drawing.Point(80, 162);
            this.btnOption3.Name = "btnOption3";
            this.btnOption3.Size = new System.Drawing.Size(157, 50);
            this.btnOption3.TabIndex = 2;
            this.btnOption3.Text = "button3";
            this.btnOption3.UseVisualStyleBackColor = true;
            this.btnOption3.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnOption4
            // 
            this.btnOption4.Location = new System.Drawing.Point(242, 162);
            this.btnOption4.Name = "btnOption4";
            this.btnOption4.Size = new System.Drawing.Size(157, 50);
            this.btnOption4.TabIndex = 3;
            this.btnOption4.Text = "button4";
            this.btnOption4.UseVisualStyleBackColor = true;
            this.btnOption4.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(184, 218);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(109, 32);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblQuestionProgress
            // 
            this.lblQuestionProgress.AutoSize = true;
            this.lblQuestionProgress.Location = new System.Drawing.Point(404, 259);
            this.lblQuestionProgress.Name = "lblQuestionProgress";
            this.lblQuestionProgress.Size = new System.Drawing.Size(35, 13);
            this.lblQuestionProgress.TabIndex = 6;
            this.lblQuestionProgress.Text = "label1";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(404, 237);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(47, 13);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "Score: 0";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(130, 276);
            this.progressBar.Maximum = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(217, 23);
            this.progressBar.TabIndex = 9;
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.AutoSize = true;
            this.lblTimeRemaining.Location = new System.Drawing.Point(208, 259);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(50, 13);
            this.lblTimeRemaining.TabIndex = 10;
            this.lblTimeRemaining.Text = "Time left:";
            // 
            // btnJoker
            // 
            this.btnJoker.Location = new System.Drawing.Point(403, 276);
            this.btnJoker.Name = "btnJoker";
            this.btnJoker.Size = new System.Drawing.Size(75, 23);
            this.btnJoker.TabIndex = 11;
            this.btnJoker.Text = "THE JOKER";
            this.btnJoker.UseVisualStyleBackColor = true;
            this.btnJoker.Click += new System.EventHandler(this.btnJoker_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(12, 9);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(466, 94);
            this.lblQuestion.TabIndex = 5;
            this.lblQuestion.Text = "label1";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 311);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.btnJoker);
            this.Controls.Add(this.lblTimeRemaining);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblQuestionProgress);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnOption4);
            this.Controls.Add(this.btnOption3);
            this.Controls.Add(this.btnOption1);
            this.Controls.Add(this.btnOption2);
            this.Name = "QuizForm";
            this.Text = "QuizForm";
            this.Load += new System.EventHandler(this.QuizForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOption2;
        private System.Windows.Forms.Button btnOption1;
        private System.Windows.Forms.Button btnOption3;
        private System.Windows.Forms.Button btnOption4;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblQuestionProgress;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer questionTimer;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Button btnJoker;
        private System.Windows.Forms.Label lblQuestion;
    }
}