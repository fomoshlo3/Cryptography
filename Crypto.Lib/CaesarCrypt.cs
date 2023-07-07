using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Lib
{
    //note: Encrypts texts through padding defined by 1 letter which is represented by his Index in the used alphabet 
    public class CaesarCrypt
    {
        private char _key;
        private int _modulus = 26;

        //todo: set modulus by looking up the index of key and compare with used IO Translation Table
        public int Modulus
        { 
            get { return _modulus; }
            set { _modulus = value; }
        }

        public char Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public CaesarCrypt(string key)
        {
            if(key.Length == 1)
            {
                Key = SetKey(key);
            }
            else
            {
                throw new ArgumentException("Key needs to be a single sign or letter");
            }
        }

        public CaesarCrypt(char key)
        {
            Key = key;
        }

        //note: For Testing
        private char SetKey(string key)
        {
            return key[0];
        }

        public string Encrypt(string plaintext)
        {
            int padding = 0;
            string ciphertext = string.Empty;
            foreach(char c in plaintext)
            {
                padding = c + Key % Modulus;
                ciphertext += (char)padding;
            }
            return ciphertext;
        }
    }
}
