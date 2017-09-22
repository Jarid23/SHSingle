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
    public class Setup
    {
        public Player Player1 { get; }
        public Player Player2 { get; }
        public bool Player1Turn { get; set; }

        public Setup()
        {
         
            Player1 = ConsoleInput.CreateSinglePLayers();
           
            Player2 = ConsoleInput.CreateSinglePLayers();
            Player1.PlayerBoard = ConsoleInput.CreatePlayerBoards(Player1.PlayerName);
            Player2.PlayerBoard = ConsoleInput.CreatePlayerBoards(Player2.PlayerName);
            Player1Turn = WhoGoesFirst();

        } 

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
                    
                    request.Coordinate = ConsoleInput.GetCoordinate(PlayerName);
                    request.Direction = ConsoleInput.GetDirection(PlayerName,s);
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
            return null;
        }
    }
}
