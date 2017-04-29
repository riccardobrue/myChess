using System;
using System.Threading;
using myChess.Models;
using Xunit;

namespace myChess.Tests
{

    public class TimerTests
    {
        [Fact]
        public void BothPlayerTimersSettedAtInitialTime()
        {
            //Given
            ITimer timer = new Models.Timer();
            //When
            timer.TurnOn();
            //Then
            Assert.Equal(TimeSpan.FromMinutes(Models.Timer.initialDefaultTime), timer.TimeLeftPlayerBlack);
            Assert.Equal(TimeSpan.FromMinutes(Models.Timer.initialDefaultTime), timer.TimeLeftPlayerWhite);
        }

        [Fact]
        public void TimeWillBeDecrementedForPlayer1()
        {
            //Given
            ITimer timer = new Models.Timer();
            //When
            timer.TurnOn();
            timer.Start();
            Thread.Sleep(500);
            //Then
            Assert.InRange(
                timer.TimeLeftPlayerBlack,
                TimeSpan.FromMilliseconds(0),
                TimeSpan.FromMilliseconds(299500)
            );

        }


        [Fact]
        public void TimeWontBeDecrementedForPlayer1InPause()
        {
            //Given
            ITimer timer = new Models.Timer();
            //When
            timer.TurnOn();
            timer.Start();
            Thread.Sleep(100);
            timer.Pause();
            TimeSpan timeInPause = timer.TimeLeftPlayerBlack;
            Thread.Sleep(500);
            //Then
            Assert.Equal(timer.TimeLeftPlayerBlack, timeInPause);

        }


        [Fact]
        public void TimeWillBeDecrementedAfterAPauseForPlayer1()
        {
            //Given
            ITimer timer = new Models.Timer();

            //When
            timer.TurnOn();
            timer.Start();
            TimeSpan timeInPause = timer.TimeLeftPlayerBlack;
            Thread.Sleep(250);
            timer.Pause();
            Assert.True(timer.TimeLeftPlayerBlack <= TimeSpan.FromMilliseconds(timeInPause.TotalMilliseconds - 250));
            timer.Start();
            Thread.Sleep(250);

            //Then
            /*
             Assert.InRange(
                timer.TimeLeftPlayer1,
                TimeSpan.FromMilliseconds(0),
                TimeSpan.FromMilliseconds(timeInPause.TotalMilliseconds-500)
            );
            */
            Assert.True(timer.TimeLeftPlayerBlack <= TimeSpan.FromMilliseconds(timeInPause.TotalMilliseconds - 500));

        }


