using System;
using System.Collections.Generic;

namespace myChess.Models.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color color) : base(color)
        {
        }

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

        public override char Character
        {
            get
            {
                return Color == Color.White ? '♞' : '♘';
            }
        }


    }
}