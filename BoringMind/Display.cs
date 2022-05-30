using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringMind
{
    // the essence of this boring game.
    public enum BM_Color { White=1, Red, Green, Blue, Yellow, Cyan, Pink, Gray};

    // stale tentatives to write the ascii title letter per letter
    // but the verbatim fucks everything up
    struct AsciiShitLeftThereu
    {
        public string[,] AsciiLettersParsing(string asciiTitle, int letterCount)
        {
            // returns bidimensional string[]
            // function that parses a set of ASCII display letterings into separate letters in arrays of separate characters
            // assuming we know (you can count...) the dimensions of each letters and the number of letters

            // splits the string into several lines with line jump, sent back as an array
            string[] asciiTitleLines = asciiTitle.Split("\n");
            // in fact we can deduce the letterHeight with the length of asciiTitleLines!
            int letterHeight = asciiTitleLines.Length;

            // split the string into bits of arrays
            int letterWidth = asciiTitleLines[0].Length / letterCount; // any line does it

            // now what we’ll have is like
            // 12 lines split across an array, sortable by indexes of asciiTitleLines
            // a second dimension of 9 rows on each line, encapsulated each as an array
            // so what we want is to consider that every line is an array in itself and not a string anymore
            // and we have to prepare the static data that will receive the strings
            string[,] decomposedTitle = new string[letterCount, letterHeight];

            foreach (string line in asciiTitleLines)
            {
                int start = 0;
                int end = letterWidth;
                int x = 0;
                int y = 0;
                string popString = line.Substring(start, end);

            }

            // stop being verbatim at this stage and add escape characters (but not before otherwise length would be compromised)

            return decomposedTitle;
        }
        public string[] RemoveVerbatimJunk(string[] asciiLetters)
        {
            string[] cleanletters = asciiLetters;
            foreach (string letter in cleanletters)
            {
                letter.Replace(@"\r", "");
            }
            return cleanletters;
        }
    }

    // all methods useful to display cool stuff in neat formatting
    public struct Display
    {
        public int displayWidth;
        public int displayHeight;

        // writes the ASCII title with rainbowed lines
        public void RainbowTitleWrite(string asciiTitle)
        {
            //bmColorList[] rainbows =  { bmColorList.Yellow, bmColorList.Red, bmColorList.Pink, bmColorList.Blue, bmColorList.Cyan, bmColorList.Green };
            string[] rainbowLines = asciiTitle.Split("\n");
            for (int i = 0; i < rainbowLines.Length; i++)
            {
                Console.ForegroundColor = (ConsoleColor)((i % 12) +1);
                Console.WriteLine(rainbowLines[i]);
            }
            Console.ResetColor();
        }

        // prints the color dots!
        public static void PrintColor(BM_Color args)
        {
            switch (args)
            {
                case BM_Color.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case BM_Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case BM_Color.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case BM_Color.Blue:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case BM_Color.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case BM_Color.Cyan:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case BM_Color.Pink:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case BM_Color.Gray:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
            Console.Write(" ● ");
            Console.ResetColor();
        }
    }

}
