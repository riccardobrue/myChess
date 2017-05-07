using System;
namespace myChess.Models
{
    public class Player : IPlayer
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
        public int Score { get; set; }
        public bool InTurn { get; set; }
    }
}