using System;

namespace myChess.Models.Pieces
{
    public class Bishop : IPiece
    {
        private readonly Color color;
        public Bishop(Color color)
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

            if ((Math.Abs(columnDifference) - Math.Abs(rowDifference)) == 0)//diagonal movement
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