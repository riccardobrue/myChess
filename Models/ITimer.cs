using System;

namespace myChess.Models
{

    public interface ITimer
    {
        //properties
        TimeSpan TimeLeftPlayer1 { get; }
        TimeSpan TimeLeftPlayer2 { get; }
        PlayerTurn CurrentPlayerTurn { get; set; }

        //methods
        void TurnOn();
        void TurnOff();
        void Start();
        void Reset();
        void Pause();
        void SwitchPlayerTurn();

        //events
        event EventHandler TimeIsUp;


    }

}
