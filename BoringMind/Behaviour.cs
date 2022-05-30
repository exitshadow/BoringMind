using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringMind
{
    public struct Behaviour
    {
        // randomly picks colors and check if there isn’t any color that repeats
        public BM_Color[] RNG_ComputerCode()
        {
            Random RNG = new Random();

            BM_Color[] computerColors = new BM_Color[4];

            for (int i = 0; i < computerColors.Length; i++)
            {
                computerColors[i] = (BM_Color)RNG.Next(1, 9);

                for (int j = 0; j < computerColors.Length; j++)
                {
                    if (j != i)
                    {
                        while(computerColors[i] == computerColors[j])
                        {
                            computerColors[i] = (BM_Color)RNG.Next(1, 9);
                            j = 0;
                        }
                    }
                }
            }
            return computerColors;
        }

        // create checking mechanism to compare the 2 lists
        // constraints are:
        //      - a red peg says there is a good color in the good place
        //      - a white peg says there is a good color in the wrong place
        //      (is this assigned to fit the pattern or just in the disorder?)
        //      => the order as follows: red pegs first, white pegs after.
        public BM_Color[] CompareCodes(BM_Color[] userGuess, BM_Color[] computerCode)
        {
            BM_Color[] comparedLists = { 0, 0, 0, 0 };
            int counter = 0;

            // this isn’t working, you win all the time
            for (int i = 0; i < userGuess.Length; i++)
            {

                for (int j = 0; j < userGuess.Length; j++)
                {
                    if(userGuess[i] == computerCode[i])
                    {
                        comparedLists[i] = BM_Color.Red;
                        counter++;
                    } else
                    {
                        comparedLists[i] = (BM_Color)(0);
                    }

                    if(userGuess[i] == computerCode[j])
                    {
                        comparedLists[i] = BM_Color.White;
                    }

                }

            }

            if (counter == 4)
            {
                Console.WriteLine("Eh, you won!");
            }
            return comparedLists;
        }

        // shows list of colors and asks user to select one
        // => introduce loops to display dots and select from them instead
        public BM_Color userColorPicker()
        {
            string str_userGuess;
            BM_Color userColor;

            do
            {
                Console.WriteLine("Pick a color from the list here:");
                foreach (BM_Color color in Enum.GetValues(typeof(BM_Color)))
                {
                    Display.PrintColor(color);
                }
                Console.WriteLine();

                str_userGuess = Console.ReadLine();

                if (!Enum.TryParse<BM_Color>(str_userGuess, out userColor))
                {
                    Console.WriteLine("Oh no, that’s not on the list. Doooo it agaaain!");
                    Console.WriteLine();
                }

            } while (!Enum.TryParse<BM_Color>(str_userGuess, out userColor));

            return userColor;
        }

        // asks user to pick in list using userColorPicker
        // then controls if color is already picked
        public BM_Color[] GuessCode()
        {
            BM_Color[] userGuess = new BM_Color[4];

            for (int i = 0; i < userGuess.Length; i++)
            {
                userGuess[i] = userColorPicker();
                for (int j = 0; j < userGuess.Length; j++)
                {
                    while (userGuess[i] == userGuess[j])
                    {
                        if (j == i) break;
                        j = 0;
                        Console.WriteLine("Oopsie, you already picked that one.");
                        Console.WriteLine();
                        userGuess[i] = userColorPicker();
                    }

                }

                Console.WriteLine("Ok!");
                Console.WriteLine();
            }

            return userGuess;
        }
    }
}
