using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.UI;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFlow newGame = new GameFlow();

            newGame.RunGame();

            Console.ReadLine();
                                
        }     
    }
}
