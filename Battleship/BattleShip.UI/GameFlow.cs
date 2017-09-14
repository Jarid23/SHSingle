using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI;

namespace BattleShip.UI
{
    class GameFlow
    {
        public void RunGame()
        {
              Player PlayerOne = ConsoleInput.CreateSinglePLayers();
              Player PlayerTwo = ConsoleInput.CreateSinglePLayers();

            Board playerOneBoard = ConsoleInput.CreatePlayerBoards(PlayerOne.PlayerName);
            Board playerTwoBoard = ConsoleInput.CreatePlayerBoards(PlayerTwo.PlayerName);



            

           

            


            

            // ConsoleInput.GetCoordinate(ConsoleInput.PlayerOne.PlayerName);

            //setupPlayerBoard.BoardCreated(ConsoleInput.PlayerOne);


        }

    }
}

