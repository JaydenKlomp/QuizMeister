namespace QuizMeister
{
    partial class AddQuestionForm
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
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtCorrectAnswer = new System.Windows.Forms.TextBox();
            this.txtWrongAnswer1 = new System.Windows.Forms.TextBox();
            this.txtWrongAnswer2 = new System.Windows.Forms.TextBox();
            this.txtWrongAnswer3 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(23, 99);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(273, 20);
            this.txtQuestion.TabIndex = 0;
            this.txtQuestion.Text = "Question";
            // 
            // txtCorrectAnswer
            // 
            this.txtCorrectAnswer.Location = new System.Drawing.Point(23, 125);
            this.txtCorrectAnswer.Name = "txtCorrectAnswer";
            this.txtCorrectAnswer.Size = new System.Drawing.Size(273, 20);
            this.txtCorrectAnswer.TabIndex = 1;
            this.txtCorrectAnswer.Text = "Answer";
            // 
            // txtWrongAnswer1
            // 
            this.txtWrongAnswer1.Location = new System.Drawing.Point(23, 151);
            this.txtWrongAnswer1.Name = "txtWrongAnswer1";
            this.txtWrongAnswer1.Size = new System.Drawing.Size(273, 20);
            this.txtWrongAnswer1.TabIndex = 2;
            this.txtWrongAnswer1.Text = "Wrong Answer";
            // 
            // txtWrongAnswer2
            // 
            this.txtWrongAnswer2.Location = new System.Drawing.Point(23, 177);
            this.txtWrongAnswer2.Name = "txtWrongAnswer2";
            this.txtWrongAnswer2.Size = new System.Drawing.Size(273, 20);
            this.txtWrongAnswer2.TabIndex = 3;
            this.txtWrongAnswer2.Text = "Wrong Answer";
            // 
            // txtWrongAnswer3
            // 
            this.txtWrongAnswer3.Location = new System.Drawing.Point(23, 203);
            this.txtWrongAnswer3.Name = "txtWrongAnswer3";
            this.txtWrongAnswer3.Size = new System.Drawing.Size(273, 20);
            this.txtWrongAnswer3.TabIndex = 4;
            this.txtWrongAnswer3.Text = "Wrong Answer";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(124, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 450);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtWrongAnswer3);
            this.Controls.Add(this.txtWrongAnswer2);
            this.Controls.Add(this.txtWrongAnswer1);
            this.Controls.Add(this.txtCorrectAnswer);
            this.Controls.Add(this.txtQuestion);
            this.Name = "AddQuestionForm";
            this.Text = "AddQuestionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtCorrectAnswer;
        private System.Windows.Forms.TextBox txtWrongAnswer1;
        private System.Windows.Forms.TextBox txtWrongAnswer2;
        private System.Windows.Forms.TextBox txtWrongAnswer3;
        private System.Windows.Forms.Button btnAdd;
    }
}