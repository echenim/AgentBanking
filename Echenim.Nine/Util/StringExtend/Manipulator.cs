using System;
using System.Collections.Generic;

namespace Echenim.Nine.Util.StringExtend
{
    public class Manipulator
    {
        private string _sentence;
        private string _divida;
        public Manipulator()
        {
            
        }
        public Manipulator(string sentence)
        {
            _sentence = sentence;
        }
        public Manipulator(string sentence,string divider)
        {
            _sentence = sentence;
            _divida = divider;
        }

        public List<string> WordWrap(string input, int maxCharacters)
        {
            var lines = new List<string>();

            if (!input.Contains(" ") && !input.Contains("\n"))
            {
                var start = 0;
                while (start < input.Length)
                {
                    lines.Add(input.Substring(start, Math.Min(maxCharacters, input.Length - start)));
                    start += maxCharacters;
                }
            }
            else
            {
                string[] paragraphs = input.Split('\n');

                foreach (string paragraph in paragraphs)
                {
                    string[] words = paragraph.Split(' ');

                    string line = "";
                    foreach (string word in words)
                    {
                        if ((line + word).Length > maxCharacters)
                        {
                            lines.Add(line.Trim());
                            line = "";
                        }

                        line += $"{word} ";
                    }

                    if (line.Length > 0)
                    {
                        lines.Add(line.Trim());
                    }
                }
            }
            return lines;
        }



    }
}
