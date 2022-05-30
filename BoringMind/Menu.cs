using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringMind
{
    public struct Menu
    {
        // displays all colors in the enum Color and allows to navigate between
        public static void ColorSelector(int currentIndex)
        {
            //Color userColor;
            int colorIndex = 0;

            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                colorIndex++;
                if (colorIndex == currentIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("[");
                    Console.ResetColor();
                    Display.PrintColor(color);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("]");
                    Console.ResetColor();
                    Console.Write(@"    ");
                } else
                {
                    Console.ResetColor();
                    Display.PrintColor(color);
                    Console.Write(@"    ");
                }

                

            }

            //return userColor;
        }
    }
}
