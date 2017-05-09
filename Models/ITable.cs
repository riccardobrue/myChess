using System;
using System.Collections.Generic;

namespace myChess.Models
{

    public interface ITable
    {
        void ReceivePlayers(string nameWhitePlayer, string nameBlackPlayer);
        Dictionary<Color, IPlayer> Players { get; }
        void StartMatch();
        IChessBoard ChessBoard { get; }
        ITimer Timer { get; }
        INotes Notes { get; }

        void AddMovement(string movement);
        event EventHandler<Color> Victory;
        
        void EndMatch();

    }

}
