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
    public partial class Igra_5 : Form
    {
        List<Igrach> igrachi;
        List<Igrach> igrachiVoIgra;
        private int maxturn;
        private int turn;
        private string[] filenames;
        private string[] kategorii;
        private string[] prasanja1;
        private string[] prasanja2;
        private string[] prasanja3;
        private string[] prasanja4;
        private string[] odgovori1;
        private string[] odgovori2;
        private string[] odgovori3;
        private string[] odgovori4;
        private string[] lines;
        private int c1Index;
        private int c2Index;
        private int c3Index;
        private int c4Index;
        private int pointsRisked;
        private void twowayshuffle(string[] prva, string[] vtora)
        {
            Random rng = new Random();
            int n = prva.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = prva[k];
                prva[k] = prva[n];
                prva[n] = value;

                value = vtora[k];
                vtora[k] = vtora[n];
                vtora[n] = value;
            }
        }
        public void disableCategories()
        {
            category1.Enabled = false;
            category2.Enabled = false;
            category3.Enabled = false;
            category4.Enabled = false;
        }
        public void enableCategories()
        {
            if (c1Index < 4)
                category2.Enabled = true;
            if (c1Index < 4)
                category2.Enabled = true;
            if (c1Index < 4)
                category3.Enabled = true;
            if (c1Index < 4)
                category4.Enabled = true;
        }
        public Igra_5(List<Igrach> igrachi)
        {
            InitializeComponent();
            pointsRisked = 0;
            igrachiVoIgra = new List<Igrach>();
            for (int i = 0; i < igrachi.Count; i++)
            {
                if (igrachi[i].poeniVkupno > 0)
                {
                    igrachiVoIgra.Add(igrachi[i]);
                }
            }
            if (igrachiVoIgra.Count == 1)
            {
                MessageBox.Show("Pobednik e " + igrachiVoIgra[0].ime);
            }
            this.igrachi = igrachi;
            filenames = System.IO.Directory.GetFiles(@"Petta");
            Random rand = new Random();
            int file_index = rand.Next(0, filenames.Length);
            lines = System.IO.File.ReadAllLines(filenames[file_index]);
            odgovori1 = new string[4];
            odgovori2 = new string[4];
            odgovori3 = new string[4];
            odgovori4 = new string[4];
            kategorii = new string[4];
            prasanja1 = new string[4];
            prasanja2 = new string[4];
            prasanja3 = new string[4];
            prasanja4 = new string[4];
            for (int i = 0; i < 36; i++)
            {
                if (i % 9 == 0)
                    kategorii[i / 9] = lines[i];
                else if (i < 9 && i % 2 == 1)
                    prasanja1[(i - 1) / 2] = lines[i];
                else if (i < 9)
                    odgovori1[(i - 1) / 2] = lines[i];
                else if (i < 18 && i % 2 == 0)
                {
                    prasanja2[(i - 10) / 2] = lines[i];
                }
                else if (i < 18)
                {
                    odgovori2[(i - 10) / 2] = lines[i];
                }
                else if (i < 27 && i % 2 == 1)
                {
                    prasanja3[(i - 19) / 2] = lines[i];
                }
                else if (i < 27)
                {
                    odgovori3[(i - 19) / 2] = lines[i];
                }
                else if (i % 2 == 0)
                {
                    prasanja4[(i - 28) / 2] = lines[i];
                }
                else
                {
                    odgovori4[(i - 28) / 2] = lines[i];
                }
            }
            twowayshuffle(prasanja1, odgovori1);
            twowayshuffle(prasanja2, odgovori2);
            twowayshuffle(prasanja3, odgovori3);
            twowayshuffle(prasanja4, odgovori4);
            category1.Text = kategorii[0];
            category2.Text = kategorii[1];
            category3.Text = kategorii[2];
            category4.Text = kategorii[3];
            c1Index = 0;
            c2Index = 0;
            c3Index = 0;
            c4Index = 0;
            player1.Text = igrachiVoIgra[0].ime + " " + igrachiVoIgra[0].prezime;
            player2.Text = igrachiVoIgra[1].ime + " " + igrachiVoIgra[1].prezime;
            if (igrachiVoIgra.Count >= 3)
            {
                player3.Text = igrachiVoIgra[2].ime + " " + igrachiVoIgra[2].prezime;
                if (igrachiVoIgra.Count == 4)
                {
                    player4.Text = igrachiVoIgra[3].ime + " " + igrachiVoIgra[3].prezime;
                }
                else
                {
                    player4.Hide();
                    label4.Text = "";
                }
            }
            else
            {
                player3.Hide();
                label4.Text = "";
                player4.Hide();
                label3.Text = "";
            }
            int min = 100;
            int index = 0;
            for (int i = 0; i < igrachiVoIgra.Count; i++)
            {
                if (igrachiVoIgra[i].poeniVkupno < min)
                {
                    min = igrachiVoIgra[i].poeniVkupno;
                    index = i;
                }
            }
            maxturn = igrachiVoIgra.Count - 1;
            turn = index;
            if (turn == 0)
                turn = maxturn;
            else
            {
                turn--;
            }
            nextPlayer_Click(null, null);
        }


        private void leaderboard_Click(object sender, EventArgs e)
        {
            LeaderBoard form = new LeaderBoard(igrachi);
            form.Show();
        }

        private void Igra_5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 1)
                Application.Exit();
        }

        private void nextPlayer_Click(object sender, EventArgs e)
        {
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
            numericUpDown1.Value = 1;
            numericUpDown1.Maximum = igrachiVoIgra[turn].poeniVkupno;
            answer.ReadOnly = true;
            verify.Enabled = false;
            nextPlayer.Enabled = false;
            numericUpDown1.Enabled = true;
            question.Text = "";
            answer.Text = "";
            nextPlayer.Enabled = false;
            enableCategories();
            label1.Text = "" + igrachiVoIgra[0].poeniVkupno;
            label2.Text = "" + igrachiVoIgra[1].poeniVkupno;
            if(igrachiVoIgra.Count > 2)
            {
                label3.Text = "" + igrachiVoIgra[2].poeniVkupno;
                if (igrachiVoIgra.Count > 3)
                    label4.Text = "" + igrachiVoIgra[3].poeniVkupno;

            }
        }

        private void category1_Click(object sender, EventArgs e)
        {
            disableCategories();
            pointsRisked = (int)numericUpDown1.Value;
            numericUpDown1.Enabled = false;
            question.Text = prasanja1[c1Index++];
            answer.ReadOnly = false;
            verify.Enabled = true;
        }

        private void category2_Click(object sender, EventArgs e)
        {
            disableCategories();
            pointsRisked = (int)numericUpDown1.Value;
            numericUpDown1.Enabled = false;
            question.Text = prasanja1[c2Index++];
            answer.ReadOnly = false;
            verify.Enabled = true;
        }

        private void category3_Click(object sender, EventArgs e)
        {
            disableCategories();
            pointsRisked = (int)numericUpDown1.Value;
            numericUpDown1.Enabled = false;
            question.Text = prasanja1[c3Index++];
            answer.ReadOnly = false;
            verify.Enabled = true;
        }

        private void category4_Click(object sender, EventArgs e)
        {
            disableCategories();
            pointsRisked = (int)numericUpDown1.Value;
            numericUpDown1.Enabled = false;
            question.Text = prasanja1[c4Index++];
            answer.ReadOnly = false;
            verify.Enabled = true;
        }
    }
}
