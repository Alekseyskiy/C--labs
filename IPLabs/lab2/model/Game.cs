using System;
using System.Collections.Generic;

namespace IPLabs.lab2.model
{
    public class Game
    {
        public int BoardSize { get; }
        public Cat Cat { get; }
        public Mouse Mouse { get; }

        public int? CaughtAtCell { get; private set; }
        public bool IsOver { get; private set; }

        private readonly List<string> _printLines = new List<string>();
        public IEnumerable<string> PrintLines => _printLines.AsReadOnly();

        public Game(int boardSize)
        {
            if (boardSize <= 0 || boardSize > 10000) throw new ArgumentOutOfRangeException(nameof(boardSize));
            BoardSize = boardSize;
            Cat = new Cat();
            Mouse = new Mouse();
            CaughtAtCell = null;
            IsOver = false;
        }

        
    }
}