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
            paused=true;
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

        //public variables
        public TimeSpan TimeLeftPlayerBlack
        {
            get
            {
                if (!paused && playerTurn == PlayerTurn.Player1Turn)
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

        public TimeSpan TimeLeftPlayerWhite
        {
            get
            {
                if (!paused && playerTurn == PlayerTurn.Player2Turn)
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
                TimeLeftPlayerBlack = timeLeftPlayerBlack - (DateTime.Now - startingTime);
            }
            else
            {
                TimeLeftPlayerWhite = timeLeftPlayerWhite - (DateTime.Now - startingTime);
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
            TimeLeftPlayerBlack = initialTime;
            TimeLeftPlayerWhite = initialTime;
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
        public event EventHandler<Color> TimeIsUp;

        //override methods
        public override string ToString(){
            return $"Timer[{this.initialTime}]";
        }
    }
}