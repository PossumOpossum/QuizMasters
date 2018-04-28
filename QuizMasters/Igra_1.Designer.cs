namespace QuizMasters
{
    partial class Igra_1
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
            this.Prasanje = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timeleftlabel = new System.Windows.Forms.Label();
            this.next_button = new System.Windows.Forms.Button();
            this.correct = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Prasanje
            // 
            this.Prasanje.Location = new System.Drawing.Point(41, 50);
            this.Prasanje.Name = "Prasanje";
            this.Prasanje.ReadOnly = true;
            this.Prasanje.Size = new System.Drawing.Size(723, 22);
            this.Prasanje.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 39);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(579, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 39);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(41, 205);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 39);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(579, 205);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 39);
            this.button4.TabIndex = 4;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(41, 322);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(723, 35);
            this.progressBar1.TabIndex = 5;
            // 
            // timeleftlabel
            // 
            this.timeleftlabel.AutoSize = true;
            this.timeleftlabel.Location = new System.Drawing.Point(41, 302);
            this.timeleftlabel.Name = "timeleftlabel";
            this.timeleftlabel.Size = new System.Drawing.Size(24, 17);
            this.timeleftlabel.TabIndex = 6;
            this.timeleftlabel.Text = "10";
            // 
            // next_button
            // 
            this.next_button.Location = new System.Drawing.Point(44, 398);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(156, 40);
            this.next_button.TabIndex = 7;
            this.next_button.Text = "Наредно прашање";
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // correct
            // 
            this.correct.Location = new System.Drawing.Point(581, 407);
            this.correct.Name = "correct";
            this.correct.ReadOnly = true;
            this.correct.Size = new System.Drawing.Size(183, 22);
            this.correct.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Точен одговор";
            // 
            // Igra_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.correct);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.timeleftlabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Prasanje);
            this.Name = "Igra_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Igra_1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Igra_1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Prasanje;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label timeleftlabel;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.TextBox correct;
        private System.Windows.Forms.Label label1;
    }
}