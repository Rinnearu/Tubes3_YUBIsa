using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tubes3_YUBIsa
{
    internal class RegexPatternCreator
    {
        public static string GetPattern(string name)
        {
            StringBuilder regexBuilder = new();
            regexBuilder.Append('^');

            bool wordStart = true;

            foreach (char currentChar in name)
            {
                if (currentChar == ' ')
                {
                    regexBuilder.Append(@"\s");
                    wordStart = true;
                }
                else
                {
                    regexBuilder.Append(TransformCharacter(currentChar, wordStart));
                    wordStart = false;
                }
            }

            return regexBuilder.ToString();
        }
        static string TransformCharacter(char ch, bool isFirstChar)
        {
            switch (char.ToLower(ch))
            {
                case 'a': return "[Aa4]?";
                case 'e': return "[Ee3]?";
                case 'i': return "[Ii1]?";
                case 'o': return "[Oo0]?";
                case 'u': return "[Uu]?";
                case 'z': return "[Zz2]?";
                case 'g': return "[Gg69]";
                case 's': return "[Ss5]";
                default: return char.IsLetter(ch) ? $"[{char.ToUpper(ch)}{char.ToLower(ch)}]" : Regex.Escape(ch.ToString());
            }
        }
    }
}
