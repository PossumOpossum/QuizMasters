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
    public partial class Igra_3 : Form
    {
        private int maxturn;
        private int turn;
        private string[] filenames;
        private int Qindex;
        public List<Igrach> igrachi { get; set; }
        private string[] kategorii;
        private string[] prasanja;
        private string[] odgovori;
        private bool finished;
        private string[] lines;
        
        private bool[] openedQuestions{get;set;}
        private List<Button> buttons { get; set; }
        private int playerAnswering { get; set; }
        private void disableQuestions()
        {
            foreach(Button bt in buttons)
            {
                bt.Enabled = false;
            }
        }
        private void enableQuestions()
        {
            for(int i = 0; i < openedQuestions.Length; i++)
            {
                if (!openedQuestions[i])
                    buttons[i].Enabled = true;
            }
        }
        private void disablePlayerChoice()
        {
            button21.Enabled = false;
            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
        }
        private void enablePlayerChoice(int i)
        {
            if (i != 0)
                button21.Enabled = true;
            if (i != 1)
                button22.Enabled = true;
            if (i != 2)
                button23.Enabled = true;
            if (i != 3)
                button24.Enabled = true;
        }
        public Igra_3(List<Igrach> igrachi)
        {
            InitializeComponent();
            disablePlayerChoice();
            Odgovor.ReadOnly = true;
            verify.Enabled = false;
            NextPlayer.Enabled = false;
            buttons = new List<Button>();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);
            buttons.Add(button17);
            buttons.Add(button18);
            buttons.Add(button19);
            buttons.Add(button20);

            finished = false;
            Qindex = 0;
            filenames = System.IO.Directory.GetFiles(@"Treta");
            Random rand = new Random();
            int file_index = rand.Next(0,filenames.Length);
            lines = System.IO.File.ReadAllLines(filenames[file_index]);
            
            odgovori = new string[20];
            prasanja = new string[20];
            kategorii = new string[20];
            for(int i = 0; i < 60; i++)
            {
                if (i % 3 == 0)
                    kategorii[i / 3] = lines[i];
                if (i % 3 == 1)
                    prasanja[i / 3] = lines[i];
                if (i % 3 == 2)
                    odgovori[i / 3] = lines[i];
            }

            threewayshuffle();
            openedQuestions = new bool[20];
            this.igrachi = igrachi;
            player1.Text = igrachi[0].ime + " " + igrachi[0].prezime;
            button21.Text = igrachi[0].ime + " " + igrachi[0].prezime;
            player2.Text = igrachi[1].ime + " " + igrachi[1].prezime;
            button22.Text = igrachi[1].ime + " " + igrachi[1].prezime;
            if (igrachi.Count >= 3)
            {
                player3.Text = igrachi[2].ime + " " + igrachi[2].prezime;
                button23.Text = igrachi[2].ime + " " + igrachi[2].prezime;
                if (igrachi.Count == 4)
                {
                    player4.Text = igrachi[3].ime + " " + igrachi[3].prezime;
                    button24.Text = igrachi[3].ime + " " + igrachi[3].prezime;
                }
                else
                {
                    player4.Hide();
                    button24.Hide();
                }
            }
            else
            {
                player3.Hide();
                player4.Hide();
                button23.Hide();
                button24.Hide();
            }


            int min = 100;
            int index = 0;
            for (int i = 0; i < igrachi.Count; i++)
            {
                if (igrachi[i].poeniVkupno < min)
                {
                    min = igrachi[i].poeniVkupno;
                    index = i;
                }
            }
            maxturn = igrachi.Count - 1;
            turn = index;
            if (turn == 0)
                turn = maxturn;
            else
            {
                turn--;
            }
            NextPlayer_Click(null, null);
        }

        private void Igra_3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 1)
                Application.Exit();
        }

        private void NextPlayer_Click(object sender, EventArgs e)
        {
            if (finished)
            {

            ////nova igra                
            }
            Prasanje.Text = "";
            Odgovor.Text = "";
            textBox2.BackColor = Color.LightGray;
            textBox1.BackColor = Color.LightGray;
            player1.BackColor = Color.White;
            player2.BackColor = Color.White;
            player3.BackColor = Color.White;
            player4.BackColor = Color.White;

            turn++;
            if (turn == maxturn + 1)
                turn = 0;

            if (turn == 0)
                player1.BackColor = Color.LightGreen;
            if (turn == 1)
                player2.BackColor = Color.LightGreen;
            if (turn == 2)
                player3.BackColor = Color.LightGreen;
            if (turn == 3)
                player4.BackColor = Color.LightGreen;
            verify.Enabled = false;
            Odgovor.ReadOnly = true;
            enableQuestions();
            NextPlayer.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Qindex = 0;
            button1.Text = kategorii[0];
            disableQuestions();
            button1.BackColor = Color.White;
            openedQuestions[0] = true;
            enablePlayerChoice(turn);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Qindex = 1;
            button2.Text = kategorii[1];
            disableQuestions();
            button2.BackColor = Color.White;
            openedQuestions[1] = true;
            enablePlayerChoice(turn);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Qindex = 2;
            button3.Text = kategorii[2];
            disableQuestions();
            button3.BackColor = Color.White;
            openedQuestions[2] = true;
            enablePlayerChoice(turn);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Qindex = 3;
            button4.Text = kategorii[3];
            disableQuestions();
            button4.BackColor = Color.White;
            openedQuestions[3] = true;
            enablePlayerChoice(turn);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Qindex = 4;
            button5.Text = kategorii[4];
            disableQuestions();
            button5.BackColor = Color.White;
            openedQuestions[4] = true;
            enablePlayerChoice(turn);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Qindex = 5;
            button6.Text = kategorii[5];
            disableQuestions();
            button6.BackColor = Color.White;
            openedQuestions[5] = true;
            enablePlayerChoice(turn);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Qindex = 6;
            button7.Text = kategorii[6];
            disableQuestions();
            button7.BackColor = Color.White;
            openedQuestions[6] = true;
            enablePlayerChoice(turn);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Qindex = 7;
            button8.Text = kategorii[7];
            disableQuestions();
            button8.BackColor = Color.White;
            openedQuestions[7] = true;
            enablePlayerChoice(turn);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Qindex = 8;
            button9.Text = kategorii[8];
            disableQuestions();
            button9.BackColor = Color.White;
            openedQuestions[8] = true;
            enablePlayerChoice(turn);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Qindex = 9;
            button10.Text = kategorii[9];
            disableQuestions();
            button10.BackColor = Color.White;
            openedQuestions[9] = true;
            enablePlayerChoice(turn);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Qindex = 10;
            button11.Text = kategorii[10];
            disableQuestions();
            button11.BackColor = Color.White;
            openedQuestions[10] = true;
            enablePlayerChoice(turn);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Qindex = 11;
            button12.Text = kategorii[11];
            disableQuestions();
            button12.BackColor = Color.White;
            openedQuestions[11] = true;
            enablePlayerChoice(turn);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Qindex = 12;
            button13.Text = kategorii[12];
            disableQuestions();
            button13.BackColor = Color.White;
            openedQuestions[12] = true;
            enablePlayerChoice(turn);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Qindex = 13;
            button14.Text = kategorii[13];
            disableQuestions();
            button14.BackColor = Color.White;
            openedQuestions[13] = true;
            enablePlayerChoice(turn);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Qindex = 14;
            button15.Text = kategorii[14];
            disableQuestions();
            button15.BackColor = Color.White;
            openedQuestions[14] = true;
            enablePlayerChoice(turn);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Qindex = 15;
            button16.Text = kategorii[15];
            disableQuestions();
            button16.BackColor = Color.White;
            openedQuestions[15] = true;
            enablePlayerChoice(turn);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Qindex = 16;
            button17.Text = kategorii[16];
            disableQuestions();
            button17.BackColor = Color.White;
            openedQuestions[16] = true;
            enablePlayerChoice(turn);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Qindex = 17;
            button18.Text = kategorii[17];
            disableQuestions();
            button18.BackColor = Color.White;
            openedQuestions[17] = true;
            enablePlayerChoice(turn);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Qindex = 18;
            button19.Text = kategorii[18];
            disableQuestions();
            button19.BackColor = Color.White;
            openedQuestions[18] = true;
            enablePlayerChoice(turn);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Qindex = 19;
            button20.Text = kategorii[19];
            disableQuestions();
            button20.BackColor = Color.White;
            openedQuestions[19] = true;
            enablePlayerChoice(turn);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Prasanje.Text = prasanja[Qindex];
            playerAnswering = 0;
            Odgovor.ReadOnly = false;
            verify.Enabled = true;
            disablePlayerChoice();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Prasanje.Text = prasanja[Qindex];
            playerAnswering = 1;
            Odgovor.ReadOnly = false;
            verify.Enabled = true;
            disablePlayerChoice();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Prasanje.Text = prasanja[Qindex];
            playerAnswering = 2;
            Odgovor.ReadOnly = false;
            verify.Enabled = true;
            disablePlayerChoice();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Prasanje.Text = prasanja[Qindex];
            playerAnswering = 3;
            Odgovor.ReadOnly = false;
            verify.Enabled = true;
            disablePlayerChoice();
        }

        private void verify_Click(object sender, EventArgs e)
        {
            string[] answers = odgovori[Qindex].Split(' ');
            if (answers.Contains(Odgovor.Text))
            {
                igrachi[turn].poeniVkupno -= 3;
                igrachi[playerAnswering].poeniVkupno += 3;
                textBox1.BackColor = Color.LightGreen;
            }
            else
            {
                igrachi[turn].poeniVkupno += 3;
                igrachi[playerAnswering].poeniVkupno -= 3;
                textBox2.BackColor = Color.Red;
            }
            verify.Enabled = false;
            NextPlayer.Enabled = true;
            bool flag = false;
            foreach (bool b in openedQuestions)
            {
                if (!b)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                NextPlayer.Text = "Нова Игра";
                finished = true;
            }
        }

        private void Leaderboard_Click(object sender, EventArgs e)
        {
            LeaderBoard form = new LeaderBoard(igrachi);
            form.Show();
        }

        private void threewayshuffle()
        {
            Random rng = new Random();
            int n = 20;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = prasanja[k];
                prasanja[k] = prasanja[n];
                prasanja[n] = value;

                value = odgovori[k];
                odgovori[k] = odgovori[n];
                odgovori[n] = value;

                value = kategorii[k];
                kategorii[k] = kategorii[n];
                kategorii[n] = value;
            }
        }

        private void Odgovor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
            {
                verify_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
