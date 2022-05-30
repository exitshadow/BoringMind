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
            Console.WriteLine();
            Console.SetCursorPosition(1, 15);
            Console.WriteLine("Pick a color from the list here:");
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
            Console.WriteLine();

            //return userColor;
        }

        public static Color ColorSelectorIterator()
        {

            int selectedIndex = 1;
            bool exitColors = false;

            do
            {

                Menu.ColorSelector(selectedIndex);
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    selectedIndex--;
                }
                
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    selectedIndex++;
                }

                if (keyPressed.Key == ConsoleKey.Enter)
                {
                    exitColors = true;
                }
                
                if (selectedIndex > 8)
                {
                    selectedIndex = 1;
                }
                else if (selectedIndex < 1)
                {
                    selectedIndex = 8;
                }

            } while (!exitColors);

            Console.WriteLine();
            // Console.WriteLine();
            return (Color)selectedIndex;
        }
    }
}
