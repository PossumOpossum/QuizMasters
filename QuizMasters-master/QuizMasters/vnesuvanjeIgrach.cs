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
            MessageBox.Show("Upatstvo");
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
