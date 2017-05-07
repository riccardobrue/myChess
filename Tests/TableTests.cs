using System.Collections.Generic;
using System.Linq;
using myChess.Models;
using Xunit;

namespace myChess.Tests
{
    public class TableTests
    {
        [Fact]
        public void TheTableMustHaveTwoPlayers()
        {
            ITable table = new Table(null, null);
            table.ReceivePlayers("Player A", "Player B");
            Dictionary<Color, IPlayer> players = table.Players;
            Assert.Equal(2, players.Count);
            Assert.Equal(1, players.Where(color => color.Key == Color.White).Count());
            Assert.Equal(1, players.Where(color => color.Key == Color.Black).Count());

            IPlayer whitePlayer = players[Color.White];
            IPlayer blackPlayer = players[Color.Black];
            Assert.Equal("Player A", whitePlayer.Name);
            Assert.Equal("Player B", blackPlayer.Name);

        }

        [Fact]
        public void TheTableMustBeAssortedWithChessBoardAndTimer()
        {
            //Given
            IChessBoard chessBoard = new ChessBoard();
            ITimer timer = new Timer();
            ITable table = new Table(chessBoard, timer);
            //When
            table.ReceivePlayers("Player A", "Player B");
            Dictionary<Color, IPlayer> players = table.Players;
            table.StartMatch();
            //Then
            Assert.NotEqual(null, table.ChessBoard);
            Assert.NotEqual(null, table.Timer);
            Assert.False(table.Timer.InPause);
        }


        [Fact]
        public void TheTableMustInterpretCoordinates()
        {
            //Given

            Table table = new Table(null, null);
            //When
            Coordinate coordinate = table.HouseCoordinatesInterpreter("A4");

            //Then
            Assert.Equal(Row.Fourth, coordinate.Row);
            Assert.Equal(Column.A, coordinate.Column);

        }
    }
}