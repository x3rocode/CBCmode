using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBCmode
{
    class Decoder
    {
        public static string Decoding(List<string> binary)
        {
            //check padding
            string a = "00000000";
            if (a.Equals(binary[binary.Count - 1].Substring(8)))
            {
                binary[binary.Count - 1] = binary[binary.Count - 1].Substring(0, 8);
            }

            string result = "";
            string strbinary = "";
            List<string> binlist = new List<string>();


            foreach (string s in binary)
                strbinary += s;
            binlist = stringConverter(strbinary);

            char[] outBytes = new char[binlist.Count];
            for (int i = 0; i < binlist.Count; i++)
            {
                outBytes[i] = (char)Convert.ToInt32(binlist[i], 2);
                result += outBytes[i].ToString();
            }
            return result;
        }

        private static List<string> stringConverter(string str)
        {
            int startIdx = 0, endIdx = 0;
            List<string> result = new List<string>();

            for (int i = 0; i < (str.Length / 9) + 1; i++)
            {
                if (str.Length < startIdx + 9)
                    endIdx = str.Length - startIdx;
                else
                    endIdx = str.Substring(startIdx, 9).LastIndexOf("");

                result.Add(str.Substring(startIdx, endIdx));

                startIdx += endIdx;
            }

            return result;
        }
    }
}
