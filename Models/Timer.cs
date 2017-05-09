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
        private TimeSpan timeLeftPlayerBlack;
        private TimeSpan timeLeftPlayerWhite;
        private bool paused, turnedOn;


        //constructor
        public Timer() : this(TimeSpan.FromMinutes(initialDefaultTime)) { }
        public Timer(TimeSpan initialTime)
        {
            paused = true;
            this.initialTime = initialTime;
            sysTimer = new System.Threading.Timer(
                checkTimeLeft,
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(1));
        }

        private void checkTimeLeft(object state)
        {
            if (paused)
            {
                return;
            }
            Pause();

            if (TimeLeftPlayerBlack <= TimeSpan.Zero)
            {
                TimeIsUp?.Invoke(this, Color.Black);
            }
            else if (TimeLeftPlayerWhite <= TimeSpan.Zero)
            {
                TimeIsUp?.Invoke(this, Color.White);
            }
            Start();
        }

        public TimeSpan TimeLeftPlayerWhite
        {
            get
            {
                if (!paused && playerTurn == PlayerTurn.PlayerWhiteTurn)
                {
                    //TimeLeftPlayer2 = TimeSpan.FromMinutes(InitialTimeInMins) - (DateTime.Now - startingTime);
                    TimeLeftPlayerWhite = timeLeftPlayerWhite - (DateTime.Now - startingTime);
                }

                return timeLeftPlayerWhite;
            }
            private set
            {
                timeLeftPlayerWhite = value;
            }
        }


        //public variables
        public TimeSpan TimeLeftPlayerBlack
        {
            get
            {
                if (!paused && playerTurn == PlayerTurn.PlayerBlackTurn)
                {
                    //TimeLeftPlayer1 = TimeSpan.FromMinutes(InitialTimeInMins) - (DateTime.Now - startingTime);
                    TimeLeftPlayerBlack = timeLeftPlayerBlack - (DateTime.Now - startingTime);
                }

                return timeLeftPlayerBlack;
            }
            private set
            {
                timeLeftPlayerBlack = value;
            }
        }




        public Color CurrentPlayerTurn
        {
            get
            {
                if (playerTurn == PlayerTurn.PlayerWhiteTurn)
                {

                    return Color.White;
                }
                else
                {
                    return Color.Black;
                }
            }
            set
            {
                if (value == Color.White)
                {
                    playerTurn = PlayerTurn.PlayerWhiteTurn;
                }
                else
                {
                    playerTurn = PlayerTurn.PlayerBlackTurn;
                }
            }
        }

        public bool InPause
        {
            get
            {
                return paused;
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
        }
        public void Pause()
        {
            if (paused)
            {
                return;
            }
            if (playerTurn == PlayerTurn.PlayerWhiteTurn)
            {
                TimeLeftPlayerWhite = timeLeftPlayerWhite - (DateTime.Now - startingTime);
            }
            else
            {
                TimeLeftPlayerBlack = timeLeftPlayerBlack - (DateTime.Now - startingTime);
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
            TimeLeftPlayerWhite = initialTime;
            TimeLeftPlayerBlack = initialTime;
            paused = true;
            playerTurn = PlayerTurn.PlayerWhiteTurn;
        }

        public void SwitchPlayerTurn()
        {
            Pause();
            if (CurrentPlayerTurn == Color.White)
            {
                CurrentPlayerTurn = Color.Black;
            }
            else { CurrentPlayerTurn = Color.White; }
            Start();
        }


        //public events
        public event EventHandler<Color> TimeIsUp;

        //override methods
        public override string ToString()
        {
            return $"Timer[{this.initialTime}]";
        }
    }
}