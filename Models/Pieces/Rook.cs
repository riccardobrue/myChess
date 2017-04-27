using System;

namespace myChess.Models.Pieces
{
    public class Rook : IPiece
    {
        private readonly Color color;
        public Rook(Color color)
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

            bool sameColumn = StartingColumn == DestinationColumn;
            bool sameRow = StartingRow == DestinationRow;


            if ((sameColumn && !sameRow)//vertical movement
                || (sameRow && !sameColumn))//horizontal movement
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