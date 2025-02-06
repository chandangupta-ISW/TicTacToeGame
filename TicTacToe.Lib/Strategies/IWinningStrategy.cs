﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Lib.Strategies
{
    public interface IWinningStrategy
    {
        public bool Check(Board board, Move move);
    }
}
