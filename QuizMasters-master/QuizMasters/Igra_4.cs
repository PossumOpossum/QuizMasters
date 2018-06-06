﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizMasters
{
    public partial class Igra_4 : Form
    {
        private void colorField()
        {
            if (playerToAnswer == 0)
            {
                player1.BackColor = Color.LightGreen;
            }
            else if (playerToAnswer == 1)
            {
                player2.BackColor = Color.LightGreen;
            }
            else if (playerToAnswer == 2)
            {
                player3.BackColor = Color.LightGreen;
            }
            else
            {
                player4.BackColor = Color.LightGreen;
            }
        }

        private void twowayshuffle()
        {
            Random rng = new Random();
            int n = 15;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = questions[k];
                questions[k] = questions[n];
                questions[n] = value;

                value = answers[k];
                answers[k] = answers[n];
                answers[n] = value;
            }
        }

        private List<Igrach> igrachi;
        public static Timer timer;
        public Queue<int> queue;
        int playerToAnswer;
        private int secondsToAnswer;
        String [] lines;
        String [] questions;
        String [] answers;
        String [] filenames;
        int counter;
        public Igra_4(List<Igrach> igrachi)
        {
            questions = new String[15];
            answers = new String[15];
            counter = -1;
            filenames = System.IO.Directory.GetFiles(@"Chetvrta");
            Random rand = new Random();
            int file_index = rand.Next(0, filenames.Length);
            lines = System.IO.File.ReadAllLines(filenames[file_index]);

            for (int i = 0; i < 30; i++)
            {
                if (i % 2 == 0)
                    questions[i / 2] = lines[i];
                if (i % 2 == 1)
                    answers[i / 2] = lines[i];
            }
            twowayshuffle();
            queue = new Queue<int>();
            secondsToAnswer = 10;
            InitializeComponent();
            this.igrachi = igrachi;
            player1.Text = igrachi[0].ime + " " + igrachi[0].prezime;
            player2.Text = igrachi[1].ime + " " + igrachi[1].prezime;
            if (igrachi.Count >= 3)
            {
                player3.Text = igrachi[2].ime + " " + igrachi[2].prezime;
                if (igrachi.Count == 4)
                {
                    player4.Text = igrachi[3].ime + " " + igrachi[3].prezime;
                }
                else
                {
                    player4.Hide();
                }
            }
            else
            {
                player3.Hide();
                player4.Hide();
            }
            verify.Enabled = false;
            progressBar1.Maximum = secondsToAnswer;
            progressBar1.Value = secondsToAnswer;

            timer = new Timer { Interval = 1000 };
            timer.Tick += TimerOnTick;
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            if (secondsToAnswer > 0)
            {
                bool flag = true;
                foreach (Igrach i in igrachi)
                    if (!i.locked)
                    {
                        flag = false;
                        break;
                    }
                if (flag)
                    secondsToAnswer = 0;
                else
                    secondsToAnswer--;

                secondsLeft.Text = secondsToAnswer.ToString();
                progressBar1.Value = secondsToAnswer;
            }
            else
            {
                timer.Stop();
                this.KeyPreview = false;
                answer.ReadOnly = false;
                verify.Enabled = true;
                if (queue.Count != 0) {
                    playerToAnswer = queue.Dequeue();
                    colorField();
                }
                else
                {
                    verify.Enabled = false;
                    answer.ReadOnly = true;
                    isCorrect.Text = "Точниот одговор е:";
                    string[] answersOfAnswer = answers[counter].Split(' ');
                    answer.Text = answersOfAnswer[0];
                    nextQuestion.Enabled = true;
                }
            }
        }

        private void Igra_4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 1)
                Application.Exit();
        }

        private void verify_Click(object sender, EventArgs e)
        {
            
            String[] answersOfQuestion = answers[counter].Split(' ');
            if (answersOfQuestion.Contains(answer.Text))
            {
                answer.ReadOnly = true;
                igrachi[playerToAnswer].poeniVkupno += 3;
                queue = new Queue<int>();
                verify.Enabled = false;
                nextQuestion.Enabled = true;
                isCorrect.Text = "Точен Одговор";
            }

            else {
                igrachi[playerToAnswer].poeniVkupno -= 3;
                isCorrect.Text = "Погрешен Одговор";
                answer.Text = "";
                if (queue.Count != 0)
                {
                    playerToAnswer = queue.Dequeue();
                    player1.BackColor = Color.White;
                    player2.BackColor = Color.White;
                    player3.BackColor = Color.White;
                    player4.BackColor = Color.White;
                    colorField();

                }
                else
                {
                    isCorrect.Text = "Точниот одговор е:";
                    answer.Text = answersOfQuestion[0];
                    verify.Enabled = false;
                    nextQuestion.Enabled = true;
                    player1.BackColor = Color.White;
                    player2.BackColor = Color.White;
                    player3.BackColor = Color.White;
                    player4.BackColor = Color.White;
                }
                
            }
            
        }

        private void nextQuestion_Click(object sender, EventArgs e)
        {
            isCorrect.Text = "";
            answer.ReadOnly = true;
            secondsToAnswer = 10;
            answer.Text = "";
            this.KeyPreview = true;
            foreach (Igrach i in igrachi)
                i.locked = false;
            nextQuestion.Enabled = false;
            verify.Enabled = false;
            progressBar1.Value = secondsToAnswer;
            secondsLeft.Text = secondsToAnswer.ToString();
            question.Text = questions[++counter];
            player1.BackColor = Color.White;
            player2.BackColor = Color.White;
            player3.BackColor = Color.White;
            player4.BackColor = Color.White;
            timer.Start();
        }

        private void Igra_4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.D1) && !igrachi[0].locked)
            {
                queue.Enqueue(0);
                player1.BackColor = Color.Yellow;
                igrachi[0].locked = true;
            }
            else if (e.KeyData.Equals(Keys.Z) && !igrachi[1].locked)
            {
                queue.Enqueue(1);
                player2.BackColor = Color.Yellow;
                igrachi[1].locked = true;
            }
            else if (e.KeyData.Equals(Keys.D7) && !igrachi[2].locked)
            {
                queue.Enqueue(2);
                player3.BackColor = Color.Yellow;
                igrachi[2].locked = true;
            }
            else if (e.KeyData.Equals(Keys.N) && !igrachi[3].locked)
            {
                queue.Enqueue(3);
                player4.BackColor = Color.Yellow;
                igrachi[3].locked = true;
            }
        }

        private void leaderboard_Click(object sender, EventArgs e)
        {
            LeaderBoard form = new LeaderBoard(igrachi);
            form.Show();
        }

       
    }
}