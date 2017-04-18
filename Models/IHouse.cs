namespace myChess.Models
{
    public interface IHouse
    {
        Column column { get; }
        Row row { get; }
        IPiece locatedPiece { get; set; }

    }
}