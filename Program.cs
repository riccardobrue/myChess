using System;
using myChess.Models;

namespace myChess
{
    class Program
    {
        static void Main(string[] args)
        {
            ITimer timer=new Timer();
            timer.TurnOn();
            timer.Start();
            
            

            Console.WriteLine($"Time 1: {timer.TimeLeftPlayer1}");
            Console.ReadKey();
            
        }
    }
}
