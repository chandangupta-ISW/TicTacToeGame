using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Lib.Strategies
{
    public class DiagonalWinningStrategy : IWinningStrategy
    {
        Dictionary<Player, int> leftDiagonalPlayerCount;
        Dictionary<Player, int> rightDiagonalPlayerCount;

        public DiagonalWinningStrategy(List<Player> players)
        {
            this.leftDiagonalPlayerCount = new Dictionary<Player, int>();
            foreach (Player player in players)
            {
                leftDiagonalPlayerCount.Add(player, 0);
            }

            this.rightDiagonalPlayerCount = new Dictionary<Player, int>();
            foreach (Player player in players)
            {
                rightDiagonalPlayerCount.Add(player, 0);
            }
        }
        public bool Check(Board board, Move move)
        {
            int size = board.Size;
            int row = move.Cell.Row;
            int col = move.Cell.Column;
            Player player = move.Player;

            if (row == col)
            {
                leftDiagonalPlayerCount[player]++;
            }
            if (row + col == size - 1)
            {
                rightDiagonalPlayerCount[player]++;
            }

            return leftDiagonalPlayerCount[player] == size || rightDiagonalPlayerCount[player] == size;
        }
    }
}
