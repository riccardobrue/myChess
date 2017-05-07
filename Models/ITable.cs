using System.Collections.Generic;

namespace myChess.Models
{

    public interface ITable
    {
        void ReceivePlayers();
        Dictionary<Color, IPlayer> Players { get; }

        IPlayer Player1 { get; set; }
        IPlayer Player2 { get; set; }

        IChessBoard ChessBoard { get; set; }


    }

}
