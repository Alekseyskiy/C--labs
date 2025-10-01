using System;
using IPLabs.lab2.enums;

namespace IPLabs.lab2.model
{
    public class Player
    {
        private string _name;
        
        public string Name
        {
            get
            {
                if (_name.Length < 8)
                {
                    throw new ArgumentException("Name is too short");
                }

                return _name.Substring(0, 8);
            }

            private set
            {
                _name = value ?? throw new ArgumentException(nameof(value));
            }
        }

        public int? Position { get; protected set; }
        public PlayerState State { get; set; }
        public long DistanceTraveled { get; protected set; }

        public Player(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Position = null;
            State = PlayerState.NotInGame;
            DistanceTraveled = 0;
        }
        
        public void SetInitialPosition(int pos, int boardSize)
        {
            if (boardSize <= 0) throw new ArgumentException("boardSize must be positive");
            if (pos < 1 || pos > boardSize) throw new ArgumentOutOfRangeException(nameof(pos));
            Position = pos;
            State = PlayerState.Playing;
        }
        
        public int Move(int delta, int boardSize)
        {
            if (boardSize <= 0) throw new ArgumentException("boardSize must be positive");
            if (!Position.HasValue) throw new InvalidOperationException("Player not in game");

            DistanceTraveled += Math.Abs((long)delta);

            long baseIndex = (Position.Value - 1L) + delta;
            long mod = ((baseIndex % boardSize) + boardSize) % boardSize;
            int newPos = (int)(mod + 1);
            Position = newPos;
            return newPos;
        }
        
        public void MarkWinner() => State = PlayerState.Winner;
        public void MarkLoser() => State = PlayerState.Loser;

        public string PositionOrQuestion() => Position.HasValue ? Position.Value.ToString() : "??";

        public override string ToString()
        {
            return $"{Name}: pos={(Position.HasValue? Position.Value.ToString() : "??")}, state={State}, dist={DistanceTraveled}";
        }
    }
}