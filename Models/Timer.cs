using System;

namespace myChess.Models
{
    public class Timer : ITimer
    {
        //private constants
        public const int initialDefaultTime = 5;


        //private variables
        private TimeSpan initialTime;
        private System.Threading.Timer sysTimer;
        private PlayerTurn playerTurn;
        private DateTime startingTime;
        private TimeSpan timeLeftPlayer1;
        private TimeSpan timeLeftPlayer2;
        private bool paused, turnedOn;

        //constructor
        public Timer() : this(TimeSpan.FromMinutes(initialDefaultTime)) { }
        public Timer(TimeSpan initialTime)
        {
            this.initialTime = initialTime;
            sysTimer = new System.Threading.Timer(
                checkTimeLeft,
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(1));
        }

        private void checkTimeLeft(object state)
        {
            if (TimeLeftPlayer1 <= TimeSpan.Zero ||
            TimeLeftPlayer2 <= TimeSpan.Zero)
            {
                TimeIsUp?.Invoke(this,null);
            }
        }

        //public variables
        public TimeSpan TimeLeftPlayer1
        {
            get
            {
                if (!paused && playerTurn == PlayerTurn.Player1Turn)
                {
                    //TimeLeftPlayer1 = TimeSpan.FromMinutes(InitialTimeInMins) - (DateTime.Now - startingTime);
                    TimeLeftPlayer1 = timeLeftPlayer1 - (DateTime.Now - startingTime);
                }

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
                if (!paused && playerTurn == PlayerTurn.Player2Turn)
                {
                    //TimeLeftPlayer2 = TimeSpan.FromMinutes(InitialTimeInMins) - (DateTime.Now - startingTime);
                    TimeLeftPlayer2 = timeLeftPlayer2 - (DateTime.Now - startingTime);
                }

                return timeLeftPlayer2;
            }
            private set
            {
                timeLeftPlayer2 = value;
            }
        }



        public PlayerTurn CurrentPlayerTurn
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
            turnedOn = true;
            Reset();
        }
        public void TurnOff()
        {
            turnedOn = false;
            throw new NotImplementedException();
        }
        public void Pause()
        {
            if (paused)
            {
                return;
            }
            if (playerTurn == PlayerTurn.Player1Turn)
            {
                TimeLeftPlayer1 = timeLeftPlayer1 - (DateTime.Now - startingTime);
            }
            else
            {
                TimeLeftPlayer2 = timeLeftPlayer2 - (DateTime.Now - startingTime);
            }
            paused = true;

        }

        public void Start()
        {
            if (!turnedOn)
            {
                throw new InvalidOperationException();
            }

            paused = false;
            startingTime = DateTime.Now;    //this is the piece of code which allows to avoid pause times
        }

        public void Reset()
        {
            if (!turnedOn)
            {
                throw new InvalidOperationException();
            }
            TimeLeftPlayer1 = initialTime;
            TimeLeftPlayer2 = initialTime;
            paused = true;
            playerTurn = PlayerTurn.Player1Turn;
        }

        public void SwitchPlayerTurn()
        {
            Pause();
            if (CurrentPlayerTurn == PlayerTurn.Player1Turn)
            {
                CurrentPlayerTurn = PlayerTurn.Player2Turn;
            }
            else { CurrentPlayerTurn = PlayerTurn.Player1Turn; }
            Start();
        }


        //public events
        public event EventHandler TimeIsUp;
    }
}