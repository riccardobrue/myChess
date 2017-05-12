using System;

namespace myChess.Models
{
    public class TimerModel
    {
        public int ID { get; set; }
        public TableModel Table { get; set; }
        public TimeSpan WhiteTimeLeft { get; set; }
        public TimeSpan BlackTimeLeft { get; set; }


    }
}