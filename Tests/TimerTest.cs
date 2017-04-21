using System;
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
        ITimer timer=new Timer();
        //When
        timer.TurnOn();
        //Then
        Assert.Equal(TimeSpan.FromMinutes(5),timer.TimeLeftPlayer1);
        Assert.Equal(TimeSpan.FromMinutes(5),timer.TimeLeftPlayer2);
        }

    }



}