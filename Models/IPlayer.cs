namespace myChess.Models
{
    public interface IPlayer
    {
        string Name { get; set; }
        int Score { get; set; }
        bool InTurn { get; set; }

    }
}