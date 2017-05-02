using System.Collections.Generic;

namespace myChess.Models.Pieces
{
    public interface IPiece
    {
        bool CanMove(
            Column StartingColumn,
            Row StartingRow,
            Column DestinationColumn,
            Row DestinationRow,
            IEnumerable<IHouse> HousesList = null);

        Color Color { get; }
    }
}