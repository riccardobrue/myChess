using System.Collections.Generic;

namespace myChess.Models
{
    public class TableModel
    {
        public int ID { get; set; }
        public List<Movement> Movements { get; set; }
        public TimerModel Timer { get; set; }

    }
}