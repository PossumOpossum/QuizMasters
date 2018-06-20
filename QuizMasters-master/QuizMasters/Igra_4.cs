using System;
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
        private bool finished;
        public Igra_4(List<Igrach> igrachi)
        {
            finished = false;
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
                    answer.Text = WhiteSpace.FIX(answersOfAnswer[0]);
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
            for (int i = 0; i < answersOfQuestion.Length; i++)
                answersOfQuestion[i] = WhiteSpace.FIX(answersOfQuestion[i]);
            if (answersOfQuestion.Contains(answer.Text.ToLower()))
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
                    if(playerToAnswer == 0)
                        player1.BackColor = Color.Red;
                    if (playerToAnswer == 1)
                        player2.BackColor = Color.Red;
                    if (playerToAnswer == 2)
                        player3.BackColor = Color.Red;
                    if (playerToAnswer == 3)
                        player4.BackColor = Color.Red;
                    playerToAnswer = queue.Dequeue();

                    colorField();

                }
                else
                {
                    isCorrect.Text = "Точниот одговор е:";
                    answer.Text = answersOfQuestion[0];
                    verify.Enabled = false;
                    nextQuestion.Enabled = true;
                    player1.BackColor = Color.Red;
                    player2.BackColor = Color.Red;
                    player3.BackColor = Color.Red;
                    player4.BackColor = Color.Red;
                }
                
            }
            
        }

        private void nextQuestion_Click(object sender, EventArgs e)
        {
            if (finished)
            {
                int qualified = 0;
                int help_index = 0;
                int tempmax = -100;
                int maxindex = 0;
                for (int i = 0; i < igrachi.Count; i++)
                {
                    if (igrachi[i].poeniVkupno > 0)
                    {
                        qualified++;
                        help_index = i;
                    }
                    if(igrachi[i].poeniVkupno > tempmax)
                    {
                        tempmax = igrachi[i].poeniVkupno;
                        maxindex = i;
                    }
                }
                if (qualified > 1)
                  {
                    Igra_5 igra5 = new Igra_5(igrachi);
                    igra5.Show();
                    this.Close();
                    Upatsvo form = new Upatsvo("Петтата игра се вика \"Лицитација\".\nОваа игра смеат да ја играат само натпреварувачите кои што имаат повеќе од 0 поени.\nПравила на играта:\nИграта ја започнува натпреварувачот на кој името и презимето во горниот дел од прозорецот се обоени со зелена боја. Натпреварувачот најпрво треба да одбере колку поени сака да вложи (не смее да вложи повеќе отколку што има во моментот). Потоа натпреварувачот треба да одбере една од 4те дадени категории. И на крај натпреварувачот треба да го одговори прашањето од дадената категорија во полето обележано за одговор.\nДоколку одговорот кој го внесе натпреварувачот е точен, натпреварувачот ќе добие толку поени колку што вложил, во спротивно вложените поени ќе му се одземат. Има вкупно 16 прашања.");
                    form.Show();
                }
                else if (qualified == 1)
                  {
                    MessageBox.Show("Победник е " + igrachi[help_index].ime + " " + igrachi[help_index].prezime);
                    this.Close();
                  }
                else
                {
                    MessageBox.Show("Победник е " + igrachi[maxindex].ime + " " + igrachi[maxindex].prezime);
                    this.Close();
                }
                
            }
            else
            {
                if (counter == 8)
                {
                    finished = true;
                    nextQuestion.Text = "Наредна Игра";
                }
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
        }

        private void Igra_4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.D1) && !igrachi[0].locked)
            {
                queue.Enqueue(0);
                player1.BackColor = Color.Yellow;
                igrachi[0].locked = true;
            }
            else if (e.KeyData.Equals(Keys.X) && !igrachi[1].locked)
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

        private void answer_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.Equals(Keys.Enter) && verify.Enabled)
            {
                verify_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Upatsvo form = new Upatsvo("Четвртата игра во квизот се вика \"Брзи прсти\".\nПравилата на играта се: Играта започува со притискање на копчето \"Нареден играч\". Во горниот дел на прозорецот е дадено прашање. Секој од натпреварувачите доколку го знае одговорот треба да притисне на доделеното копче од тастатура за да влезе во ред за одговарање додека не истече тајмерот во долниот дел на прозорецот кој што трае 10 секунди.\n1) За првиот натпреварувач да влезе во редот за одговарање треба да го притисне копчето \"1\".\n2) За вториот натпреварувач да влезе во редот за одговарање треба да го притисне копчето \"X\".\n3) За третиот натпреварувач да влезе во редот за одговарање треба да го притисне копчето \"7\".\n4) За четвртиот натпреварувач да влезе во редот за одговарање треба да го притисне копчето \"N\".\nДоколку натпреварувачот е влезен во редот за одговарање полето со неговото име и презиме ќе се обои со жолта боја. Откако ќе истече тајмерот, натпреварувачите го одговараат прашањто во даденото поле се додека некој не го погоди одговорт или не поминат сите натпреварувачи од редот (прв одговара тој што прв влегол во редот за одговарање). Полето на натпреварувачот кој треба да одговара ќе се обои во зелена боја. Доколку го погоди одговорот ќе му се додадат (број на поени) поени, а доколку не одговори точно ќе му се одземат (број на поени) поени. ");
            form.Show();
        }
    }
}
