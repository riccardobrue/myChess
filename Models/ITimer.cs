using System;

namespace myChess.Models
{

    public interface ITimer
    {
        TimeSpan TimeLeftPlayer1 { get; }
        TimeSpan TimeLeftPlayer2 { get; }

        PlayerTurn TurnChangerButton { get; set; }


    }

}
