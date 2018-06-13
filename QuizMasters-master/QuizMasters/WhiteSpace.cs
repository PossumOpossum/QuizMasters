using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMasters
{
    public static class WhiteSpace
    {
        public static string FIX(string s)
        {
            return s.Replace('_', ' ');
        }
    }
}
