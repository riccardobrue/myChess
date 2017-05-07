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
            ITable table = new Table();
            table.ReceivePlayers();
            Dictionary<Color, IPlayer> players = table.Players;
            Assert.Equal(2, players.Count);
            Assert.Equal(1, players.Where(color => color.Key == Color.White).Count());
            Assert.Equal(1, players.Where(color => color.Key == Color.Black).Count());
        }
    }
}