using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Lib.Strategies
{
    public class EasyBotPlayingStrategy : IBotPlayingStrategy
    {
        Board board;
        public EasyBotPlayingStrategy(Board board)
        {
            this.board = board;
        }
        public Cell GetProposedCell()
        {
            foreach (Cell cell in board.Cells)
            {
                if (cell.State == CellState.Empty)
                {
                    return cell;
                }
            }

            return null;
        }
    }
}
