using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CBCmode
{
    class Encrypt
    {
        private static List<string> result = new List<string>(); //encryptionlist
        private static string key = "";
        public static List<string> Encryption(List<string> plainBinary, string keyBinary)
        {
            result.Clear();
            key = keyBinary;
            for (int i = 0; i < plainBinary.Count; i ++)
            {
                key = Enc(plainBinary[i], key);
                result.Add(key);
            }
            return result;
        }

        private static string Enc(string plainBinary, string keyBinary)
        {
            string xor = "";
            xor = string.Join(null, Enumerable.Zip(plainBinary, keyBinary, (a, b) => (Convert.ToByte(a) ^ Convert.ToByte(b)) == 0 ? '0' : '1'));
            return xor;
        }
    }
}
