using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Lib
{
    public class Board
    {
        public Board(int size) 
        { 
            this.Size = size;
            this.Cells = new Cell[size, size];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Cells[row, col] = new Cell(row, col);
                    Cells[row, col].State = CellState.Empty;
                }
            }
        }
        public int Size {  get; set; }
        public Cell[,] Cells { get; set; }
    }
}
