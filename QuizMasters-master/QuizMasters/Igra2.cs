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
            lockedbuttons = new bool[16];
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
            NextPlayer_Click(null,null);
        }

        private void NextPlayer_Click(object sender, EventArgs e)
        {
            if (solved)
            {
                ///new form
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
            A1.Text = A_words[0];
            lockedbuttons[0] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void A2_Click(object sender, EventArgs e)
        {
            A2.Text = A_words[1];
            lockedbuttons[1] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void A3_Click(object sender, EventArgs e)
        {
            A3.Text = A_words[2];
            lockedbuttons[2] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void A4_Click(object sender, EventArgs e)
        {
            A4.Text = A_words[3];
            lockedbuttons[3] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void B1_Click(object sender, EventArgs e)
        {
            B1.Text = B_words[0];
            lockedbuttons[4] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void B2_Click(object sender, EventArgs e)
        {
            B2.Text = B_words[1];
            lockedbuttons[5] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void B3_Click(object sender, EventArgs e)
        {
            B3.Text = B_words[2];
            lockedbuttons[6] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void B4_Click(object sender, EventArgs e)
        {
            B4.Text = B_words[3];
            lockedbuttons[7] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void C1_Click(object sender, EventArgs e)
        {
            C1.Text = C_words[0];
            lockedbuttons[8] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void C2_Click(object sender, EventArgs e)
        {
            C2.Text = C_words[1];
            lockedbuttons[9] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void C3_Click(object sender, EventArgs e)
        {
            C3.Text = C_words[2];
            lockedbuttons[10] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void C4_Click(object sender, EventArgs e)
        {
            C4.Text = C_words[3];
            lockedbuttons[11] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void D1_Click(object sender, EventArgs e)
        {
            D1.Text = D_words[0];
            lockedbuttons[12] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void D2_Click(object sender, EventArgs e)
        {
            D2.Text = D_words[1];
            lockedbuttons[13] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void D3_Click(object sender, EventArgs e)
        {
            D3.Text = D_words[2];
            lockedbuttons[14] = true;
            setCLickable(false);
            NextPlayer.Enabled = true;
        }

        private void D4_Click(object sender, EventArgs e)
        {
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
    }
}
