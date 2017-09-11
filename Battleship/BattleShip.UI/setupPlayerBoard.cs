using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class setupPlayerBoard
    {
        private readonly Player gamePlayer;
        public setupPlayerBoard(Player gamePlayer)
        {
            this.gamePlayer = gamePlayer;
        }

        public Board BoardCreated(string PlayerName)
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
                        ConsoleOutput.GGOverlap();
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
