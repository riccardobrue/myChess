using System;
namespace myChess.Models
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public bool InTurn { get; set; }
    }
}