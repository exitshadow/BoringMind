using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringMind
{
    public struct Logic
    {
        // randomly picks colors and check if there isn’t any color that repeats
        public static Color[] RNG_ComputerCode()
        {
            Random RNG = new Random();

            Color[] computerColors = new Color[4];

            for (int i = 0; i < computerColors.Length; i++)
            {
                computerColors[i] = (Color)RNG.Next(1, 9);

                for (int j = 0; j < computerColors.Length; j++)
                {
                    if (j != i)
                    {
                        while (computerColors[i] == computerColors[j])
                        {
                            computerColors[i] = (Color)RNG.Next(1, 9);
                            j = 0;
                        }
                    }
                }
            }
            return computerColors;
        }

        // asks user to pick in list using userColorPicker
        // then controls if color is already picked
        public static Color[] GuessCode()
        {
            Color[] userGuesses = new Color[4];

            for (int i = 0; i < userGuesses.Length; i++)
            {
                userGuesses[i] = Menu.ColorSelectorIterator();
                for (int j = 0; j < userGuesses.Length; j++)
                {
                    while (userGuesses[i] == userGuesses[j])
                    {
                        if (j == i) break;
                        j = 0;

                        Console.SetCursorPosition(0, 18);
                        Console.WriteLine("                                    ");
                        Console.SetCursorPosition(0, 18);
                        Console.WriteLine("Oopsie, you already picked that one.");
                        Console.WriteLine();

                        userGuesses[i] = Menu.ColorSelectorIterator();
                    }
                }

                Console.SetCursorPosition(0, 18);
                Console.WriteLine("                                    ");
                Console.SetCursorPosition(0, 18);
                Console.WriteLine("Ok!");
                Console.WriteLine();

                Console.WriteLine("Current pick:");
                Console.SetCursorPosition(i * 3, 21);
                Console.WriteLine("                           ");
                Console.SetCursorPosition(i * 3, 21);
                Display.PrintColor(userGuesses[i]);

            }

            Console.SetCursorPosition(0, 21);
            Console.WriteLine("                           ");
            
            return userGuesses;
        }

        // create checking mechanism to compare the 2 lists
        // constraints are:
        //      - a red peg says there is a good color in the good place
        //      - a white peg says there is a good color in the wrong place
        //      (is this assigned to fit the pattern or just in the disorder?)
        //      => the order as follows: red pegs first, white pegs after.
        public static void CompareCodes(Color[] userGuesses, Color[] computerCode, out bool hasWon, out List<Color> comparisons)
        {
            hasWon = false;
            comparisons = new List<Color>();
            comparisons.Clear();
            int counter = 0;

            for (int i = 0; i < userGuesses.Length; i++)
            {
                for (int j = 0; j < userGuesses.Length; j++)
                {
                    if(userGuesses[i] == computerCode[j])
                    {
                        if (i == j)
                        {
                            // it isn’t working when the index is 0 0
                            // yes it’s working? not understanding this shit!!
                            comparisons.Add(Color.Red);
                            counter++;
                        } else
                        {
                            comparisons.Add(Color.White);
                        }
                    }
                }
            }

            if (counter == 4)
            {
                hasWon = true;
            }
        }
    }
}
