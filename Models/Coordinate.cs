namespace myChess.Models
{
    public struct Coordinate
    {
        public Coordinate(Column column, Row row)
        {
            Column = column;
            Row = row;
        }
        public Column Column { get; private set; }
        public Row Row { get; private set; }
    }
}