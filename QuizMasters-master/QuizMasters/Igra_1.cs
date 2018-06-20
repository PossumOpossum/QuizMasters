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
        public bool first_true { get; set; }
        public bool second_true { get; set; }
        public bool third_true { get; set; }
        public bool fourth_true { get; set; }
        public int secondsleft { get; set; }
        public int endcounter { get; set; }

        public Igra_1(List<Igrach> igrachi)
        {
            InitializeComponent();
            this.igrachi = igrachi;
            endcounter = 10;
            first_true = false;
            second_true = false;
            third_true = false;
            fourth_true = false;
            lines = System.IO.File.ReadAllLines(@"Prasanja_prva.txt");
            prasanja = new List<Prasanje_prva>();
            secondsleft = 15;
            progressBar1.Maximum = secondsleft;
            progressBar1.Value = secondsleft;
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
            prasanja.ListShuffle();
            timer = new Timer { Interval = 1000 };
            timer.Tick += TimerOnTick;
            igrach1Label.Text = igrachi[0].ime + " " + igrachi[0].prezime;
            igrach2Label.Text = igrachi[1].ime + " " + igrachi[1].prezime;
            igrach3Label.Text = "";
            igrach4Label.Text = "";
            if (igrachi.Count >= 3)
                igrach3Label.Text = igrachi[2].ime + " " + igrachi[2].prezime;
            else
                textBox3.Hide();
            if (igrachi.Count == 4)
                igrach4Label.Text = igrachi[3].ime + " " + igrachi[3].prezime;
            else
                textBox4.Hide();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            if (secondsleft > 0)
            {
                bool flag = true;
                foreach(Igrach i in igrachi)
                    if (!i.locked)
                    {
                        flag = false;
                        break;
                    }
                if(flag)
                    secondsleft = 0;
                else
                    secondsleft--;

                timeleftlabel.Text = secondsleft.ToString();
                progressBar1.Value = secondsleft;
            }
            else
            {
                timer.Stop();
                this.KeyPreview = false;
                next_button.Enabled = true;
                if (counter == endcounter)
                    next_button.Text = "Наредна Игра";
                if (first_true)
                    textBox1.BackColor = Color.Green;
                else
                    textBox1.BackColor = Color.Red;
                if (second_true)
                    textBox2.BackColor = Color.Green;
                else
                    textBox2.BackColor = Color.Red;
                if (third_true)
                    textBox3.BackColor = Color.Green;
                else
                    textBox3.BackColor = Color.Red;
                if (fourth_true)
                    textBox4.BackColor = Color.Green;
                else
                    textBox4.BackColor = Color.Red;

                first_true = false;
                second_true = false;
                third_true = false;
                fourth_true = false;

                String correct = prasanja[counter - 1].odgovori[3];
                if (button1.Text.Equals(correct))
                    button1.BackColor = Color.LawnGreen;
                if (button2.Text.Equals(correct))
                    button2.BackColor = Color.LawnGreen;
                if (button3.Text.Equals(correct))
                    button3.BackColor = Color.LawnGreen;
                if (button4.Text.Equals(correct))
                    button4.BackColor = Color.LawnGreen;
                //MessageBox.Show(igrachi[0].poeniVkupno.ToString());
                
            }
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            if (counter == endcounter)
            {//leaderboard
                Igra2 nova = new Igra2(igrachi,1, -1);
                nova.Show();
                this.Close();
                Upatsvo form = new Upatsvo("Втората игра од квизот е \"Aсоцијаци\". Целта на оваа игра е да се погоди конечниот одговор кој треба да се добие како асоцијација од 4те пододговори (А, Б, Ц, Д) кои се добиваат како асоцијација од соодветните полиња (пр. А1-А4 за А).\nПравилата на оваа игра се: На ред е играчот чиво име и презиме во горниот дел на прозорецот е обоено со зелена боја. Најпрво натпреварувачот треба да отвори едно од 16те полиња (А1-А4, Б1-Б4, В1-В4, Г1-Г4). Потоа натпреварувачот смее да одговори еден од четирите подоговори или конечниот одговор, доколку погоди еден од четирите пододговори смее да го одговори и конечниот одговор. Потегот на еден играч завршува со притискање на копчето \"Нареден играч\". На ред е играчот чиво име и презиме во горниот дел на прозорецот е обоено со зелена боја.\nВо оваа игра поени се доделуваат за секој точно одоговрен пододговор и конечен одговор според тоа колку полиња биле отворени пред да се погоди соодветниот одговор.\nКолона одговорена со едно отворено поле - 4 поени, со две - 3 поени, со три - 2 поени, со четири - 1 поен.\nКонечниот одговор со една отворена колона - 10 поени, со две - 8, со три - 6, со четири - 4.\nВо квизот се играат две асоцијации.");
                form.Show();
            }
           
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

            secondsleft = 15;
            timeleftlabel.Text = secondsleft.ToString();
            progressBar1.Value = secondsleft;

            textBox1.BackColor = Color.Gray;
            textBox2.BackColor = Color.Gray;
            textBox3.BackColor = Color.Gray;
            textBox4.BackColor = Color.Gray;
            
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            foreach (Igrach igrach in igrachi)
                {
                igrach.locked = false;
                }
            counter++;
            
            timer.Start();
            next_button.Enabled = false;
        }

        private void Igra_1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData.Equals(Keys.D1))
            {

                
                textBox1.BackColor = Color.Yellow;
                if (button1.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[0].locked && progressBar1.Value!=0)
                {
                    igrachi[0].poeniVkupno++;
                    
                    first_true = true;
                }
                igrachi[0].locked = true;
            }

            if (e.KeyData.Equals(Keys.D2))
            {
                
                textBox1.BackColor = Color.Yellow;
                if (button2.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[0].locked && progressBar1.Value != 0)
                { 
                    igrachi[0].poeniVkupno++;
                    
                    first_true = true;
                }
                igrachi[0].locked = true;
            }

            if (e.KeyData.Equals(Keys.D3))
            {
                
                textBox1.BackColor = Color.Yellow;
                if (button3.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[0].locked && progressBar1.Value != 0)
                {
                    igrachi[0].poeniVkupno++;
                    
                    first_true = true;
                }
                igrachi[0].locked = true;
            }

            if (e.KeyData.Equals(Keys.D4))
            {
                
                textBox1.BackColor = Color.Yellow;
                if (button4.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[0].locked && progressBar1.Value != 0)
                {
                    igrachi[0].poeniVkupno++;
                   
                    first_true = true;
                }
                igrachi[0].locked = true;
            }

        

            if (e.KeyData.Equals(Keys.X))
            {
                
                textBox2.BackColor = Color.Yellow;
                if (button1.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[1].locked && progressBar1.Value != 0)
                {
                    igrachi[1].poeniVkupno++;
                    
                    second_true = true;
                }
                igrachi[1].locked = true;
            }

            if (e.KeyData.Equals(Keys.C))
            {
                
                textBox2.BackColor = Color.Yellow;
                if (button2.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[1].locked && progressBar1.Value != 0)
                {
                    igrachi[1].poeniVkupno++;
                    
                    second_true = true;
                }
                igrachi[1].locked = true;
            }

            if (e.KeyData.Equals(Keys.V))
            {
                
                textBox2.BackColor = Color.Yellow;
                if (button3.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[1].locked && progressBar1.Value != 0)
                {
                    igrachi[1].poeniVkupno++;
                    
                    second_true = true;
                }
                igrachi[1].locked = true;
            }

            if (e.KeyData.Equals(Keys.B))
            {
                
                textBox2.BackColor = Color.Yellow;
                if (button4.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[1].locked && progressBar1.Value != 0)
                {
                    igrachi[1].poeniVkupno++;
                    
                    second_true = true;
                }
                igrachi[1].locked = true;
            }

            if (igrachi.Count >= 3)
            {
                if (e.KeyData.Equals(Keys.D7))
                {
                    
                    textBox3.BackColor = Color.Yellow;
                    if (button1.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[2].locked && progressBar1.Value != 0)
                    {
                        igrachi[2].poeniVkupno++;
                        
                        third_true = true;
                    }
                    igrachi[2].locked = true;
                }

                if (e.KeyData.Equals(Keys.D8))
                {
                    
                    textBox3.BackColor = Color.Yellow;
                    if (button2.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[2].locked && progressBar1.Value != 0)
                    {
                        igrachi[2].poeniVkupno++;
                        
                        third_true = true;
                    }
                    igrachi[2].locked = true;
                }

                if (e.KeyData.Equals(Keys.D9))
                {
                    
                    textBox3.BackColor = Color.Yellow;
                    if (button3.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[2].locked && progressBar1.Value != 0)
                    {
                        igrachi[2].poeniVkupno++;
                       
                        third_true = true;
                    }
                    igrachi[2].locked = true;
                }

                if (e.KeyData.Equals(Keys.D0))
                {
                    
                    textBox3.BackColor = Color.Yellow;
                    if (button4.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[2].locked && progressBar1.Value != 0)
                    {
                        igrachi[2].poeniVkupno++;
                        
                        third_true = true;
                    }
                    igrachi[2].locked = true;
                }
            }

            if (igrachi.Count == 4)
            {
                if (e.KeyData.Equals(Keys.N))
                {
                    
                    textBox4.BackColor = Color.Yellow;
                    if (button1.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[3].locked && progressBar1.Value != 0)
                    {
                        igrachi[3].poeniVkupno++;
                       
                        fourth_true = true;
                    }
                    igrachi[3].locked = true;
                }

                if (e.KeyData.Equals(Keys.M))
                {
                    
                    textBox4.BackColor = Color.Yellow;
                    if (button2.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[3].locked && progressBar1.Value != 0)
                    {
                        igrachi[3].poeniVkupno++;
                        
                        fourth_true = true;
                    }
                    igrachi[3].locked = true;
                }

                if (e.KeyData.Equals(Keys.Oemcomma))
                {
                    
                    textBox4.BackColor = Color.Yellow;
                    if (button3.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[3].locked && progressBar1.Value != 0)
                    {
                        igrachi[3].poeniVkupno++;
                        
                        fourth_true = true;
                    }
                    igrachi[3].locked = true;
                }

                if (e.KeyData.Equals(Keys.OemPeriod))
                {
                    
                    textBox4.BackColor = Color.Yellow;
                    if (button4.Text.Equals(prasanja[counter - 1].odgovori[3]) && !igrachi[3].locked && progressBar1.Value != 0)
                    {
                        igrachi[3].poeniVkupno++;
                       
                        fourth_true = true;
                    }
                    igrachi[3].locked = true;
                }
            }
        }

        private void Igra_1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 1)
                Application.Exit();
        }

        private void leaderboard_Click(object sender, EventArgs e)
        {
           LeaderBoard form = new LeaderBoard(igrachi);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Upatsvo form = new Upatsvo("Добредојдовте во Quiz Masters. Во првата игра натпреварувачите треба да одговорат на 10 прашања. За секое прашање има 4 понудени одговори (под А), Б), В), Г)). На секој од натпреварувачите му се доделени 4 копчиња на тастатурата со кои треба да го зададат својот одоговор:\n1) Натпреварувачот борј 1 одговорот на секое прашање може да го зададе со \"1\" за А), \"2\" за Б), \"3\" за В), \"4\" за Г).\n2) Натпреварувачот борј 2 одговорот на секое прашање може да го зададе со \"X\" за А), \"C\" за Б), \"V\" за В), \"B\" за Г).\n3) Натпреварувачот борј 3 одговорот на секое прашање може да го зададе со \"7\" за А), \"8\" за Б), \"9\" за В), \"0\" за г).\n4) Натпреварувачот борј 4 одговорот на секое прашање може да го зададе со \"N\" за А), \"M\" за Б), \",/<\" за В), \"./>\" за Г).\nЗа секое прашање натпреварувачите имаат 15 секунди да го дадат својот одговор на прашањето кое се наоѓа во горниот дел на прозорецот.\nСекој од натпреварувачите штом го даде својот одговор полето до неговото име и презиме ќе се обои во жолта боја. По истекувањето на 15те секунди на натпреварувачите кои го одоговориле точно прашањето до нивното име и презиме полето ќе се обои во зелена боја, доколку одоговорот е грешен полето до нивнотот име и презиме ќе се обои во црвена боја.\nЗа секој точен одговор на натпреварувачот му се додава 1 поен.");
            form.Show();
        }
    }
}
        

    
        
    

