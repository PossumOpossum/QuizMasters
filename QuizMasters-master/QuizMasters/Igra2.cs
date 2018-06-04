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
    public partial class Igra2 : Form
    {
        public List<Igrach> igrachi { get; set; }
        public int turn { get; set; }
        public string[] lines { get; set; }
        public string[] A_words { get; set; }
        public string[] A_solutions { get; set; }
        public string[] B_words { get; set; }
        public string[] B_solutions { get; set; }
        public string[] C_words { get; set; }
        public string[] C_solutions { get; set; }
        public string[] D_words { get; set; }
        public string[] D_solutions { get; set; }
        public string[] full_solutions { get; set; }
        public string[] filenames { get; set; }
        public int maxturn { get; set; }
        public List<Button> buttons { get; set; }
        public bool[] lockedbuttons { get; set; }
        private bool solved;
        public bool[] columns { get; set; }
        public HashSet<int> enabledForAnswering { get; set; }

        private void setCLickable(bool mybool)
        {
            for (int i = 0; i < 16; i++)
            {
                if (!lockedbuttons[i])
                {
                    buttons[i].Enabled = mybool;
                    buttons[i].BackColor = Color.LightGray;
                }
                else
                {
                    buttons[i].BackColor = Color.White;
                    buttons[i].Enabled = false;
                }

            }
        }
        private void deservesPoints(int start, int end)
        {
            int pointsForNow = 0;
            for (int i = start; i < end; i++)
            {
                if (lockedbuttons[i] == false)
                    pointsForNow++;
            }
            igrachi[turn].poeniVkupno += pointsForNow;
        }
        private void disableAnswers()
        {
            VerifyA.Enabled = false;
            VerifyB.Enabled = false;
            VerifyC.Enabled = false;
            VerifyD.Enabled = false;
            VerifyFull.Enabled = false;
        }
        private void enableAnswers()
        {
            foreach(int i in enabledForAnswering)
            {
                if (i == 0)
                    VerifyA.Enabled = true;
                else if (i == 1)
                    VerifyB.Enabled = true;
                else if (i == 2)
                    VerifyC.Enabled = true;
                else if (i == 3)
                    VerifyD.Enabled = true;
                else if (i == 4)
                    VerifyFull.Enabled = true;
            }
        }
        public Igra2(List<Igrach> igrachi)
        {
            InitializeComponent();
            solved = false;
            buttons = new List<Button>();
            buttons.Add(A1);
            buttons.Add(A2);
            buttons.Add(A3);
            buttons.Add(A4);
            buttons.Add(B1);
            buttons.Add(B2);
            buttons.Add(B3);
            buttons.Add(B4);
            buttons.Add(C1);
            buttons.Add(C2);
            buttons.Add(C3);
            buttons.Add(C4);
            buttons.Add(D1);
            buttons.Add(D2);
            buttons.Add(D3);
            buttons.Add(D4);
            Answer1.ReadOnly = true;
            Answer2.ReadOnly = true;
            Answer3.ReadOnly = true;
            Answer4.ReadOnly = true;
            lockedbuttons = new bool[16];
            columns = new bool[4];
            enabledForAnswering = new HashSet<int>();
            filenames = System.IO.Directory.GetFiles(@"Asocijacii");
            Random rand = new Random();
            int file_index = rand.Next(filenames.Length);
            lines = System.IO.File.ReadAllLines(filenames[file_index]);
            A_words = lines[0].Split(' ');
            A_solutions = lines[1].Split(' ');
            B_words = lines[2].Split(' ');
            B_solutions = lines[3].Split(' ');
            C_words = lines[4].Split(' ');
            C_solutions = lines[5].Split(' ');
            D_words = lines[6].Split(' ');
            D_solutions = lines[7].Split(' ');
            full_solutions = lines[8].Split(' ');

            A_words.ListShuffle();
            B_words.ListShuffle();
            C_words.ListShuffle();
            D_words.ListShuffle();

            this.igrachi = igrachi;
            Player_1.Text = igrachi[0].ime + " " + igrachi[0].prezime;
            Player_2.Text = igrachi[1].ime + " " + igrachi[1].prezime;
            if(igrachi.Count >=3)
            {
                Player_3.Text = igrachi[2].ime + " " + igrachi[2].prezime;
                if (igrachi.Count == 4)
                    Player_4.Text = igrachi[3].ime + " " + igrachi[3].prezime;
                else
                    Player_4.Hide();
            }
            else
            {
                Player_3.Hide();
                Player_4.Hide();
            }

            int min = 100;
            int index = 0;
            for (int i = 0;i<igrachi.Count;i++)
            {
                if(igrachi[i].poeniVkupno < min)
                {
                    min = igrachi[i].poeniVkupno;
                    index = i;
                }
            }
            maxturn = igrachi.Count-1;
            turn = index;
            if (turn == 0)
                turn = maxturn;
            else
            {
                turn--;
            }
            NextPlayer_Click(null,null);
        }

        private void NextPlayer_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach(bool bl in lockedbuttons)
            {
                if (!bl)
                    flag = true;
            }
            if (flag)
            {
                disableAnswers();
            }
            if (solved)
            {
                ///new form
                Igra_3 forma = new Igra_3(igrachi);
                forma.Show();
                this.Close();
            }
                Player_1.BackColor = Color.White;
                Player_2.BackColor = Color.White;
                Player_3.BackColor = Color.White;
                Player_4.BackColor = Color.White;

            turn++;
            if (turn == maxturn+1)
                turn = 0;
            
            if (turn == 0)
                Player_1.BackColor = Color.LightGreen;
            if (turn == 1)
                Player_2.BackColor = Color.LightGreen;
            if (turn == 2)
                Player_3.BackColor = Color.LightGreen;
            if (turn == 3)
                Player_4.BackColor = Color.LightGreen;

            NextPlayer.Enabled = false;

            setCLickable(true);
        }

        private void A1_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(0);
            enableAnswers();
            Answer1.ReadOnly = false;
            A1.Text = A_words[0];
            lockedbuttons[0] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void A2_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(0);
            enableAnswers();
            Answer1.ReadOnly = false;
            A2.Text = A_words[1];
            lockedbuttons[1] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void A3_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(0);
            enableAnswers();
            Answer1.ReadOnly = false;
            A3.Text = A_words[2];
            lockedbuttons[2] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void A4_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(0);
            enableAnswers();
            Answer1.ReadOnly = false;
            A4.Text = A_words[3];
            lockedbuttons[3] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void B1_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(1);
            enableAnswers();
            Answer2.ReadOnly = false;
            B1.Text = B_words[0];
            lockedbuttons[4] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void B2_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(1);
            enableAnswers();
            Answer2.ReadOnly = false;
            B2.Text = B_words[1];
            lockedbuttons[5] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void B3_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(1);
            enableAnswers();
            Answer2.ReadOnly = false;
            B3.Text = B_words[2];
            lockedbuttons[6] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void B4_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(1);
            enableAnswers();
            Answer2.ReadOnly = false;
            B4.Text = B_words[3];
            lockedbuttons[7] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void C1_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(2);
            enableAnswers();
            Answer3.ReadOnly = false;
            C1.Text = C_words[0];
            lockedbuttons[8] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void C2_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(2);
            enableAnswers();
            Answer3.ReadOnly = false;
            C2.Text = C_words[1];
            lockedbuttons[9] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void C3_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(2);
            enableAnswers();
            Answer3.ReadOnly = false;
            C3.Text = C_words[2];
            lockedbuttons[10] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void C4_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(2);
            enableAnswers();
            Answer3.ReadOnly = false;
            C4.Text = C_words[3];
            lockedbuttons[11] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void D1_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(3);
            enableAnswers();
            Answer4.ReadOnly = false;
            D1.Text = D_words[0];
            lockedbuttons[12] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void D2_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(3);
            enableAnswers();
            Answer4.ReadOnly = false;
            D2.Text = D_words[1];
            lockedbuttons[13] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void D3_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(3);
            enableAnswers();
            Answer4.ReadOnly = false;
            D3.Text = D_words[2];
            lockedbuttons[14] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void D4_Click(object sender, EventArgs e)
        {
            enabledForAnswering.Add(3);
            enableAnswers();
            Answer4.ReadOnly = false;
            D4.Text = D_words[3];
            lockedbuttons[15] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void Igra2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 1)
                Application.Exit();
        }

        private void Leaderboard_Click(object sender, EventArgs e)
        {
            LeaderBoard form = new LeaderBoard(igrachi);
            form.Show();
        }

        private void VerifyA_Click(object sender, EventArgs e)
        {
            if (A_solutions.Contains(Answer1.Text))
            {
                enabledForAnswering.Remove(0);
                enabledForAnswering.Add(4);
                enableAnswers();
                deservesPoints(0, 4);
                columns[0] = true;
                A1.Text = A_words[0];
                A2.Text = A_words[1];
                A3.Text = A_words[2];
                A4.Text = A_words[3];
                A1.BackColor = Color.White;
                A2.BackColor = Color.White;
                A3.BackColor = Color.White;
                A4.BackColor = Color.White;
                A1.Enabled = false;
                A2.Enabled = false;
                A3.Enabled = false;
                A4.Enabled = false;
                lockedbuttons[0] = true;
                lockedbuttons[1] = true;
                lockedbuttons[2] = true;
                lockedbuttons[3] = true;
                VerifyA.Enabled = false;
                Answer1.ReadOnly = true;
            }
            else
            {
                Answer1.Text = "";
                NextPlayer_Click(null, null);
            }
            
        }

        private void VerifyB_Click(object sender, EventArgs e)
        {
            if (B_solutions.Contains(Answer2.Text))
            {
                enabledForAnswering.Remove(1);
                enabledForAnswering.Add(4);
                enableAnswers();
                deservesPoints(4, 8);
                columns[1] = true;
                B1.Text = B_words[0];
                B2.Text = B_words[1];
                B3.Text = B_words[2];
                B4.Text = B_words[3];
                B1.BackColor = Color.White;
                B2.BackColor = Color.White;
                B3.BackColor = Color.White;
                B4.BackColor = Color.White;
                B1.Enabled = false;
                B2.Enabled = false;
                B3.Enabled = false;
                B4.Enabled = false;
                lockedbuttons[4] = true;
                lockedbuttons[5] = true;
                lockedbuttons[6] = true;
                lockedbuttons[7] = true;
                VerifyB.Enabled = false;
                Answer2.ReadOnly = true;
            }
            else
            {
                Answer2.Text = "";
                NextPlayer_Click(null, null);
            }

        }

        private void VerifyC_Click(object sender, EventArgs e)
        {
            if (C_solutions.Contains(Answer3.Text))
            {
                enabledForAnswering.Remove(2);
                enabledForAnswering.Add(4);
                enableAnswers();
                deservesPoints(8, 12);
                columns[2] = true;
                C1.Text = C_words[0];
                C2.Text = C_words[1];
                C3.Text = C_words[2];
                C4.Text = C_words[3];
                C1.BackColor = Color.White;
                C2.BackColor = Color.White;
                C3.BackColor = Color.White;
                C4.BackColor = Color.White;
                C1.Enabled = false;
                C2.Enabled = false;
                C3.Enabled = false;
                C4.Enabled = false;
                lockedbuttons[8] = true;
                lockedbuttons[9] = true;
                lockedbuttons[10] = true;
                lockedbuttons[11] = true;
                VerifyC.Enabled = false;
                Answer3.ReadOnly = true;
            }
            else
            {
                Answer3.Text = "";
                NextPlayer_Click(null, null);
            }
        }

        private void VerifyD_Click(object sender, EventArgs e)
        {
            if (D_solutions.Contains(Answer4.Text))
            {
                enabledForAnswering.Remove(3);
                enabledForAnswering.Add(4);
                enableAnswers();
                deservesPoints(12, 16);
                columns[3] = true;
                D1.Text = D_words[0];
                D2.Text = D_words[1];
                D3.Text = D_words[2];
                D4.Text = D_words[3];
                D1.BackColor = Color.White;
                D2.BackColor = Color.White;
                D3.BackColor = Color.White;
                D4.BackColor = Color.White;
                D1.Enabled = false;
                D2.Enabled = false;
                D3.Enabled = false;
                D4.Enabled = false;
                lockedbuttons[12] = true;
                lockedbuttons[13] = true;
                lockedbuttons[14] = true;
                lockedbuttons[15] = true;
                VerifyD.Enabled = false;
                Answer4.ReadOnly = true;
            }
            else
            {
                Answer4.Text = "";
                NextPlayer_Click(null, null);
            }
        }

        private void VerifyFull_Click(object sender, EventArgs e)
        {
            if (full_solutions.Contains(FullAnswer.Text))
            {
                VerifyFull.Enabled = false;
                int pointsForNow = 4;
                foreach(bool bl in columns)
                {
                    if (!bl)
                        pointsForNow += 2;
                }
                igrachi[turn].poeniVkupno += pointsForNow;
                A1.Text = A_words[0];
                A2.Text = A_words[1];
                A3.Text = A_words[2];
                A4.Text = A_words[3];
                A1.BackColor = Color.White;
                A2.BackColor = Color.White;
                A3.BackColor = Color.White;
                A4.BackColor = Color.White;
                A1.Enabled = false;
                A2.Enabled = false;
                A3.Enabled = false;
                A4.Enabled = false;
                lockedbuttons[0] = true;
                lockedbuttons[1] = true;
                lockedbuttons[2] = true;
                lockedbuttons[3] = true;
                VerifyA.Enabled = false;
                Answer1.Text = A_solutions[0];
                Answer1.ReadOnly = true;

                B1.Text = B_words[0];
                B2.Text = B_words[1];
                B3.Text = B_words[2];
                B4.Text = B_words[3];
                B1.BackColor = Color.White;
                B2.BackColor = Color.White;
                B3.BackColor = Color.White;
                B4.BackColor = Color.White;
                B1.Enabled = false;
                B2.Enabled = false;
                B3.Enabled = false;
                B4.Enabled = false;
                lockedbuttons[4] = true;
                lockedbuttons[5] = true;
                lockedbuttons[6] = true;
                lockedbuttons[7] = true;
                VerifyB.Enabled = false;
                Answer2.Text = B_solutions[0];
                Answer2.ReadOnly = true;

                C1.Text = C_words[0];
                C2.Text = C_words[1];
                C3.Text = C_words[2];
                C4.Text = C_words[3];
                C1.BackColor = Color.White;
                C2.BackColor = Color.White;
                C3.BackColor = Color.White;
                C4.BackColor = Color.White;
                C1.Enabled = false;
                C2.Enabled = false;
                C3.Enabled = false;
                C4.Enabled = false;
                lockedbuttons[8] = true;
                lockedbuttons[9] = true;
                lockedbuttons[10] = true;
                lockedbuttons[11] = true;
                VerifyC.Enabled = false;
                Answer3.Text = C_solutions[0];
                Answer3.ReadOnly = true;

                D1.Text = D_words[0];
                D2.Text = D_words[1];
                D3.Text = D_words[2];
                D4.Text = D_words[3];
                D1.BackColor = Color.White;
                D2.BackColor = Color.White;
                D3.BackColor = Color.White;
                D4.BackColor = Color.White;
                D1.Enabled = false;
                D2.Enabled = false;
                D3.Enabled = false;
                D4.Enabled = false;
                lockedbuttons[12] = true;
                lockedbuttons[13] = true;
                lockedbuttons[14] = true;
                lockedbuttons[15] = true;
                VerifyD.Enabled = false;
                Answer4.Text = D_solutions[0];
                Answer4.ReadOnly = true;
                solved = true;
                NextPlayer.Text = "Нова Игра";
            }
            else
            {
                FullAnswer.Text = "";
                NextPlayer_Click(null, null);
            }
        }

        private void Answer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
                VerifyA_Click(null, null);
        }

        private void Answer2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
                VerifyB_Click(null, null);
        }

        private void Answer3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
                VerifyC_Click(null, null);
        }

        private void Answer4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
                VerifyD_Click(null, null);
        }

        private void FullAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter))
                VerifyFull_Click(null, null);
        }
    }
}
