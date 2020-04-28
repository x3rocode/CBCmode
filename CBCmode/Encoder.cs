using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBCmode
{
    class Encoder
    {

        public static List<string> Encoding(string plainText)
        {
            List<string> binaryCharCode = new List<string>();

            int i = 1;
            string s = "";
            foreach (char c in plainText)
            {
                s += Convert.ToString((int)c, 2).PadLeft(8, '0');
                if (i % 2 == 0)
                {
                    binaryCharCode.Add(s);
                    s = "";
                }
                if (i >= plainText.Length)  //padding check
                {
                    string padding = "";
                    if(s.Length >= 1 && s.Length < 16)
                    {
                        for (int j = 0; j < 16 - s.Length; j++)
                        {
                            padding += "0";
                        }
                        s += padding;
                        binaryCharCode.Add(s);
                    }
                }
                i++;
            }

            return binaryCharCode;
        }

    }
}
