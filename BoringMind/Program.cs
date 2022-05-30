using System;

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

            #region setup structures
            Behaviour Behaviour = new Behaviour();
            Display Display = new Display();
            #endregion

            #region initializing
            Console.Clear();
            Display.RainbowTitleWrite(title);

            BM_Color[] computerCode = Behaviour.RNG_ComputerCode();
            #endregion

            #region game loop
            BM_Color[] userGuess = Behaviour.GuessCode();
            Console.WriteLine("Good, you did it all! :clappingkitty:");
            Console.WriteLine($"You picked:");

            foreach(BM_Color color in userGuess)
            {
                Display.PrintColor(color);
            }

            Console.WriteLine();
            Console.WriteLine();

            BM_Color[] comparedCodes = Behaviour.CompareCodes(userGuess, computerCode);
            Console.WriteLine("Computer picked:");
            foreach(BM_Color color in computerCode)
            {
                Display.PrintColor(color);
            }

            Console.WriteLine();
            Console.WriteLine("Hints:");
            foreach(BM_Color color in comparedCodes)
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

            Console.ReadKey(true);

        }
    }
}
