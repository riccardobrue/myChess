using System;
using System.Threading;
using myChess.Models;
using Xunit;

namespace myChess.Tests
{

    public class TimerTest
    {
        [Fact]
        public void BothPlayerTimersSettedAt5Mins()
        {
            //Given
            ITimer timer = new Models.Timer();
            //When
            timer.TurnOn();
            //Then
            Assert.Equal(TimeSpan.FromMinutes(5), timer.TimeLeftPlayer1);
            Assert.Equal(TimeSpan.FromMinutes(5), timer.TimeLeftPlayer2);
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
                timer.TimeLeftPlayer1,
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
            TimeSpan timeInPause = timer.TimeLeftPlayer1;
            Thread.Sleep(500);
            //Then
            Assert.Equal(timer.TimeLeftPlayer1, timeInPause);

        }


        [Fact]
        public void TimeWillBeDecrementedAfterAPauseForPlayer1()
        {
            //Given
            ITimer timer = new Models.Timer();

            //When
            timer.TurnOn();
            timer.Start();
            TimeSpan timeInPause = timer.TimeLeftPlayer1;
            Thread.Sleep(250);
            timer.Pause();
            Assert.True(timer.TimeLeftPlayer1 <= TimeSpan.FromMilliseconds(timeInPause.TotalMilliseconds - 250));
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
            Assert.True(timer.TimeLeftPlayer1 <= TimeSpan.FromMilliseconds(timeInPause.TotalMilliseconds - 500));

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
            TimeSpan firstTimePlayer1 = timer.TimeLeftPlayer1;
            TimeSpan firstTimePlayer2 = timer.TimeLeftPlayer2;
            //Then
            Assert.Equal(firstTimePlayer2, TimeSpan.FromMinutes(5));    //player 2 still have 5 minutes (initial time)
            Assert.True(firstTimePlayer1.TotalMilliseconds <= TimeSpan.FromMinutes(5).TotalMilliseconds - 200); //player 1 time is decreased
            //And When
            timer.SwitchPlayerTurn();   //SWITCH (Player 2)
            timer.Start();
            Thread.Sleep(300);
            timer.Pause();
            TimeSpan secondTimePlayer1 = timer.TimeLeftPlayer1;
            TimeSpan secondTimePlayer2 = timer.TimeLeftPlayer2;
            //Then
            Assert.Equal(firstTimePlayer1, timer.TimeLeftPlayer1); //player 1 still have the same previous time
            Assert.True(timer.TimeLeftPlayer2.TotalMilliseconds <= (firstTimePlayer2.TotalMilliseconds - 300)); //player 2 time is decreased
            //And When
            timer.SwitchPlayerTurn();   //SWITCH (Player 1)
            timer.Start();
            Thread.Sleep(400);
            timer.Pause();
            TimeSpan thirdTimePlayer1 = timer.TimeLeftPlayer1;
            TimeSpan thirdTimePlayer2 = timer.TimeLeftPlayer2;
            //Then
            Assert.Equal(secondTimePlayer2, timer.TimeLeftPlayer2); //player 2 still have the same previous time
            Assert.True(timer.TimeLeftPlayer1.TotalMilliseconds <= secondTimePlayer1.TotalMilliseconds - 400); //player 1 time is decreased
            //And When
            timer.SwitchPlayerTurn();   //SWITCH (Player 2)
            timer.Start();
            Thread.Sleep(600);
            timer.Pause();
            //Then
            Assert.Equal(thirdTimePlayer1, timer.TimeLeftPlayer1); //player 1 still have the same timer
            Assert.True(timer.TimeLeftPlayer2.TotalMilliseconds <= thirdTimePlayer2.TotalMilliseconds - 600); //player 1 time is decreased

            //LAST THEN
            Assert.True(timer.TimeLeftPlayer1.TotalMilliseconds <= TimeSpan.FromMinutes(5).TotalMilliseconds - 600); //player 1 time is decreased by the sum from the game start (200+400)
            Assert.True(timer.TimeLeftPlayer2.TotalMilliseconds <= TimeSpan.FromMinutes(5).TotalMilliseconds - 900); //player 2 time is decreased by the sum from the game start (600+300)
           
            Assert.InRange(
                timer.TimeLeftPlayer1,
                TimeSpan.FromMilliseconds(0),
                TimeSpan.FromMilliseconds(TimeSpan.FromMinutes(5).TotalMilliseconds - 600)
            );
            Assert.InRange(
                timer.TimeLeftPlayer2,
                TimeSpan.FromMilliseconds(0),
                TimeSpan.FromMilliseconds(TimeSpan.FromMinutes(5).TotalMilliseconds - 900)
            );
            
        }


    }





}