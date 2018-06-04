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
    public partial class LeaderBoard : Form
    {
        public LeaderBoard(List<Igrach> igrachi)
        {
            InitializeComponent();
            igrachi = igrachi.OrderByDescending(x => x.poeniVkupno).ToList();
            foreach (Igrach igrach in igrachi)
                listView1.Items.Add(new ListViewItem(new[] { igrach.ime, igrach.prezime, igrach.poeniVkupno.ToString() }));
            name.Width = -1;
            surname.Width = -1;
            points.Width = -2;
        }
    }
}
