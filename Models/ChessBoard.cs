using System;
using System.Collections.Generic;
using System.Linq;

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
            .Select(index => (IHouse)new House((Column)(index % 8 + 1),
                                                (Row)(index / 8 + 1)))
            .ToArray();


        }

        public IHouse this[Column column, Row row]
        {
            get
            {
                return housesList[(int)column - 1 + (((int)row - 1) * 8)];
            }
        }

        public IEnumerable<IHouse> Houses
        {
            get
            {
                return housesList;
            }
        }

    }
}