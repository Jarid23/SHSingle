using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class ConsoleInput
    {

        public static string PlayerOne = string.Empty;
        public static string PlayerTwo = string.Empty;
        internal static string GetUserName()
        {
            Console.WriteLine("Enter your name first player : ");
            PlayerOne =  Console.ReadLine();

            Console.WriteLine("Enter your name second player : ");
            PlayerTwo = Console.ReadLine();

            return Console.ReadLine();

        }

        internal static string GetUserCoordinates()
        {
            Console.WriteLine("Enter a coordinate to strike at : ");
            Console.ReadLine();

            return Console.ReadLine();
        }
        
    }
}
