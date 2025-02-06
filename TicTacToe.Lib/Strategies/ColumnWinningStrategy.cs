using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Lib.Strategies
{
    public class ColumnWinningStrategy : IWinningStrategy
    {

        List<Dictionary<Player, int>> columnPlayerCount;
        public ColumnWinningStrategy(int size, List<Player> players)
        {

            this.columnPlayerCount = new List<Dictionary<Player, int>>();
            for (int col = 0; col < size; col++)
            {
                Dictionary<Player, int> playerCount = new Dictionary<Player, int>();
                foreach (Player player in players)
                {
                    playerCount.Add(player, 0);
                }

                columnPlayerCount.Add(playerCount);
            }
        }
        public bool Check(Board board, Move move)
        {
            int column = move.Cell.Column;
            Player player = move.Player;

            Dictionary<Player, int> playerCount = columnPlayerCount[column];
            playerCount[player]++;

            return board.Size == playerCount[player];
        }
     
    
    }
}
