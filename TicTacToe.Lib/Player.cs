using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Lib
{
    public class Player
    {
        public Player(string name, String symbol)
        {
            this.Name = name;
            this.Symbol = symbol;
            this.PlayerType = PlayerType.Human;

        }
        public string Name { get; set; }
        public PlayerType PlayerType { get; set; }
        public string Symbol { get; set; }
        
        public virtual void MakeMove(Cell cell)
        {
            cell.Player = this;
            cell.State = CellState.Filled;
        }
    }
}
