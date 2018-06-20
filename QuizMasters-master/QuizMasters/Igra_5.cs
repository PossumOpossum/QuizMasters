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
        private int currentCategory;
        private int activePlayers;
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
                category1.Enabled = true;
            if (c2Index < 4)
                category2.Enabled = true;
            if (c3Index < 4)
                category3.Enabled = true;
            if (c4Index < 4)
                category4.Enabled = true;
        }
        public void endGame()
        {
            Igrach pobednik = new Igrach("", "");
            pobednik.poeniVkupno = int.MinValue;
            if(igrachiVoIgra.Count == 1)
            {
                MessageBox.Show("Победник е " + igrachiVoIgra[0].ime + " " + igrachiVoIgra[0].prezime);
                this.Close();
            }
            else
            {
                int counter = 1;
                HashSet<Igrach> winners = new HashSet<Igrach>();
                for (int i = 0;i<igrachi.Count;i++)
                {
                    if(igrachi[i].poeniVkupno > pobednik.poeniVkupno)
                    {
                        pobednik = igrachi[i];
                        counter = 1;
                    }
                    else if (igrachi[i].poeniVkupno == pobednik.poeniVkupno)
                    {
                        counter++;
                        winners.Add(pobednik);
                        winners.Add(igrachi[i]);
                    }
                }
                if (counter == 1)
                    MessageBox.Show("Победник е " + pobednik.ime + " " + pobednik.prezime);
                else
                {
                    if (counter == 2)
                        MessageBox.Show("Победници се " + winners.ElementAt(0).ime + " " 
                            + winners.ElementAt(0).prezime + " и " + winners.ElementAt(1).ime + " "
                            + winners.ElementAt(1).prezime);
                    if (counter == 3)
                        MessageBox.Show("Победници се " + winners.ElementAt(0).ime + " "
                            + winners.ElementAt(0).prezime + " и " + winners.ElementAt(1).ime + " "
                            + winners.ElementAt(1).prezime + " и " + winners.ElementAt(2).ime + " "
                            + winners.ElementAt(2).prezime);
                    if (counter == 4)
                        MessageBox.Show("Победници се " + winners.ElementAt(0).ime + " "
                            + winners.ElementAt(0).prezime + " и " + winners.ElementAt(1).ime + " "
                            + winners.ElementAt(1).prezime + " и " + winners.ElementAt(2).ime + " "
                            + winners.ElementAt(2).prezime + " и " + winners.ElementAt(3).ime + " "
                            + winners.ElementAt(3).prezime);
                }
                this.Close();
            }
        }
        public Igra_5(List<Igrach> igrachi)
        {
            InitializeComponent();
            activePlayers = 0;
            pointsRisked = 0;
            igrachiVoIgra = new List<Igrach>();
            for (int i = 0; i < igrachi.Count; i++)
            {
                if (igrachi[i].poeniVkupno > 0)
                {
                    igrachiVoIgra.Add(igrachi[i]);
                    activePlayers++;
                }
            }
            if (igrachiVoIgra.Count == 1)
            {
                endGame();
            }
            if(igrachiVoIgra.Count == 0)
            {
                igrachiVoIgra = igrachi;
                endGame();
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
            ostanatiA.Text = (4 - c1Index).ToString();
            ostanatiB.Text = (4 - c2Index).ToString();
            ostanatiC.Text = (4 - c3Index).ToString();
            ostanatiD.Text = (4 - c4Index).ToString();
            player1.BackColor = Color.White;
            player2.BackColor = Color.White;
            player3.BackColor = Color.White;
            player4.BackColor = Color.White;
            if (c1Index > 3 && c2Index > 3 && c3Index > 3 && c4Index > 3)
                endGame();
            turn++;
            if (turn == maxturn + 1)
                turn = 0;
            while (igrachiVoIgra[turn].poeniVkupno <= 0)
            {
                turn++;
                if (turn == maxturn + 1)
                    turn = 0;
            }

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
            question.Text = prasanja1[c1Index];
            answer.ReadOnly = false;
            verify.Enabled = true;
            currentCategory = 1;
        }

        private void category2_Click(object sender, EventArgs e)
        {
            disableCategories();
            pointsRisked = (int)numericUpDown1.Value;
            numericUpDown1.Enabled = false;
            question.Text = prasanja2[c2Index];
            answer.ReadOnly = false;
            verify.Enabled = true;
            currentCategory = 2;
        }

        private void category3_Click(object sender, EventArgs e)
        {
            disableCategories();
            pointsRisked = (int)numericUpDown1.Value;
            numericUpDown1.Enabled = false;
            question.Text = prasanja3[c3Index];
            answer.ReadOnly = false;
            verify.Enabled = true;
            currentCategory = 3;
        }

        private void category4_Click(object sender, EventArgs e)
        {
            disableCategories();
            pointsRisked = (int)numericUpDown1.Value;
            numericUpDown1.Enabled = false;
            question.Text = prasanja4[c4Index];
            answer.ReadOnly = false;
            verify.Enabled = true;
            currentCategory = 4;
        }

        private void verify_Click(object sender, EventArgs e)
        {
            string[] currentAnswers;
            if(currentCategory == 1)
            {
                currentAnswers = odgovori1[c1Index++].Split(' ');
            }
            else if(currentCategory == 2)
            {
                currentAnswers = odgovori2[c2Index++].Split(' ');
            }
            else if(currentCategory == 3)
            {
                currentAnswers = odgovori3[c3Index++].Split(' '); ;
            }
            else
            {
                currentAnswers = odgovori4[c4Index++].Split(' '); ;
            }
            for (int i = 0; i < currentAnswers.Length; i++)
            {
                currentAnswers[i] = WhiteSpace.FIX(currentAnswers[i]);
            }
            if (currentAnswers.Contains(answer.Text.ToLower()))
            {
                igrachiVoIgra[turn].poeniVkupno += pointsRisked;
            }
            else
            {
                igrachiVoIgra[turn].poeniVkupno -= pointsRisked;
                if (igrachiVoIgra[turn].poeniVkupno <= 0)
                    activePlayers--;
                if (activePlayers == 1)
                    endGame();
            }
            answer.Text = currentAnswers[0];
            verify.Enabled = false;
            nextPlayer.Enabled = true;
            answer.ReadOnly = true;
            label1.Text = "" + igrachiVoIgra[0].poeniVkupno;
            label2.Text = "" + igrachiVoIgra[1].poeniVkupno;
            if(igrachiVoIgra.Count > 2)
            {
                label3.Text = "" + igrachiVoIgra[2].poeniVkupno;
                if (igrachiVoIgra.Count > 3)
                    label4.Text = "" + igrachiVoIgra[3].poeniVkupno;
            }
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
    }
}
