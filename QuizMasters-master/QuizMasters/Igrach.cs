using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMasters
{
    public class Igrach
    {
        public String ime { get; set; }
        public bool locked { get; set; }
        public String prezime { get; set; }
        public int poeniVkupno { get; set; }
      
        public Igrach (String ime, String prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
            poeniVkupno = 0;
            
            locked = false;
        }
    }
}
