using System;
using System.Collections.Generic;
using System.Linq;

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
            IEnumerable<IHouse> HousesList = null)
        {
            var columnDifference = (int)StartingColumn - (int)DestinationColumn;
            var rowDifference = (int)StartingRow - (int)DestinationRow;

            bool sameColumn = StartingColumn == DestinationColumn;
            int rowsDistance;

            if (columnDifference == 0 && rowDifference == 0) { return false; }

            if (HousesList != null)
            {
                IHouse startingHouse = HousesList
                .Single(House => House.Column == StartingColumn
                && House.Row == StartingRow
                && House.PieceInLocation == this);

                if (Math.Abs(columnDifference) == 1
                    && ((this.Color == Color.White && rowDifference == -1)
                    || (this.Color == Color.Black && rowDifference == 1)))
                {

                    IHouse arrivingHouse = HousesList
                  .Single(House => House.Column == DestinationColumn
                  && House.Row == DestinationRow);

                    if (arrivingHouse != null
                        && arrivingHouse.PieceInLocation != null
                        && arrivingHouse.PieceInLocation.Color != this.Color)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

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