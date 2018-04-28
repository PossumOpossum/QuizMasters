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
    public partial class Start : Form
    {
        
        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            vnesuvanjeIgrach forma = new vnesuvanjeIgrach(2);
            forma.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vnesuvanjeIgrach forma = new vnesuvanjeIgrach(3);
            forma.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            vnesuvanjeIgrach forma = new vnesuvanjeIgrach(4);
            this.Close();
            forma.Show();
            
        }
    }
}
