using System.Numerics;
using TicTacToe.Lib;
using TicTacToe.Lib.Controller;
using TicTacToe.Lib.Strategies;

namespace TicTacToe.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 3;

            List<Player> players = new List<Player>
            {
                new Player("Pancha","O"),
                new Player("Gourav","X"),
            };
            List<IWinningStrategy> winningStrategies = new List<IWinningStrategy>
            {
               new RowWinningStrategy(size, players),
               new ColumnWinningStrategy(size, players),
               new DiagonalWinningStrategy(players)
            };

            GameController controller = new GameController();
            Game game = controller.CreateGame(size, players, winningStrategies);

            game.State = GameState.InProgress;

            while (game.State == GameState.InProgress)
            {
                Console.Clear();
                Console.WriteLine($"-----{game.CurrentPlayer.Name}'s Turn-----\n");
                controller.Display(game);

                Console.Write("\nPlease enter Row number: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("\nPlease enter Column number: ");
                int column = int.Parse(Console.ReadLine());

                controller.MakeMove(game, row, column);
            }

            Console.Clear();
            controller.Display(game);

            if (game.State == GameState.Drawn)
            {
                Console.WriteLine("-----Game has been drawn-----");
            }
            else
            {
                Player winner = game.CurrentPlayer;

                Console.WriteLine($"-----Congratulations!! Player {winner.Name} is the winner-----");
            }

            Console.ReadLine();
        }
    }
}
