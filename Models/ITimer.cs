using System;

namespace myChess.Models
{

    public interface ITimer
    {
        TimeSpan TimeLeftPlayer1 { get; set; }
        TimeSpan TimeLeftPlayer2 { get; set; }


    }

}
