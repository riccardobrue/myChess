using System;

namespace myChess.Models
{

    public interface ITimer
    {
        DateTime TimePlayer1 { get; set; }
        DateTime TimePlayer2 { get; set; }


    }

}
