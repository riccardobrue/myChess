namespace myChess.Models
{
    public struct Coordinate
    {
        public Coordinate(Row row, Column column)
        {
            Column = column;
            Row = row;
        }
        public Column Column { get; private set; }
        public Row Row { get; private set; }
    }
}