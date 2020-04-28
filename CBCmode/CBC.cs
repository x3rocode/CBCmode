using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBCmode
{
    class CBC
    {
        private static List<string> enResult = new List<string>(); //encryptionlist
        private static List<string> deResult = new List<string>(); //decryptionlist
        private static string key = "";
        private static string plain = "";
        public static List<string> Encryption(List<string> plainBinary, string keyBinary)
        {
            enResult.Clear();
            key = keyBinary;
            for (int i = 0; i < plainBinary.Count; i++)
            {
                key = Enc(plainBinary[i], key);
                enResult.Add(key);
            }
            return enResult;
        }

        private static string Enc(string plainBinary, string keyBinary)
        {
            string xor = "";
            xor = string.Join(null, Enumerable.Zip(plainBinary, keyBinary, (a, b) => (Convert.ToByte(a) ^ Convert.ToByte(b)) == 0 ? '0' : '1'));
            return xor;
        }



        public static List<string> Decryption(List<string> encBinary, string keyBinary)
        {
            deResult.Clear();

            deResult.Add(Dec(encBinary[0], keyBinary));

            for (int i = 0; i < encBinary.Count - 1; i++)
            {
                plain = Dec(encBinary[i], encBinary[i + 1]);
                deResult.Add(plain);
            }
            return deResult;
        }

        private static string Dec(string plainBinary, string keyBinary)
        {
            string xor = "";
            xor = string.Join(null, Enumerable.Zip(plainBinary, keyBinary, (a, b) => (Convert.ToByte(a) ^ Convert.ToByte(b)) == 0 ? '0' : '1'));
            return xor;
        }
    }
}
