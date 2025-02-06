using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Lib.Strategies
{
    public class RowWinningStrategy : IWinningStrategy
    {
        List<Dictionary<Player, int>> RowPlayerCount;
        public RowWinningStrategy(int size, List<Player> players)
        {

            this.RowPlayerCount = new List<Dictionary<Player, int>>();
            for (int row = 0; row < size; row++)
            {
                Dictionary<Player, int> playerCount = new Dictionary<Player, int>();
                foreach (Player player in players)
                {
                    playerCount.Add(player, 0);
                }

                RowPlayerCount.Add(playerCount);
            }
        }
        public bool Check(Board board, Move move)
        {
            int row = move.Cell.Row;
            Player player = move.Player;

            Dictionary<Player, int> playerCount = RowPlayerCount[row];
            playerCount[player]++;

            return board.Size == playerCount[player];
        }
    }
}
