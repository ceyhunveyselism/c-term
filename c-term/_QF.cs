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
        public static string join(List<string> al, string delimiter)
        {
            string str = "";
            for (int i = 0; i < al.Count; i++)
            {
                str += al[i] + ((i != al.Count - 1) ? delimiter : "");
            }
            return str;
        }
    }
}
