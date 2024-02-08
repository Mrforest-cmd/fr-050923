using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptndecrypt
{
    public static class Safety
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static string Encrypt(string text, int shift)
        {
            string result = "";
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    int index = Alphabet.IndexOf(char.ToLowerInvariant(c));
                    int shiftedIndex = (index + shift) % Alphabet.Length;
                    char shiftedChar = Alphabet[shiftedIndex];
                    result += char.IsUpper(c) ? char.ToUpperInvariant(shiftedChar) : shiftedChar;
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        public static string Decrypt(string text, int shift)
        {
            string result = "";

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    int index = Alphabet.IndexOf(char.ToLowerInvariant(c));
                    int shiftedIndex = (index - shift + Alphabet.Length) % Alphabet.Length;
                    char shiftedChar = Alphabet[shiftedIndex];
                    result += char.IsUpper(c) ? char.ToUpperInvariant(shiftedChar) : shiftedChar;
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }
    }
}
