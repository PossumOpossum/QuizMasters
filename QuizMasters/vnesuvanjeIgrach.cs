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
                ime3.ReadOnly = true;
                ime4.ReadOnly = true;
                prezime3.ReadOnly = true;
                prezime4.ReadOnly = true;
            }

            if(numberOfPlayers == 3)
            {
                ime4.ReadOnly = true;
                prezime4.ReadOnly = true;
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

            Igra_1 forma = new Igra_1(igrachi, numberOfPlayers);
            forma.Show();
            MessageBox.Show("Upatstvo");
        }
    }
}
