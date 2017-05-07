namespace myChess.Models
{
    public interface IPlayer
    {
        string Name { get; }
        int Score { get; set; }
        bool InTurn { get; set; }

    }
}