using System;
using System.Threading;
using myChess.Models;
using myChess.Models.Pieces;
using Xunit;

namespace myChess.Tests
{

    public class PiecesTest
    {
        [Fact]
        public void PawnCanMoveOneSTepForward()
        {
            //Given
            Pawn pedone = new Pawn(Color.White);
            //When
            bool esito = pedone.CanMove(
                StartingColumn: Column.a,
                StartingRow: Row.Second,
                DestinationColumn: Column.a,
                DestinationRow: Row.Third);

            //Then
            Assert.True(esito);
        }
        



    }
}