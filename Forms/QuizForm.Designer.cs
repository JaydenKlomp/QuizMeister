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
            this.btnOption2 = new System.Windows.Forms.Button();
            this.btnOption1 = new System.Windows.Forms.Button();
            this.btnOption3 = new System.Windows.Forms.Button();
            this.btnOption4 = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblQuestionProgress = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOption2
            // 
            this.btnOption2.Location = new System.Drawing.Point(249, 132);
            this.btnOption2.Name = "btnOption2";
            this.btnOption2.Size = new System.Drawing.Size(75, 23);
            this.btnOption2.TabIndex = 0;
            this.btnOption2.Text = "button2";
            this.btnOption2.UseVisualStyleBackColor = true;
            this.btnOption2.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnOption1
            // 
            this.btnOption1.Location = new System.Drawing.Point(158, 132);
            this.btnOption1.Name = "btnOption1";
            this.btnOption1.Size = new System.Drawing.Size(75, 23);
            this.btnOption1.TabIndex = 1;
            this.btnOption1.Text = "button1";
            this.btnOption1.UseVisualStyleBackColor = true;
            this.btnOption1.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnOption3
            // 
            this.btnOption3.Location = new System.Drawing.Point(158, 161);
            this.btnOption3.Name = "btnOption3";
            this.btnOption3.Size = new System.Drawing.Size(75, 23);
            this.btnOption3.TabIndex = 2;
            this.btnOption3.Text = "button3";
            this.btnOption3.UseVisualStyleBackColor = true;
            this.btnOption3.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnOption4
            // 
            this.btnOption4.Location = new System.Drawing.Point(249, 161);
            this.btnOption4.Name = "btnOption4";
            this.btnOption4.Size = new System.Drawing.Size(75, 23);
            this.btnOption4.TabIndex = 3;
            this.btnOption4.Text = "button4";
            this.btnOption4.UseVisualStyleBackColor = true;
            this.btnOption4.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(205, 217);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(24, 38);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(93, 33);
            this.lblQuestion.TabIndex = 5;
            this.lblQuestion.Text = "label1";
            // 
            // lblQuestionProgress
            // 
            this.lblQuestionProgress.AutoSize = true;
            this.lblQuestionProgress.Location = new System.Drawing.Point(400, 259);
            this.lblQuestionProgress.Name = "lblQuestionProgress";
            this.lblQuestionProgress.Size = new System.Drawing.Size(35, 13);
            this.lblQuestionProgress.TabIndex = 6;
            this.lblQuestionProgress.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblQuestion);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // QuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 311);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblQuestionProgress);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnOption4);
            this.Controls.Add(this.btnOption3);
            this.Controls.Add(this.btnOption1);
            this.Controls.Add(this.btnOption2);
            this.Name = "QuizForm";
            this.Text = "QuizForm";
            this.Load += new System.EventHandler(this.QuizForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOption2;
        private System.Windows.Forms.Button btnOption1;
        private System.Windows.Forms.Button btnOption3;
        private System.Windows.Forms.Button btnOption4;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblQuestionProgress;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}