using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Lib.Builders;
using TicTacToe.Lib.Strategies;
using static System.Net.Mime.MediaTypeNames;

namespace TicTacToe.Lib.Controller
{
    public class GameController
    {
        public GameController() { }

        public Game CreateGame(int size, List<Player> players, List<IWinningStrategy> winningStrategies) 
        {

            return new GameBuilder()
            .SetSize(size)
            .SetPlayers(players)
            .SetWinningStrategy(winningStrategies)
            .Build();
        }

        public void MakeMove(Game game, int row, int column)
        {
            game.MakeMove(row, column);

        }
        public void Undo(Game game)
        {
            //game.Undo();

        }
        public void Display(Game game)
        {
            var cells = game.Board.Cells;
            int size = game.Board.Size;
            Console.WriteLine("\n-------Board---------\n");
            Console.Write("\t");
            for (int col = 0; col < size; col++)
            {
                string text = $" {col}.. ";
                Console.Write(text);
            }
            Console.WriteLine("\n");
            for (int row = 0; row < size; row++)
            {
                Console.Write(row + "..");
                Console.Write("\t|");
                for (int col = 0; col < size; col++)
                {
                    Cell cell = cells[row, col];
                    string text = cell.State == CellState.Filled ? $" {cell.Player.Symbol} " : $"   ";
                    Console.Write(text);
                    Console.Write("|");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n-------------------------\n");
        }
    }
}
