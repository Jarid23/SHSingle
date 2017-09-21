using BattleShip.BLL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Ships;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public static class ConsoleInput
    {

        public static Player CreateSinglePLayers()
        {
            Console.WriteLine("Enter your name first player : ");
            return new Player(Console.ReadLine(), new Board ());

        }
        internal static Board CreatePlayerBoards(string playerOne)
        {
              return BoardCreated(playerOne);           
        }

        internal static Coordinate GetCoordinate(string PlayerName)
        {
            bool IsValidCoordinate = false;

            Coordinate validCoordinate = null;
            while (!IsValidCoordinate)
            {
                Console.Write($"{PlayerName}, please enter a coordinate (a-j, then 1-10) : ");


                String userInput = Console.ReadLine();
                IsValidCoordinate = CoordinateTryParse(userInput, out validCoordinate);
            }
            return validCoordinate;
        }

        internal static ShipDirection GetDirection(string playerName, ShipType s)
        {
            // throw new NotImplementedException();
            Console.Write($"{playerName}, please enter a ship direction (D for down, U for UP, L for left, R for right) : ");
            string requestedDirection = Console.ReadLine();
            switch (requestedDirection)
            {

                case "D":
                    return ShipDirection.Down;
                case "U":
                    return ShipDirection.Up;
                case "L":
                    return ShipDirection.Left;
                case "R":
                    return ShipDirection.Right;
                default:
                    return GetDirection(playerName, s);
                
            } }


         

        public static bool CoordinateTryParse(string userInput, out Coordinate outputCoord)
        {
            outputCoord = null;
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
                            outputCoord = new Coordinate(ycol, x);
                            return true;
                        }
                    }
                }
            }
            return false;


        }
        public static Board BoardCreated(string PlayerName)
        {

            Board toReturn = new Board();

            for (ShipType s = ShipType.Carrier; s >= ShipType.Destroyer; s--)
            {

                bool IsShipSpotValid = false;
                do
                {
                    PlaceShipRequest request = new PlaceShipRequest();
                    request.Coordinate = ConsoleInput.GetCoordinate(PlayerName);
                    request.Direction = ConsoleInput.GetDirection(PlayerName, s);
                    request.ShipType = s;

                    var result = toReturn.PlaceShip(request);

                    if (result == ShipPlacement.NotEnoughSpace)
                    {
                        ConsoleOutput.TooFar();
                    }
                    if (result == ShipPlacement.Overlap)
                    {
                        ConsoleOutput.Overlap();
                    }
                    if (result == ShipPlacement.Ok)
                    {
                        ConsoleOutput.PlaceSuccess();
                        IsShipSpotValid = true;
                    }
                }
                while (!IsShipSpotValid);
            }
            return toReturn;

        }
    }
}


