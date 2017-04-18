using System;

namespace myChess.Models
{
    public class Timer : ITimer
    {
        //private constants
        private const int InitialTimeInMins = 5;

        //private variables
        private PlayerTurn playerTurn = PlayerTurn.Player1Turn;
        private DateTime startingTime;
        private TimeSpan timeLeftPlayer1;
        private TimeSpan timeLeftPlayer2;

        //public variables
        public TimeSpan TimeLeftPlayer1
        {
            get
            {
                timeLeftPlayer1 = TimeSpan.FromMinutes(InitialTimeInMins) - (DateTime.Now - startingTime);
                return timeLeftPlayer1;
            }
            private set
            {
                timeLeftPlayer1 = value;
            }
        }

        public TimeSpan TimeLeftPlayer2
        {
            get
            {
                timeLeftPlayer2 = TimeSpan.FromMinutes(InitialTimeInMins) - (DateTime.Now - startingTime);
                return timeLeftPlayer2;
            }
            private set
            {
                timeLeftPlayer2 = value;
            }
        }



        public PlayerTurn TurnChangerButton
        {
            get
            {
                return playerTurn;
            }
            set
            {
                playerTurn = value;
            }
        }

        //public methods

        public void TurnOn()
        {
            Reset();
        }
        public void TurnOff()
        {
            throw new NotImplementedException();
        }
        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            startingTime = DateTime.Now;
        }

        public void Reset()
        {
            TimeLeftPlayer1 = TimeSpan.FromMinutes(InitialTimeInMins);
            TimeLeftPlayer2 = TimeSpan.FromMinutes(InitialTimeInMins);
        }


        //public events
        public event EventHandler TimeIsUp;
    }
}