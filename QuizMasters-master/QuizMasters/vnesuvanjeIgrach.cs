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
    public partial class vnesuvanjeIgrach : Form
    {
        public List<Igrach> igrachi { get; set; }
        int numberOfPlayers;
        public vnesuvanjeIgrach(int numberOfPlayers)
        {
            InitializeComponent();
            igrachi = new List<Igrach>();
            this.numberOfPlayers = numberOfPlayers;
            if(numberOfPlayers == 2)
            {
                ime3.Hide();
                ime4.Hide();
                prezime3.Hide();
                prezime4.Hide();
                label5.Hide();
                label6.Hide();
            }

            if(numberOfPlayers == 3)
            {
                label6.Hide();
                ime4.Hide();
                prezime4.Hide();
            }
        }

        private void begin_button_Click(object sender, EventArgs e)
        {
            igrachi.Add(new Igrach(ime1.Text, prezime1.Text));
            igrachi.Add(new Igrach(ime2.Text, prezime2.Text));
            if(numberOfPlayers >= 3)
                igrachi.Add(new Igrach(ime3.Text, prezime3.Text));
            if(numberOfPlayers == 4)
                igrachi.Add(new Igrach(ime4.Text, prezime4.Text));

            Igra_1 forma = new Igra_1(igrachi);
            forma.Show();
            this.Close();
            Upatsvo form = new Upatsvo("Добредојдовте во Quiz Masters. Во првата игра натпреварувачите треба да одговорат на 10 прашања. За секое прашање има 4 понудени одговори (под А), Б), В), Г)). На секој од натпреварувачите му се доделени 4 копчиња на тастатурата со кои треба да го зададат својот одоговор:\n1) Натпреварувачот борј 1 одговорот на секое прашање може да го зададе со \"1\" за А), \"2\" за Б), \"3\" за В), \"4\" за Г).\n2) Натпреварувачот борј 2 одговорот на секое прашање може да го зададе со \"X\" за А), \"C\" за Б), \"V\" за В), \"B\" за Г).\n3) Натпреварувачот борј 3 одговорот на секое прашање може да го зададе со \"7\" за А), \"8\" за Б), \"9\" за В), \"0\" за г).\n4) Натпреварувачот борј 4 одговорот на секое прашање може да го зададе со \"N\" за А), \"M\" за Б), \",/<\" за В), \"./>\" за Г).\nЗа секое прашање натпреварувачите имаат 15 секунди да го дадат својот одговор на прашањето кое се наоѓа во горниот дел на прозорецот.\nСекој од натпреварувачите штом го даде својот одговор полето до неговото име и презиме ќе се обои во жолта боја. По истекувањето на 15те секунди на натпреварувачите кои го одоговориле точно прашањето до нивното име и презиме полето ќе се обои во зелена боја, доколку одоговорот е грешен полето до нивнотот име и презиме ќе се обои во црвена боја.\nЗа секој точен одговор на натпреварувачот му се додава 1 поен.");
            form.Show();
        }

        private void vnesuvanjeIgrach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 1)
                Application.Exit();
        }

        private void vnesuvanjeIgrach_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData.Equals(Keys.Enter))
            {
                begin_button_Click(null, null);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Start forma = new Start();
            forma.Show();
            this.Close();
        }
    }
}
