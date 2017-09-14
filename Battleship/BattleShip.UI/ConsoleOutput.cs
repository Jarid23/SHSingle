using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;



namespace BattleShip.UI
{
    public static class ConsoleOutput
    {
      
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

      

        public static string BshipInput()
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

        internal static void Overlap()
        {
            Console.WriteLine("The ships overlap");
            Console.WriteLine();
            Console.WriteLine("Pick a new coordinate, a valid one this time");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void PlaceSuccess()
        {
            Console.WriteLine("Ship placed successfully");
            Console.ReadLine();
            Console.Clear();
        }

        public static string BshipOutput()
        {
            Console.WriteLine("");
            return null;
        }

    }
}
