using myChess.Models.Pieces;

namespace myChess.Models
{
    public interface IHouse
    {
        Column Column { get; }
        Row Row { get; }
        IPiece PieceInLocation { get; set; }

    }
}