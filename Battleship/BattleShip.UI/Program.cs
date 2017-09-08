using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;


namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Player playerOne;
            Player playerTwo;

            ConsoleOutput.StartMenu();

            ConsoleInput.GetUserName();

            playerOne = new Player(ConsoleInput.PlayerOne, ConsoleOutput.Board());
            playerTwo = new Player(ConsoleInput.PlayerTwo, ConsoleOutput.Board());
            Console.ReadLine();
            
        }

      
    }
}
