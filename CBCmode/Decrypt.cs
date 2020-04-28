using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBCmode
{
    class Decrypt
    {
        private static List<string> result = new List<string>(); //encryptionlist
        private static string plain = "";
        public static List<string> Decryption(List<string> encBinary, string keyBinary)
        {
            result.Clear();

            result.Add(Dec(encBinary[0], keyBinary));

            for (int i = 0; i < encBinary.Count-1; i++)
            {
                plain = Dec(encBinary[i], encBinary[i+1]);
                result.Add(plain);
            }
            return result;
        }

        private static string Dec(string plainBinary, string keyBinary)
        {
            string xor = "";
            xor = string.Join(null, Enumerable.Zip(plainBinary, keyBinary, (a, b) => (Convert.ToByte(a) ^ Convert.ToByte(b)) == 0 ? '0' : '1'));
            return xor;
        }
    }
}
