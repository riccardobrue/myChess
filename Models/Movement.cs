namespace myChess.Models
{
    public class Movement
    {
        public int ID { get; set; }
        public string MovementString { get; set; }
        public TableModel Table { get; set; }
    }
}