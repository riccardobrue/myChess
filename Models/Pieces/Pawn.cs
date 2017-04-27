using System;

namespace myChess.Models.Pieces
{
    public class Pawn : IPiece
    {
        private readonly Color color;
        public Pawn(Color color)
        {
            this.color = color;
        }

        public Color Color
        {
            get
            {
                return color;
            }
        }

        public bool CanMove(
            Column StartingColumn,
            Row StartingRow,
            Column DestinationColumn,
            Row DestinationRow,
            IChessBoard ChessBoard = null)
        {
            var columnDifference = (int)StartingColumn - (int)DestinationColumn;
            var rowDifference = (int)StartingRow - (int)DestinationRow;

            bool sameColumn = StartingColumn == DestinationColumn;
            int rowsDistance;

            if (columnDifference == 0 && rowDifference == 0) { return false; }

            if (Color == Color.White)
            {
                rowsDistance = (int)DestinationRow - (int)StartingRow;
            }
            else
            {
                rowsDistance = (int)StartingRow - (int)DestinationRow;
            }

            if (sameColumn && rowsDistance == 1)
            {
                return true;
            }
            else
            {
                return false;
            }







        }
    }
}