using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Lib.Strategies;

namespace TicTacToe.Lib
{
    public class Game
    {
        public Game()
        {
            this.Size = 3;
            this.Board = new Board(this.Size);
            this.Players = new List<Player>();
            this.Moves = new List<Move>();
            this.WinningStrategies = new List<IWinningStrategy>();
            this.State = GameState.NotStarted;
            this.CurrentPlayerIndex = 0;

        }
        public Game(int size, List<Player> players, List<IWinningStrategy> winningStrategies)
        {
            this.Size = size;
            this.Board = new Board(this.Size);
            this.Players = players;
            this.WinningStrategies = winningStrategies;
            this.Moves = new List<Move>();
            this.State = GameState.NotStarted;
            this.CurrentPlayerIndex = 0;
        }
        public int Size { get; set; }
        public Board Board { get; set; }
        public List<Player> Players { get; set; }
        public List<Move> Moves { get; set; }
        public List<IWinningStrategy> WinningStrategies { get; set; }
        public Player CurrentPlayer
        {
            get
            {
                return this.Players[this.CurrentPlayerIndex];
            }
        }
        public int CurrentPlayerIndex { get; set; }
        public
        Player Winner
        { get; set; }
        public GameState State { get; set; }

        public void MakeMove(int row, int column)
        {
            Cell proposedCell = this.Board.Cells[row, column];
            if(ValidateMove(proposedCell))
            {
                this.CurrentPlayer.MakeMove(proposedCell);
                Move proposeMove = new Move { Cell = proposedCell, Player = this.CurrentPlayer };
                this.Moves.Add(proposeMove);

                if(CheckIfWinner(proposeMove))
                {
                    this.State = GameState.Finished;
                    return;
                }
                if(CheckIfDraw())
                {
                    this.State = GameState.Drawn;
                }

                CurrentPlayerIndex = CurrentPlayerIndex + 1;
                CurrentPlayerIndex = CurrentPlayerIndex % (this.Size - 1); 
            }
        }
        private bool ValidateMove(Cell proposedCell)
        {
            return proposedCell.State == CellState.Empty;
        }
        private bool CheckIfWinner(Move move)
        {
            foreach (IWinningStrategy strategy in WinningStrategies)
            {
                if(strategy.Check(this.Board, move))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckIfDraw()
        {
            return this.Moves.Count >= (this.Size * this.Size);
        }
    }
}
