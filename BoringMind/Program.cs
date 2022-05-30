using System;
using System.Collections.Generic;

namespace BoringMind
{
    
    class Program
    {
        static void Main(string[] args)
        {
            #region setup displays
            string titleLenght = @"    ___       ___       ___       ___       ___       ___       ___       ___       ___       ___   
";
            Console.Title = "B O R I N G M I N D";
            Console.WindowWidth = titleLenght.Length;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            #endregion

            // all structure methods are static
            // therefore there is no need to intialize 

            #region initializing
            Console.Clear();
            Assets.RainbowWritePrompt();

            Color[] computerCode = Logic.RNG_ComputerCode();
            bool hasWon = false;
            int numberofGuesses = 0;
            #endregion

            #region game loop
            do
            {
                if (numberofGuesses > 11)
                {
                    Console.WriteLine();
                    Console.WriteLine("You lost, you looser.");
                    Display.DisplayComputerControl(numberofGuesses, computerCode, true);
                    break;
                }
                numberofGuesses++;

                Color[] userGuesses = Logic.GuessCode();

                List<Color> comparedCodes = new List<Color>();

                Logic.CompareCodes(userGuesses, computerCode, out hasWon, out comparedCodes);


                //Display.DisplayComputerControl(numberofGuesses, computerCode);

                Display.DisplayGuesses(numberofGuesses, userGuesses);

                Display.DisplayHints(numberofGuesses, comparedCodes);

                Display.DisplayRemainingGuesses(numberofGuesses);


            } while (!hasWon);
            #endregion

            Console.WriteLine();

            if(hasWon)
            {
                Console.WriteLine("Yipee, you won!");
            }
            Console.ReadKey(true);

        }
    }
}
