using System;
using System.Collections.Generic;

namespace myChess.Models.Pieces
{
    public class Queen : IPiece
    {
        private readonly Color color;
        public Queen(Color color)
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
            IEnumerable<IHouse> HousesList = null)
        {
            var columnDifference = (int)StartingColumn - (int)DestinationColumn;
            var rowDifference = (int)StartingRow - (int)DestinationRow;

            bool sameColumn = StartingColumn == DestinationColumn;
            bool sameRow = StartingRow == DestinationRow;

            if (columnDifference == 0 && rowDifference == 0) { return false; }

            if ((sameColumn && !sameRow)//vertical movement
                || (sameRow && !sameColumn)//horizontal movement
                || ((Math.Abs(columnDifference) - Math.Abs(rowDifference)) == 0))//diagonal movement
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