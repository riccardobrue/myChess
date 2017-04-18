namespace myChess.Models
{

    public interface ITable
    {
        IPlayer Player1 { get; set; }
        IPlayer Player2 { get; set; }

        IChessBoard ChessBoard { get; set; }


    }

}
