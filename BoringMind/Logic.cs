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


        // shows list of colors and asks user to select one
        // => introduce loops to display dots and select from them instead
        public static Color userColorPicker()
        {
            string str_userGuess;
            Color userColor;

            do
            {
                #region SelectColors
                Menu.ColorSelectorIterator();

                Console.WriteLine();

                str_userGuess = Console.ReadLine();
                #endregion

                if (!Enum.TryParse<Color>(str_userGuess, out userColor))
                {
                    Console.WriteLine("Oh no, that’s not on the list. Doooo it agaaain!");
                    Console.WriteLine();
                }

            } while (!Enum.TryParse<Color>(str_userGuess, out userColor));

            return userColor;
        }

        // asks user to pick in list using userColorPicker
        // then controls if color is already picked
        public static Color[] GuessCode()
        {
            Color[] userGuesses = new Color[4];

            for (int i = 0; i < userGuesses.Length; i++)
            {
                userGuesses[i] = userColorPicker();
                for (int j = 0; j < userGuesses.Length; j++)
                {
                    while (userGuesses[i] == userGuesses[j])
                    {
                        if (j == i) break;
                        j = 0;
                        Console.WriteLine("Oopsie, you already picked that one.");
                        Console.WriteLine();
                        userGuesses[i] = userColorPicker();
                    }

                }

                Console.WriteLine("Ok!");
                Console.WriteLine();
                Console.SetCursorPosition(i * 3, 25);
                Display.PrintColor(userGuesses[i]);
            }

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
