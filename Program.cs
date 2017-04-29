using System;
using System.Threading;
using myChess.Models;
using myChess.Extensions;
using System.Collections.Generic;
using myChess.Models.Pieces;

namespace myChess
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleXUnitRunner.SimpleXUnit.RunTests();
            //Console.ReadKey();

            //ITimer timer = new Models.Timer(TimeSpan.FromSeconds(5));
            /*
            //METHOD 1
            timer.TimeIsUp += notifyDefeat;
            */
            /*
            //METHOD 2           
            timer.TimeIsUp += (object sender,Color color) =>
            {
                Console.WriteLine($"{sender.ToString()} - TIME IS UP! Player with {color} color has been defeated!");
            };
            */
            //METHOD 3
            /* 
            EventHandler<Color> notifyDefeat = (object sender, Color color) =>
            {
                Console.WriteLine($"{sender.ToString()} - TIME IS UP! Player with {color} color has been defeated!");
            };

            timer.TimeIsUp += notifyDefeat;
            //timer.TimeIsUp -= notifyDefeat;

            timer.TurnOn();
            timer.Start();



            Console.WriteLine($"Time 1: {timer.TimeLeftPlayerBlack}");
            Thread.Sleep(1000);
            Console.WriteLine($"Time 2: {timer.TimeLeftPlayerBlack}");
            Thread.Sleep(1000);
            Console.WriteLine($"Time 3: {timer.TimeLeftPlayerBlack}");
            Thread.Sleep(1000);
            Console.WriteLine($"Time 4: {timer.TimeLeftPlayerBlack}");
            Thread.Sleep(1000);
            Console.WriteLine($"Time 5: {timer.TimeLeftPlayerBlack}");
            */

            IChessBoard chessboard = new ChessBoard();
            IEnumerable<IHouse> list = chessboard.Houses
                .WithPieces()
                .PiecesType<Pawn>();

            foreach (House house in list)
            {
                IPiece piece = house.PieceInLocation;
                Console.WriteLine($"{piece.Color} - {piece.GetType().ToString()}");
            }



            Console.ReadKey();

        }

        /*
        private static void notifyDefeat(object sender, Color color)
        {
            Console.WriteLine($"{sender.ToString()} - TIME IS UP! Player with {color} color has been defeated!");
        }
        */
    }
}
