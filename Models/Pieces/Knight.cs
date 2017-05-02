using System;
using System.Collections.Generic;

namespace myChess.Models.Pieces
{
    public class Knight : IPiece
    {
        private readonly Color color;
        public Knight(Color color)
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
            
            if (columnDifference == 0 && rowDifference == 0) { return false; }

            if (Math.Abs(rowDifference) == 2)
            {
                if (Math.Abs(columnDifference) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (Math.Abs(columnDifference) == 2)
            {

                if (Math.Abs(rowDifference) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }


    }
}