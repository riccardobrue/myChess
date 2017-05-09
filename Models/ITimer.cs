using System;

namespace myChess.Models
{

    public interface ITimer
    {
        //properties
        TimeSpan TimeLeftPlayerBlack { get; }
        TimeSpan TimeLeftPlayerWhite { get; }
        Color CurrentPlayerTurn { get; set; }

        //methods
        void TurnOn();
        void TurnOff();
        void Start();
        void Reset();
        void Pause();
        void SwitchPlayerTurn();
        bool InPause { get; }

        //events
        event EventHandler<Color> TimeIsUp;


    }

}
