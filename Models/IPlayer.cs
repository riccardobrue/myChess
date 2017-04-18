namespace myChess.Models
{
    public interface IPlayer
    {
        string name { get; set; }
        int score { get; set; }
        bool inTurn { get; set; }

    }
}