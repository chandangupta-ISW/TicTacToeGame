using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Lib.Strategies;

namespace TicTacToe.Lib.Builders
{
    public class GameBuilder
    {
        private int size;
        private List<Player> players;
        private List<IWinningStrategy> winningStrategies;

        public GameBuilder SetSize(int size) 
        { 
            this.size = size;
            return this;
        }
        public GameBuilder SetPlayers(List<Player> players)
        {
            this.players = players;
            return this;
        }
        public GameBuilder SetWinningStrategy(List<IWinningStrategy> winningStrategies)
        {
            this.winningStrategies = winningStrategies;
            return this;
        }

        public Game Build()
        {
            if(Validate())
            {
                return new Game(size, players, winningStrategies);
            }

            return null;
        }
        public bool Validate()
        {
            if(players.Count >= size)
            {
                return false;
            }
            return true;

        }

    }

}
