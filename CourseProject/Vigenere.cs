using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseProject
{
    public class Vigenere
    {
        public static string Encrypt(string str, string key)
        {
            string result = "";
            string alphabet = new LanguageCheck(str).checkResult;
            key = key.ToLower();
            int posStr, posKey, k = 0;
            foreach (char c in key)
            {
                if (!alphabet.Contains(c)) 
                {
                    MessageBox.Show("Uncorrected key!!!");
                    return null;
                }
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (k >= key.Length) 
                {
                    k = 0;
                }
                posStr = alphabet.IndexOf(char.ToLower(str[i]));
                if (posStr != -1)
                {
                    posKey = alphabet.IndexOf(key[k]);
                    k++;
                    if (posStr + posKey > alphabet.Length - 1)
                    { 
                        result += alphabet[posStr + posKey - alphabet.Length];
                    }
                    else 
                    { 
                        result += alphabet[posStr + posKey];
                    }
                }
                else 
                { 
                    result += str[i];
                }
            }
            return result;
        }
        public static string Decrypt(string str, string key)
        {
            string result = "";
            string alphabet = new LanguageCheck(str).checkResult;
            int posStr, posKey, k = 0;
            key = key.ToLower();
            foreach (char c in key)
            {
                if (!alphabet.Contains(c))
                {
                    MessageBox.Show("Key and text alphabets do not match!!!");
                    return null;
                }
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (k >= key.Length) 
                {
                    k = 0; 
                }
                posStr = alphabet.IndexOf(char.ToLower(str[i]));
                if (posStr != -1)
                {
                    posKey = alphabet.IndexOf(key[k]);
                    k++;

                    if (posStr - posKey < 0)
                    {
                        result += alphabet[posStr - posKey + alphabet.Length]; 
                    }
                    else 
                    { 
                        result += alphabet[posStr - posKey]; 
                    }
                }
                else 
                { 
                    result += str[i];
                }
            }
            return result;
        }
    }
}
