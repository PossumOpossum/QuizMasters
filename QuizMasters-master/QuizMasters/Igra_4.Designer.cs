namespace QuizMasters
{
    partial class Igra_4
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
            this.question = new System.Windows.Forms.TextBox();
            this.player1 = new System.Windows.Forms.TextBox();
            this.player2 = new System.Windows.Forms.TextBox();
            this.player4 = new System.Windows.Forms.TextBox();
            this.player3 = new System.Windows.Forms.TextBox();
            this.nextQuestion = new System.Windows.Forms.Button();
            this.leaderboard = new System.Windows.Forms.Button();
            this.answer = new System.Windows.Forms.TextBox();
            this.verify = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.secondsLeft = new System.Windows.Forms.Label();
            this.isCorrect = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // question
            // 
            this.question.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question.Location = new System.Drawing.Point(73, 42);
            this.question.Name = "question";
            this.question.ReadOnly = true;
            this.question.Size = new System.Drawing.Size(1405, 34);
            this.question.TabIndex = 0;
            // 
            // player1
            // 
            this.player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1.Location = new System.Drawing.Point(73, 175);
            this.player1.Name = "player1";
            this.player1.ReadOnly = true;
            this.player1.Size = new System.Drawing.Size(364, 34);
            this.player1.TabIndex = 1;
            // 
            // player2
            // 
            this.player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2.Location = new System.Drawing.Point(73, 279);
            this.player2.Name = "player2";
            this.player2.ReadOnly = true;
            this.player2.Size = new System.Drawing.Size(364, 34);
            this.player2.TabIndex = 2;
            // 
            // player4
            // 
            this.player4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player4.Location = new System.Drawing.Point(73, 477);
            this.player4.Name = "player4";
            this.player4.ReadOnly = true;
            this.player4.Size = new System.Drawing.Size(364, 34);
            this.player4.TabIndex = 3;
            // 
            // player3
            // 
            this.player3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player3.Location = new System.Drawing.Point(73, 368);
            this.player3.Name = "player3";
            this.player3.ReadOnly = true;
            this.player3.Size = new System.Drawing.Size(364, 34);
            this.player3.TabIndex = 4;
            // 
            // nextQuestion
            // 
            this.nextQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextQuestion.Location = new System.Drawing.Point(73, 796);
            this.nextQuestion.Name = "nextQuestion";
            this.nextQuestion.Size = new System.Drawing.Size(195, 60);
            this.nextQuestion.TabIndex = 5;
            this.nextQuestion.Text = "Наредно Прашање";
            this.nextQuestion.UseVisualStyleBackColor = true;
            this.nextQuestion.Click += new System.EventHandler(this.nextQuestion_Click);
            // 
            // leaderboard
            // 
            this.leaderboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboard.Location = new System.Drawing.Point(1283, 796);
            this.leaderboard.Name = "leaderboard";
            this.leaderboard.Size = new System.Drawing.Size(195, 60);
            this.leaderboard.TabIndex = 6;
            this.leaderboard.Text = "Бодовна Табела";
            this.leaderboard.UseVisualStyleBackColor = true;
            this.leaderboard.Click += new System.EventHandler(this.leaderboard_Click);
            // 
            // answer
            // 
            this.answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer.Location = new System.Drawing.Point(831, 368);
            this.answer.Name = "answer";
            this.answer.ReadOnly = true;
            this.answer.Size = new System.Drawing.Size(229, 30);
            this.answer.TabIndex = 7;
            this.answer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.answer_KeyDown);
            // 
            // verify
            // 
            this.verify.Location = new System.Drawing.Point(1140, 367);
            this.verify.Name = "verify";
            this.verify.Size = new System.Drawing.Size(76, 31);
            this.verify.TabIndex = 8;
            this.verify.Text = "✓";
            this.verify.UseVisualStyleBackColor = true;
            this.verify.Click += new System.EventHandler(this.verify_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(73, 684);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1405, 38);
            this.progressBar1.TabIndex = 9;
            // 
            // secondsLeft
            // 
            this.secondsLeft.AutoSize = true;
            this.secondsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondsLeft.Location = new System.Drawing.Point(70, 642);
            this.secondsLeft.Name = "secondsLeft";
            this.secondsLeft.Size = new System.Drawing.Size(0, 25);
            this.secondsLeft.TabIndex = 11;
            // 
            // isCorrect
            // 
            this.isCorrect.AutoSize = true;
            this.isCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isCorrect.Location = new System.Drawing.Point(826, 315);
            this.isCorrect.Name = "isCorrect";
            this.isCorrect.Size = new System.Drawing.Size(0, 25);
            this.isCorrect.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(646, 796);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 60);
            this.button1.TabIndex = 13;
            this.button1.Text = "Упатство";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Igra_4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1618, 947);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.isCorrect);
            this.Controls.Add(this.secondsLeft);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.verify);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.leaderboard);
            this.Controls.Add(this.nextQuestion);
            this.Controls.Add(this.player3);
            this.Controls.Add(this.player4);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.question);
            this.Name = "Igra_4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Igra_4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Igra_4_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Igra_4_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox question;
        private System.Windows.Forms.TextBox player1;
        private System.Windows.Forms.TextBox player2;
        private System.Windows.Forms.TextBox player4;
        private System.Windows.Forms.TextBox player3;
        private System.Windows.Forms.Button nextQuestion;
        private System.Windows.Forms.Button leaderboard;
        private System.Windows.Forms.TextBox answer;
        private System.Windows.Forms.Button verify;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label secondsLeft;
        private System.Windows.Forms.Label isCorrect;
        private System.Windows.Forms.Button button1;
    }
}