using System;
using System.Collections.Generic;

namespace BoringMind
{
    
    class Program
    {
        static void Main(string[] args)
        {
            #region setup displays
            string title = @"
    ___       ___       ___       ___       ___       ___       ___       ___       ___       ___   
   /\  \     /\  \     /\  \     /\  \     /\__\     /\  \     /\__\     /\  \     /\__\     /\  \  
  /::\  \   /::\  \   /::\  \   _\:\  \   /:| _|_   /::\  \   /::L_L_   _\:\  \   /:| _|_   /::\  \ 
 /::\:\__\ /:/\:\__\ /::\:\__\ /\/::\__\ /::|/\__\ /:/\:\__\ /:/L:\__\ /\/::\__\ /::|/\__\ /:/\:\__\
 \:\::/  / \:\/:/  / \;:::/  / \::/\/__/ \/|::/  / \:\:\/__/ \/_/:/  / \::/\/__/ \/|::/  / \:\/:/  /
  \::/  /   \::/  /   |:\/__/   \:\__\     |:/  /   \::/  /    /:/  /   \:\__\     |:/  /   \::/  / 
   \/__/     \/__/     \|__|     \/__/     \/__/     \/__/     \/__/     \/__/     \/__/     \/__/  

";
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
            Display.RainbowTitleWrite(title);

            Color[] computerCode = Logic.RNG_ComputerCode();
            bool hasWon = false;
            #endregion

            #region game loop
            do
            {

                Color[] userGuesses = Logic.GuessCode();

                Console.WriteLine("Good, you did it all! :clappingkitty:");
                Console.WriteLine($"You picked:");

                foreach(Color color in userGuesses)
                {
                    Display.PrintColor(color);
                }

                Console.WriteLine();
                Console.WriteLine();

                List<Color> comparedCodes = Logic.CompareCodes(userGuesses, computerCode);

                Console.WriteLine("Computer picked:");
                foreach(Color color in computerCode)
                {
                    Display.PrintColor(color);
                }

                Console.WriteLine();
                Console.WriteLine("Hints:");
                foreach(Color color in comparedCodes)
                {
                    Display.PrintColor(color);
                }

                Console.WriteLine();

                // create interface for player to pick their colors
                // using the color enum
                // see if PickColors structure can be used


                // apply color displays

                // refine the whole user interface with pretty display
                #endregion

            } while (!hasWon);
            
            Console.ReadKey(true);

        }
    }
}
