using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseProject
{
    public class LanguageCheck
    {
        private string ruLang = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private string engLang = "abcdefghijklmnopqrstuvwxyz";
        public string checkResult;
        public LanguageCheck(string txt)
        {
            int ruLetters = 0, engLetters = 0;
            for (int i = 0; i < txt.Length; i++)
            {
                if (ruLang.Contains(char.ToLower(txt[i])))
                {
                    ruLetters++;
                }
                if (engLang.Contains(char.ToLower(txt[i])))
                {
                    engLetters++;
                }
            }
            if (ruLetters >= engLetters)
            {
                checkResult = ruLang;
            }
            else
            {
                checkResult = engLang;
            }

        }
    }
}
