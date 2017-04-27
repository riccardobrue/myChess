using System;

namespace myChess.Models.Pieces
{
    public class King : IPiece
    {
        private readonly Color color;
        public King(Color color)
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
            
            if (columnDifference == 0 && rowDifference == 0) { return false; }

            if (Math.Abs(columnDifference) <= 1 && Math.Abs(rowDifference) <= 1)
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