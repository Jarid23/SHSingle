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

            bool determineFirst = RNG.CoinFlip();
            bool IsVictory = false;

            while (!IsVictory)
            {
                if(determineFirst)
                {
                    
                    ConsoleOutput.GetBoard(playerOneBoard); //playerone board parameter
                    var fireShotResponse = playerOneBoard.FireShot(ConsoleInput.GetCoordinate(PlayerOne.PlayerName));
                    Console.WriteLine("This is the shot status : {0}", fireShotResponse.ShotStatus);
                    Console.WriteLine("This is the ship impacted status : {0}", fireShotResponse.ShipImpacted);
                    
                    
                   IsVictory = fireShotResponse.ShotStatus == ShotStatus.Victory;
                }
                else
                {
                    
                    ConsoleOutput.GetBoard(playerTwoBoard);
                    var fireShotResponse = playerTwoBoard.FireShot(ConsoleInput.GetCoordinate(PlayerTwo.PlayerName));
                    Console.WriteLine("This is the shot status : {0}",fireShotResponse.ShotStatus);
                    Console.WriteLine("This is the ship impacted status : {0}",fireShotResponse.ShipImpacted);
                    IsVictory = fireShotResponse.ShotStatus == ShotStatus.Victory;
                }
                determineFirst = !determineFirst;
            }
           

           // GameState thisGame = new GameState(PlayerOne, PlayerTwo, determineFirst);
           

        }

    }
}