        [Fact]
        public void WhenPlayerSwitchOccourPreviousPlayerTimerIsBlocked()
        {
            //Given
            ITimer timer = new Models.Timer();
            //When
            timer.TurnOn(); //(Player 1)
            timer.Start();
            Thread.Sleep(200);
            timer.Pause();
            TimeSpan firstTimePlayer1 = timer.TimeLeftPlayerBlack;
            TimeSpan firstTimePlayer2 = timer.TimeLeftPlayerWhite;
            //Then
            Assert.Equal(firstTimePlayer2, TimeSpan.FromMinutes(Models.Timer.initialDefaultTime));    //player 2 still have 5 minutes (initial time)
            Assert.True(firstTimePlayer1.TotalMilliseconds <= TimeSpan.FromMinutes(Models.Timer.initialDefaultTime).TotalMilliseconds - 200); //player 1 time is decreased
            //And When
            timer.SwitchPlayerTurn();   //SWITCH (Player 2)
            timer.Start();
            Thread.Sleep(300);
            timer.Pause();
            TimeSpan secondTimePlayer1 = timer.TimeLeftPlayerBlack;
            TimeSpan secondTimePlayer2 = timer.TimeLeftPlayerWhite;
            //Then
            Assert.Equal(firstTimePlayer1, timer.TimeLeftPlayerBlack); //player 1 still have the same previous time
            Assert.True(timer.TimeLeftPlayerWhite.TotalMilliseconds <= (firstTimePlayer2.TotalMilliseconds - 300)); //player 2 time is decreased
            //And When
            timer.SwitchPlayerTurn();   //SWITCH (Player 1)
            timer.Start();
            Thread.Sleep(400);
            timer.Pause();
            TimeSpan thirdTimePlayer1 = timer.TimeLeftPlayerBlack;
            TimeSpan thirdTimePlayer2 = timer.TimeLeftPlayerWhite;
            //Then
            Assert.Equal(secondTimePlayer2, timer.TimeLeftPlayerWhite); //player 2 still have the same previous time
            Assert.True(timer.TimeLeftPlayerBlack.TotalMilliseconds <= secondTimePlayer1.TotalMilliseconds - 400); //player 1 time is decreased
            //And When
            timer.SwitchPlayerTurn();   //SWITCH (Player 2)
            timer.Start();
            Thread.Sleep(600);
            timer.Pause();
            //Then
            Assert.Equal(thirdTimePlayer1, timer.TimeLeftPlayerBlack); //player 1 still have the same timer
            Assert.True(timer.TimeLeftPlayerWhite.TotalMilliseconds <= thirdTimePlayer2.TotalMilliseconds - 600); //player 1 time is decreased

            //LAST THEN
            Assert.True(timer.TimeLeftPlayerBlack.TotalMilliseconds <= TimeSpan.FromMinutes(Models.Timer.initialDefaultTime).TotalMilliseconds - 600); //player 1 time is decreased by the sum from the game start (200+400)
            Assert.True(timer.TimeLeftPlayerWhite.TotalMilliseconds <= TimeSpan.FromMinutes(Models.Timer.initialDefaultTime).TotalMilliseconds - 900); //player 2 time is decreased by the sum from the game start (600+300)

            Assert.InRange(
                timer.TimeLeftPlayerBlack,
                TimeSpan.FromMilliseconds(0),
                TimeSpan.FromMilliseconds(TimeSpan.FromMinutes(Models.Timer.initialDefaultTime).TotalMilliseconds - 600)
            );
            Assert.InRange(
                timer.TimeLeftPlayerWhite,
                TimeSpan.FromMilliseconds(0),
                TimeSpan.FromMilliseconds(TimeSpan.FromMinutes(Models.Timer.initialDefaultTime).TotalMilliseconds - 900)
            );

        }

        [Fact]
        public void FiveMinutesAfterReset()
        {
            //Given
            ITimer timer = new Models.Timer();
            //When
            timer.TurnOn(); //(Player 1)
            timer.Start();
            Thread.Sleep(600);
            timer.SwitchPlayerTurn();   //SWITCH (Player 2)
            Thread.Sleep(800);
            timer.Pause();
            //Then
            Assert.True(
                timer.TimeLeftPlayerBlack.TotalMilliseconds <= TimeSpan.FromMinutes(Models.Timer.initialDefaultTime).TotalMilliseconds - 600); //player 1 time is decreased by the sum from the game start (200+400)
            Assert.True(
                timer.TimeLeftPlayerWhite.TotalMilliseconds <= TimeSpan.FromMinutes(Models.Timer.initialDefaultTime).TotalMilliseconds - 800); //player 2 time is decreased by the sum from the game start (600+300)

            //And When
            timer.Reset();
            Thread.Sleep(300);
            //Then
            Assert.Equal(timer.TimeLeftPlayerBlack, TimeSpan.FromMinutes(Models.Timer.initialDefaultTime));
            Assert.Equal(timer.TimeLeftPlayerWhite, TimeSpan.FromMinutes(Models.Timer.initialDefaultTime));
        }

        [Fact]
        public void ThrowExceptionWhenStartBeforeTurnOn()
        {
            //Given
            ITimer timer = new Models.Timer();
            //When & Then
            Assert.Throws(typeof(InvalidOperationException), () => { timer.Start(); });//lambda expression
        }

        [Fact]
        public void ThrowTimeIsUpEvent()
        {
            //Given
            ITimer timer = new Models.Timer(TimeSpan.FromMilliseconds(500));
            //When
            timer.TurnOn();
            timer.Start();

            //Then
            bool invoked = false;
            timer.TimeIsUp += (sender, args) =>
            {
                invoked = true;
            };
            Thread.Sleep(2000);
            Assert.True(invoked);
        }





    }





}