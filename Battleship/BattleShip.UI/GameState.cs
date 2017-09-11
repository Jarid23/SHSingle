using BattleShip.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class GameState
    {
        public Player playerOne { get; }
        public Player playerTwo { get; }
        public bool IsXTurn { get; private set; } = true;

        public GameState(Player p1, Player p2, bool IsXTurn)
        {
            playerOne = p1;
            playerTwo = p2;
            IsXTurn = false; 
        }
    }
}
