using System;
using myChess.Models.Pieces;

namespace myChess.Models
{
    public class House : IHouse
    {
        private Column column;
        private Row row;
        private IPiece pieceInLocation;
        public House(Column column, Row row)
        {
            this.column = column;
            this.row = row;
        }

        public Column Column
        {
            get { return column; }
        }

        public Row Row
        {
            get { return row; }
        }

        public IPiece PieceInLocation
        {
            get
            {
                return pieceInLocation;
            }
            set
            {
                pieceInLocation = value;
            }
        }
    }
}