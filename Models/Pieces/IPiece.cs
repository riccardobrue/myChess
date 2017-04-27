namespace myChess.Models.Pieces
{
    public interface IPiece
    {
        bool CanMove(
            Column StartingColumn,
            Row StartingRow,
            Column DestinationColumn,
            Row DestinationRow,
            IChessBoard ChessBoard = null);

        Color Color { get; }
    }
}