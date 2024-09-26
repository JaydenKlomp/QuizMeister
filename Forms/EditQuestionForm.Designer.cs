namespace QuizMeister
{
    partial class EditQuestionForm
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtWrongAnswer3 = new System.Windows.Forms.TextBox();
            this.txtWrongAnswer2 = new System.Windows.Forms.TextBox();
            this.txtWrongAnswer1 = new System.Windows.Forms.TextBox();
            this.txtCorrectAnswer = new System.Windows.Forms.TextBox();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtQuestionId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(138, 265);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtWrongAnswer3
            // 
            this.txtWrongAnswer3.Location = new System.Drawing.Point(37, 228);
            this.txtWrongAnswer3.Name = "txtWrongAnswer3";
            this.txtWrongAnswer3.Size = new System.Drawing.Size(273, 20);
            this.txtWrongAnswer3.TabIndex = 10;
            this.txtWrongAnswer3.Text = "Wrong Answer";
            // 
            // txtWrongAnswer2
            // 
            this.txtWrongAnswer2.Location = new System.Drawing.Point(37, 202);
            this.txtWrongAnswer2.Name = "txtWrongAnswer2";
            this.txtWrongAnswer2.Size = new System.Drawing.Size(273, 20);
            this.txtWrongAnswer2.TabIndex = 9;
            this.txtWrongAnswer2.Text = "Wrong Answer";
            // 
            // txtWrongAnswer1
            // 
            this.txtWrongAnswer1.Location = new System.Drawing.Point(37, 176);
            this.txtWrongAnswer1.Name = "txtWrongAnswer1";
            this.txtWrongAnswer1.Size = new System.Drawing.Size(273, 20);
            this.txtWrongAnswer1.TabIndex = 8;
            this.txtWrongAnswer1.Text = "Wrong Answer";
            // 
            // txtCorrectAnswer
            // 
            this.txtCorrectAnswer.Location = new System.Drawing.Point(37, 150);
            this.txtCorrectAnswer.Name = "txtCorrectAnswer";
            this.txtCorrectAnswer.Size = new System.Drawing.Size(273, 20);
            this.txtCorrectAnswer.TabIndex = 7;
            this.txtCorrectAnswer.Text = "Answer";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(37, 124);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(273, 20);
            this.txtQuestion.TabIndex = 6;
            this.txtQuestion.Text = "Question";
            // 
            // txtQuestionId
            // 
            this.txtQuestionId.Location = new System.Drawing.Point(37, 98);
            this.txtQuestionId.Name = "txtQuestionId";
            this.txtQuestionId.Size = new System.Drawing.Size(273, 20);
            this.txtQuestionId.TabIndex = 12;
            this.txtQuestionId.Text = "Question ID";
            // 
            // EditQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 450);
            this.Controls.Add(this.txtQuestionId);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtWrongAnswer3);
            this.Controls.Add(this.txtWrongAnswer2);
            this.Controls.Add(this.txtWrongAnswer1);
            this.Controls.Add(this.txtCorrectAnswer);
            this.Controls.Add(this.txtQuestion);
            this.Name = "EditQuestionForm";
            this.Text = "EditQuestionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtWrongAnswer3;
        private System.Windows.Forms.TextBox txtWrongAnswer2;
        private System.Windows.Forms.TextBox txtWrongAnswer1;
        private System.Windows.Forms.TextBox txtCorrectAnswer;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtQuestionId;
    }
}