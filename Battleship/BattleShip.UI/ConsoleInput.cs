using BattleShip.BLL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Ships;
using BattleShip.BLL;

namespace BattleShip.UI
{
    class ConsoleInput
    {

        public static Player PlayerOne { get; set; }
        public static Player PlayerTwo { get; set; }
        internal static void CreateBothPLayers()
        {
            Console.WriteLine("Enter your name first player : ");
            PlayerOne = new Player(Console.ReadLine(), ConsoleOutput.Board());

            Console.WriteLine("Enter your name second player : ");
            PlayerTwo = new Player(Console.ReadLine(), ConsoleOutput.Board());
        }
        internal static void CreatePlayerBoards()
        {
            var playerOneBoardSetup = new setupPlayerBoard(PlayerOne);
            var playerTwoBoardSetup = new setupPlayerBoard(PlayerTwo);
        }

        internal static Coordinate GetCoordinate(string PlayerName)
        {
            bool IsValidCoordinate = false;

            Coordinate validCoordinate = null;
            while (!IsValidCoordinate)
            {
                Console.Write($"{PlayerName}, please enter a coordinate : ");


                String userInput = Console.ReadLine();
                IsValidCoordinate = CoordinateTryParse(userInput, out validCoordinate);
            }
            return validCoordinate;
        }

        internal static ShipDirection GetDirection(string playerName, ShipType s)
        {
            throw new NotImplementedException();
        }

        public static bool CoordinateTryParse(string userInput, out Coordinate validCoordinate)
        {
            validCoordinate = null;
            if (userInput.Length > 1)
            {
                char yPart = userInput[0];
                String xPart = userInput.Substring(1);

                int ycol;
                int x;

                if (yPart >= 'a' && yPart <= 'j')
                {
                    if (int.TryParse(xPart, out x))
                    {
                        if (x >= 1 && x <= 10)
                        {
                            ycol = (yPart - 'a' + 1);
                            validCoordinate = new Coordinate(ycol, x);
                            return true;
                        }
                    }
                }
            }
            return false;


        }
    }
}
