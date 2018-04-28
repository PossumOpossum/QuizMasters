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
    public partial class Igra_1 : Form
    {
        public List<Prasanje_prva> prasanja;
        public List<Igrach> igrachi { get; set; }
        public string[] lines { get; set; }
        public static Timer timer;
        static int counter;
        public int secondsleft { get; set; }
        public int brojIgrachi { get; set; }
        public Igra_1(List<Igrach> igrachi, int brojIgrachi)
        {
            InitializeComponent();
            this.igrachi = igrachi;
            this.brojIgrachi = brojIgrachi;
            lines = System.IO.File.ReadAllLines(@"Prasanja_prva.txt");
            prasanja = new List<Prasanje_prva>();
            secondsleft = 10;
            progressBar1.Maximum = 10;
            progressBar1.Value = 10;
            counter = 0;
            for(int i =0; i<lines.Length; i++)
            {
                if (i % 5 == 0)
                    prasanja.Add(new Prasanje_prva(lines[i]));
                if (i % 5 == 1)
                    prasanja[i / 5].odgovori[0] = lines[i];
                if (i % 5 == 2)
                    prasanja[i / 5].odgovori[1] = lines[i];
                if (i % 5 == 3)
                    prasanja[i / 5].odgovori[2] = lines[i];
                if (i % 5 == 4)
                    prasanja[i / 5].odgovori[3] = lines[i];
            }
            timer = new Timer { Interval = 1000 };
            timer.Tick += TimerOnTick;
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            if (secondsleft > 0)
            {
                secondsleft--;
                timeleftlabel.Text = secondsleft.ToString();
                progressBar1.Value = secondsleft;
            }
            else
            {
                timer.Stop();
                correct.Text = prasanja[counter - 1].odgovori[3];
                if (counter == 15)
                {//leaderboard

                    this.Close();
                }
            }
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            Prasanje.Text = prasanja[counter].prasanje;
            List<int> izminati = new List<int>();
            Random rand = new Random();

            int a = rand.Next(4);
            button1.Text = prasanja[counter].odgovori[a];
            izminati.Add(a);

            a = rand.Next(4);
            while(izminati.Contains(a))
                a = rand.Next(4);
            button2.Text = prasanja[counter].odgovori[a];
            izminati.Add(a);

            a = rand.Next(4);
            while (izminati.Contains(a))
                a = rand.Next(4);
            button3.Text = prasanja[counter].odgovori[a];
            izminati.Add(a);

            a = rand.Next(4);
            while (izminati.Contains(a))
                a = rand.Next(4);
            button4.Text = prasanja[counter].odgovori[a];
            izminati.Add(a);

            secondsleft = 10;
            timeleftlabel.Text = secondsleft.ToString();
            progressBar1.Value = secondsleft;

            counter++;
            correct.Clear();
            timer.Start();
        }

        private void Igra_1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue.Equals(Keys.D1))
            {
                if (button1.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[0].locked)
                    igrachi[0].poeniVkupno++;
                    igrachi[0].poeniPoIgra[0]++;
                    igrachi[0].locked = true;
            }

            if (e.KeyValue.Equals(Keys.D2))
            {
                if (button2.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[0].locked)
                    igrachi[0].poeniVkupno++;
                    igrachi[0].poeniPoIgra[0]++;
                    igrachi[0].locked = true;
            }

            if (e.KeyValue.Equals(Keys.D3))
            {
                if (button3.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[0].locked)
                    igrachi[0].poeniVkupno++;
                    igrachi[0].poeniPoIgra[0]++;
                    igrachi[0].locked = true;
            }

            if (e.KeyValue.Equals(Keys.D4))
            {
                if (button4.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[0].locked)
                    igrachi[0].poeniVkupno++;
                    igrachi[0].poeniPoIgra[0]++;
                    igrachi[0].locked = true;
            }

            if (e.KeyValue.Equals(Keys.Z))
            {
                if (button1.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[1].locked)
                    igrachi[1].poeniVkupno++;
                    igrachi[1].poeniPoIgra[0]++;
                    igrachi[1].locked = true;
            }

            if (e.KeyValue.Equals(Keys.X))
            {
                if (button2.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[1].locked)
                    igrachi[1].poeniVkupno++;
                    igrachi[1].poeniPoIgra[0]++;
                    igrachi[1].locked = true;
            }

            if (e.KeyValue.Equals(Keys.C))
            {
                if (button3.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[1].locked)
                    igrachi[1].poeniVkupno++;
                    igrachi[1].poeniPoIgra[0]++;
                    igrachi[1].locked = true;
            }

            if (e.KeyValue.Equals(Keys.V))
            {
                if (button4.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[1].locked)
                    igrachi[1].poeniVkupno++;
                    igrachi[1].poeniPoIgra[0]++;
                    igrachi[1].locked = true;
            }

            if (brojIgrachi >= 3)
            {
                if (e.KeyValue.Equals(Keys.D7))
                {
                    if (button1.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[2].locked)
                        igrachi[2].poeniVkupno++;
                    igrachi[2].poeniPoIgra[0]++;
                    igrachi[2].locked = true;
                }

                if (e.KeyValue.Equals(Keys.D8))
                {
                    if (button2.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[2].locked)
                        igrachi[2].poeniVkupno++;
                    igrachi[2].poeniPoIgra[0]++;
                    igrachi[2].locked = true;
                }

                if (e.KeyValue.Equals(Keys.D9))
                {
                    if (button3.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[2].locked)
                        igrachi[2].poeniVkupno++;
                    igrachi[2].poeniPoIgra[0]++;
                    igrachi[2].locked = true;
                }

                if (e.KeyValue.Equals(Keys.D0))
                {
                    if (button4.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[2].locked)
                        igrachi[2].poeniVkupno++;
                    igrachi[2].poeniPoIgra[0]++;
                    igrachi[2].locked = true;
                }
            }

            if (brojIgrachi == 4)
            {
                if (e.KeyValue.Equals(Keys.N))
                {
                    if (button1.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[3].locked)
                        igrachi[3].poeniVkupno++;
                    igrachi[3].poeniPoIgra[0]++;
                    igrachi[3].locked = true;
                }

                if (e.KeyValue.Equals(Keys.M))
                {
                    if (button2.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[3].locked)
                        igrachi[3].poeniVkupno++;
                    igrachi[3].poeniPoIgra[0]++;
                    igrachi[3].locked = true;
                }

                if (e.KeyValue.Equals(Keys.Oemcomma))
                {
                    if (button3.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[3].locked)
                        igrachi[3].poeniVkupno++;
                    igrachi[3].poeniPoIgra[0]++;
                    igrachi[3].locked = true;
                }

                if (e.KeyValue.Equals(Keys.OemPeriod))
                {
                    if (button4.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[3].locked)
                        igrachi[3].poeniVkupno++;
                    igrachi[3].poeniPoIgra[0]++;
                    igrachi[3].locked = true;
                }
            }
        }
    }
}
        

    
        
    

