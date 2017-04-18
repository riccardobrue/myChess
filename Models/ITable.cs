namespace myChess.Models
{

    public interface ITable
    {
        IPlayer player1 { get; set; }
        IPlayer player2 { get; set; }

        IChessBoard chessBoard { get; set; }


    }

}
