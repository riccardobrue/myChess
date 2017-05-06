using System;
using System.Collections.Generic;

namespace myChess.Models.Pieces
{
    public abstract class Piece : IPiece
    {
        public Piece(Color color)
        {
            Color = color;
        }
        public Color Color { get; private set; }

        //----------------------------------------

        public string defaultMethod() { return ""; }
        public virtual string defaultMethodCanBeOverrided() { return ""; }
        public abstract string defaultAbstractMethodMustBeOverrided();

         //----------------------------------------

        public virtual bool CanMove(
            Column StartingColumn,
            Row StartingRow,
            Column DestinationColumn,
            Row DestinationRow,
            IEnumerable<IHouse> HousesList)
        {
            if (StartingColumn == DestinationColumn
                && StartingRow == DestinationRow)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}