using System;
using System.Collections.Generic;
using System.Linq;
using myChess.Models.Pieces;

namespace myChess.Models
{
    public class ChessBoard : IChessBoard
    {
        private IHouse[] housesList;

        /*
                public ChessBoard()
                {
                    housesList = new IHouse[64];
                    var index = 0;
                    for (int i = 1; i <= 8; i++)
                    {
                        for (int j = 1; j <= 8; j++, index++)
                        {
                            IHouse house = new House((Column)j, (Row)i);
                            housesList[index] = house;
                        }
                    }
                }
        */
        public ChessBoard()
        {
            housesList = Enumerable
            .Range(0, 64) //list of 64 elements (index from 0 to 63)
            //.Select(index => new House((Column)(index % 8 + 1), (Row)(index / 8 + 1)))
            .Select(index => CreateHouse(index))
            .ToArray();



        }

        internal IHouse CreateHouse(int index)
        {
            Column column = (Column)(index % 8 + 1);
            Row row = (Row)(index / 8 + 1);
            IHouse house = new House(column, row);

            if (row == Row.Second)
            {
                house.PieceInLocation = new Pawn(Color.White);
            }
            else if (row == Row.Seventh)
            {
                house.PieceInLocation = new Pawn(Color.Black);
            }
            else if (row == Row.First || row == Row.Eighth)
            {
                Color color = (row == Row.First) ? Color.White : Color.Black;

                switch (column)
                {
                    case Column.A:
                        house.PieceInLocation = new Rook(color);
                        break;
                    case Column.B:
                        house.PieceInLocation = new Knight(color);
                        break;
                    case Column.C:
                        house.PieceInLocation = new Bishop(color);
                        break;
                    case Column.D:
                        house.PieceInLocation = new Queen(color);
                        break;
                    case Column.E:
                        house.PieceInLocation = new King(color);
                        break;
                    case Column.F:
                        house.PieceInLocation = new Bishop(color);
                        break;
                    case Column.G:
                        house.PieceInLocation = new Knight(color);
                        break;
                    case Column.H:
                        house.PieceInLocation = new Rook(color);
                        break;
                }
            }

            return house;
        }

        public IHouse this[Column column, Row row]
        {
            get
            {
                return housesList[(int)column - 1 + (((int)row - 1) * 8)];
            }
            set
            {
                housesList[(int)column - 1 + (((int)row - 1) * 8)] = value;
            }
        }

        public IEnumerable<IHouse> Houses
        {
            get
            {
                return housesList;
            }
        }



        public bool KingIsAlive(Color color)
        {
            try
            {
                Houses.Single(house => house.PieceInLocation is King
                && house.PieceInLocation.Color == color);
                return true;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }

        }

        public void MovePiece(IHouse startingHouse, IHouse destinationHouse)
        {
            destinationHouse.PieceInLocation = startingHouse.PieceInLocation;
            startingHouse.PieceInLocation = null;
        }


    }
}