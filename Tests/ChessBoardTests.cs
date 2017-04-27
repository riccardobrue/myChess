using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using myChess.Models;
using myChess.Models.Pieces;
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

        [Fact]
        public void InTheSecondRowThereAreAllWhitePawns()
        {
            //Given
            IChessBoard chessboard = new ChessBoard();
            //When
            IEnumerable<IHouse> secondRowHouses = chessboard.Houses
                .Where(house => house.Row == Row.Second);
            //Then 1
            for (int i = 1; i <= 8; i++)
            {
                Assert.IsType(
                    typeof(Pawn),
                    chessboard[(Column)i, Row.Second].PieceInLocation);
            }
            //Then 2
            bool allWhitePawns = secondRowHouses.All(house => house.PieceInLocation is Pawn
                && house.PieceInLocation.Color == Color.White);
            Assert.True(allWhitePawns);
        }


        [Fact]
        public void ThereIsOnlyOneWhiteKingInFirstRowAndEColumn()
        {
            //Given
            IChessBoard chessboard = new ChessBoard();
            //When
            IEnumerable<IHouse> kingsHouses = chessboard.Houses
                .Where(house => house.PieceInLocation is King
                    && house.PieceInLocation.Color == Color.White);
            //Then 
            Assert.Equal(1, kingsHouses.Count());//there is only one white king
            Assert.Equal(Column.E, kingsHouses.First().Column);//white king's column is E
            Assert.Equal(Row.First, kingsHouses.First().Row);//white king's row is the First

        }


        [Theory]
        [InlineData(typeof(Rook), Color.White, Column.A, Row.First)]
        public void PiecesMustBeInTheCorrectHouse(
            Type pieceType,
            Color pieceColor,
            Column column,
            Row row)
        {
            //Given
            IChessBoard chessboard = new ChessBoard();
            chessboard.Houses.Single(house =>
                house.PieceInLocation != null
                && house.PieceInLocation.GetType() == pieceType
                && house.PieceInLocation.Color == pieceColor
                && house.Row == row
                && house.Column == column);
        }
    }
}
