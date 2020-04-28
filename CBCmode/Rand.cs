using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBCmode
{
    class Rand
    {
         public static string GetRandomBinary()
        {
            string binaryList = "";
            Random r = new Random();
            string s = "";
            for (int j = 0; j < 16; j++)
            {
                s += r.Next(0, 2);
            }
            binaryList += s;
            return binaryList;
        }
    }
}
