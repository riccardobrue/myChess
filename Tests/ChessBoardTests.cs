using System;
using System.Linq;
using System.Threading;
using myChess.Models;
using Xunit;

namespace myChess.Tests
{

    public class ChessBoardTest
    {

        [Fact]
        public void ChessBoardMustHave64Houses()
        {
            //Given
            IChessBoard chessboard = new ChessBoard();
            //Then
            Assert.Equal(64, chessboard.Houses.Count());
        }


        [Fact]
        public void IndexMustResturnTheCorrectHouse()
        {
            //Given
            IChessBoard chessboard = new ChessBoard();
            IHouse house = chessboard[Column.F, Row.Second];

            //Then
            Assert.Equal(Column.F, house.Column);
            Assert.Equal(Row.Second, house.Row);
        }

    }
}
