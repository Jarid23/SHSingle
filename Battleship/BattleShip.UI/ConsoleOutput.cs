using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;



namespace BattleShip.UI
{
    class ConsoleOutput
    {
        public static void StartMenu()
        {
            Console.WriteLine("Welcome to Battleship");
            Console.WriteLine("Alright this is a two player game so lets get your names");
            Console.WriteLine("Press any key to continue");
        }
        //public string GetUserNames()
        //{
        //    string player1 = ConsoleInput.PlayerOne;
        //    string player2 = ConsoleInput.PlayerTwo;
        //    Console.WriteLine(player1);
        //    Console.WriteLine(player2);
        //    return player1 + player2;
        //}
        internal static Board Board()
        {
            Board board = new Board();
            for (int y = 1; y < 11; y++)
            {
                for (int x = 1; x <= 11; x++)
                {
                    Console.Write($"| ");
                    
                }
                Console.WriteLine("");
                Console.WriteLine("----------------------------");
                
            }
            return board;
        }

      

        public string BshipInput()
        {
            Console.WriteLine("Enter a coordinate to strike");
            return Console.ReadLine();
        }

        internal static void TooFar()
        {
            Console.WriteLine("You have gone too far, please pick a new coordinate!");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void GGOverlap()
        {
            Console.WriteLine("Good grief, you aren't supposed to run your ships into each other!");
            Console.WriteLine();
            Console.WriteLine("Pick a new coordinate... A good one this time");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void PlaceSuccess()
        {
            Console.WriteLine("Congratulations! You managed to keep your fleet afloat! Now don't mess the next one up..");
            Console.ReadLine();
            Console.Clear();
        }

        public string BshipOutput()
        {
            Console.WriteLine("");
            return null;
        }

    }
}
