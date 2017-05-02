using System;
using myChess.Models;
using myChess.Models.Pieces;
using Xunit;

namespace myChess.Tests
{
    public class QuizTests
    {
        
        [Fact]
        public void HouseBehaviour()
        {
        //Given
        IHouse house1 = new House(Column.A, Row.First);
        IHouse house2 = house1;
        house1.PieceInLocation = new Pawn(Color.White);
        house2.PieceInLocation = new Pawn(Color.Black);
        
        //Then
        Assert.Equal(Color.Black, house1.PieceInLocation.Color);
        Assert.Equal(Color.Black, house2.PieceInLocation.Color);

        }

        [Fact]
        public void TestValueType()
        {
        //Given
        int a = 5;
        int b = a;
        b++;
        
        //Then
        Assert.Equal(5, a);
        Assert.Equal(6, b);
        }

        [Fact]
        public void TestData()
        {
        //Given
        DateTime d1 = new DateTime(2017, 1, 1);
        DateTime d2 = d1;
        d1 = d1.AddYears(1);

        //When
        
        //Then
        Assert.Equal(2018, d1.Year);
        Assert.Equal(2017, d2.Year);
        }
    }
}