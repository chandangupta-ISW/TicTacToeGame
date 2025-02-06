using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Lib
{
    public class Cell
    {
        public Cell(int row, int col) 
        {
            this.Row = row;
            this.Column = col;
            this.State = CellState.Empty;
        }
        public int Row { get; set; }
        public int Column { get; set; }
        public Player Player { get; set; }
        public CellState State { get; set; }
    }
}
