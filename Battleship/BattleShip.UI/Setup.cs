using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.UI;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;



namespace BattleShip.UI
{
    class Setup
    {
        private bool WhoGoesFirst()
        {
            return RNG.CoinFlip();
        }
        private Board BoardCreated(string PlayerName)
        {

            Board toReturn = new Board();

            for (ShipType s = ShipType.Carrier; s >= ShipType.Destroyer; s--)
            {

                bool IsShipSpotValid = false;
                do
                {
                    PlaceShipRequest request = new PlaceShipRequest();
                    //request.Coordinate = BshipInput.GetCoordinate(PlayerName, s);
                   // request.Direction = BshipInput.GetDirection(PlayerName, s);
                    request.ShipType = s;

                    var result = toReturn.PlaceShip(request);

                    if (result == ShipPlacement.NotEnoughSpace)
                    {
                       // BshipOutput.TooFar();
                    }
                    if (result == ShipPlacement.Overlap)
                    {
                    //    BshipOutput.GGOverlap();
                    }
                    if (result == ShipPlacement.Ok)
                    {
                     //   BshipOutput.PlaceSuccess();
                        IsShipSpotValid = true;
                    }
                }
                while (!IsShipSpotValid);
            }
            return null;
        }
    }
}
