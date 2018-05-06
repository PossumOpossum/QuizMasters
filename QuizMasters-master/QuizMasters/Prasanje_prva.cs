using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMasters
{
    public class Prasanje_prva
    {
        public String prasanje { get; set; }
        public String[] odgovori { get; set; }
        

        public Prasanje_prva(string prasanje)
        {
            this.prasanje = prasanje;
            odgovori = new String [4];
        }
    }
}
