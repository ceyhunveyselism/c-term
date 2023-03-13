using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace c_term
{
    class _QF
    {
        public static string join(ArrayList al, string delimiter)
        {
            string str = "";
            bool space = delimiter == " ";
            for (int i = 0; i < al.Count; i++)
            {
                if (!space)
                    str += al[i] + (i != al.Count - 1 ? $"{delimiter} " : " ");
                else
                    str += al[i] + (i != al.Count - 1 ? " " : "");
            }
            return str;
        }
    }
}
