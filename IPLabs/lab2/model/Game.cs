using System;
using System.Collections.Generic;
using System.Globalization;
using IPLabs.lab2.enums;

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
        
        
        
        public string ProcessCommandLine(string line)
        {
            if (IsOver) return null;
            if (string.IsNullOrWhiteSpace(line)) return null;
            var parts = line.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return null;
            string cmd = parts[0].ToUpperInvariant();

            if (cmd == "P")
            {
                var row = GeneratePrintRow();
                _printLines.Add(row);
                return row;
            }

            if (cmd != "M" && cmd != "C")
                throw new ArgumentException($"Unknown command: {cmd}");

            if (parts.Length < 2) throw new ArgumentException("Move command missing value");

            if (!int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
                throw new ArgumentException("Invalid integer in command");

            if (cmd == "M")
                ProcessMouseCommand(value);
            else
                ProcessCatCommand(value);
            return null;
        }

        private void ProcessMouseCommand(int value)
        {
            if (!Mouse.Position.HasValue)
            {
                Mouse.SetInitialPosition(NormalizeInitial(value), BoardSize);
            }
            else
            {
                Mouse.Move(value, BoardSize);
            }

            TrySetPlayingStateIfBothPresent();
            CheckCatch();
        }

        private void ProcessCatCommand(int value)
        {
            if (!Cat.Position.HasValue)
            {
                Cat.SetInitialPosition(NormalizeInitial(value), BoardSize);
            }
            else
            {
                Cat.Move(value, BoardSize);
            }
            TrySetPlayingStateIfBothPresent();
            CheckCatch();
        }

        private int NormalizeInitial(int pos)
        {
            if (pos >= 1 && pos <= BoardSize) return pos;
            long baseIndex = (pos - 1L);
            long mod = ((baseIndex % BoardSize) + BoardSize) % BoardSize;
            return (int)(mod + 1);
        }

        private void TrySetPlayingStateIfBothPresent()
        {
            if (Cat.Position.HasValue && Mouse.Position.HasValue)
            {
                Cat.State = PlayerState.Playing;
                Mouse.State = PlayerState.Playing;
                CheckCatch();
            }
        }

        private void CheckCatch()
        {
            if (!Cat.Position.HasValue || !Mouse.Position.HasValue) return;
            if (IsOver) return;

            if (Cat.Position.Value == Mouse.Position.Value)
            {
                IsOver = true;
                CaughtAtCell = Cat.Position.Value;
                Cat.MarkWinner();
                Mouse.MarkLoser();
            }
        }

        private string GeneratePrintRow()
        {
            string catPos = Cat.PositionOrQuestion();
            string mousePos = Mouse.PositionOrQuestion();
            string distance = (Cat.Position.HasValue && Mouse.Position.HasValue)
                ? ComputeDistance().ToString()
                : "??";

            return $"{catPos,6}{mousePos,8}{distance,10}";
        }

        private int ComputeDistance()
        {
            int diff = Math.Abs(Cat.Position.Value - Mouse.Position.Value);
            return Math.Min(diff, BoardSize - diff);
        }
        
        //print result
        public IEnumerable<string> GetFinalLines()
        {
            var lines = new List<string>();

            lines.Add("Cat and Mouse");
            lines.Add(string.Empty);
            lines.Add(string.Format("{0,6}{1,8}{2,10}", "Cat", "Mouse", "Distance"));
            lines.Add(new string('-', 24));

            foreach (var r in _printLines)
                lines.Add(r);

            lines.Add(new string('-', 24));
            lines.Add(string.Empty);
            lines.Add(string.Empty);

            lines.Add($"Cat distance traveled: {Cat.DistanceTraveled}");
            lines.Add($"Mouse distance traveled: {Mouse.DistanceTraveled}");
            lines.Add(string.Empty);

            if (IsOver && CaughtAtCell.HasValue)
                lines.Add($"Mouse caught at: {CaughtAtCell.Value}");
            else
                lines.Add("Mouse evaded Cat");

            return lines;
        }
    }
}