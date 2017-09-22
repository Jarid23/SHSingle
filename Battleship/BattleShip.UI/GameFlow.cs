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

            Setup gameSetup = new Setup();

            Player PlayerOne = gameSetup.Player1;
            Player PlayerTwo = gameSetup.Player2;

            Board playerOneBoard = PlayerOne.PlayerBoard;
            Board playerTwoBoard = PlayerTwo.PlayerBoard;

            bool determineFirst = gameSetup.Player1Turn;
            bool IsVictory = false;

            while (!IsVictory)
            {
                if(determineFirst)
                {
                    
                    ConsoleOutput.GetBoard(playerTwoBoard); //playerone board parameter
                    var fireShotResponse = playerTwoBoard.FireShot(ConsoleInput.GetCoordinate(PlayerOne.PlayerName));
                    Console.WriteLine("This is the shot status : {0}", fireShotResponse.ShotStatus);
                    Console.WriteLine("This is the ship impacted status : {0}", fireShotResponse.ShipImpacted);
                    
                    
                   IsVictory = fireShotResponse.ShotStatus == ShotStatus.Victory;
                }
                else
                {
                    
                    ConsoleOutput.GetBoard(playerOneBoard);
                    var fireShotResponse = playerOneBoard.FireShot(ConsoleInput.GetCoordinate(PlayerTwo.PlayerName));
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

