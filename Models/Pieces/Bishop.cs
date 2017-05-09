using System;
using System.Collections.Generic;

namespace myChess.Models.Pieces
{
    public class Bishop : Piece
    {

        public Bishop(Color color) : base(color) { }

        public override bool CanMove(
            Column StartingColumn,
            Row StartingRow,
            Column DestinationColumn,
            Row DestinationRow,
            IEnumerable<IHouse> HousesList = null)
        {

            bool canMove = base.CanMove(StartingColumn,
             StartingRow,
             DestinationColumn,
             DestinationRow,
             HousesList);
            if (!canMove)
            {
                return false;
            }

            var columnDifference = (int)StartingColumn - (int)DestinationColumn;
            var rowDifference = (int)StartingRow - (int)DestinationRow;
            if (columnDifference == 0 && rowDifference == 0) { return false; }

            if ((Math.Abs(columnDifference) - Math.Abs(rowDifference)) == 0)//diagonal movement
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override char Character
        {
            get
            {
                return Color == Color.White ? '♝' : '♗';
            }
        }
    }
}