﻿using System;
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
                    Console.WriteLine("You lost, you looser.");
                    break;
                }
                numberofGuesses++;

                Color[] userGuesses = Logic.GuessCode();

                Console.WriteLine();
                Console.WriteLine($"You picked:");

                foreach(Color color in userGuesses)
                {
                    Display.PrintColor(color);
                }

                Console.WriteLine();
                Console.WriteLine();

                List<Color> comparedCodes = new List<Color>();

                Logic.CompareCodes(userGuesses, computerCode, out hasWon, out comparedCodes);

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
                Console.WriteLine();
                Console.WriteLine($"You have {12 - numberofGuesses} guesses remaining.");

                // TODO
                // create interface for player to pick their colors
                // using the color enum
                // see if PickColors structure can be used


                // apply color displays

                // refine the whole user interface with pretty display

                #endregion

            } while (!hasWon);

            Console.WriteLine();

            if(hasWon)
            {
                Console.WriteLine("Yipee, you won!");
            }
            Console.ReadKey(true);

        }
    }
}
