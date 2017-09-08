using BattleShip.BLL;
using BattleShip.BLL.Requests;
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
        setupPlayerBoard(Player gamePlayer)
        {
            this.gamePlayer = gamePlayer;
        }
        private void setupPlayerGame()
        {
            Console.WriteLine(string.Format("Hey {0} setup your board!", this.gamePlayer.PlayerName));
            PlaceShipRequest newShipRequest = new PlaceShipRequest();
        }

    }
}
