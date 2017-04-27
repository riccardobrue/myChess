using System.Collections.Generic;

namespace myChess.Models
{
    public interface IChessBoard
    {
        IEnumerable<IHouse> Houses { get; }
        IHouse this[Column column, Row row] { get; }
    }
}