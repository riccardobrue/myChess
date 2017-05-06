using System;
using System.Threading;
using myChess.Models;
using myChess.Extensions;
using System.Collections.Generic;
using myChess.Models.Pieces;
using System.Linq;

namespace myChess
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleXUnitRunner.SimpleXUnit.RunTests();
            //Console.ReadKey();

            Dictionary<int, IChessBoard> matches = new Dictionary<int, IChessBoard>();
            int counter = 1;

            matches.Add(counter, new ChessBoard());
            //the player has moved a piece
            int key = 1;
            if (matches.ContainsKey(key))
            {
                Console.WriteLine(matches[key].Houses.Count());
            }
            else
            {
                Console.WriteLine("Match not found");
            }

            IPiece pawn1 = new Pawn(Color.White);
            IPiece pawn2 = new Pawn(Color.White);
            Console.WriteLine(pawn1);
            Console.WriteLine(pawn1.Equals(pawn2));


            var dictionary = new Dictionary<IPiece, string>();
            dictionary.Add(pawn1, "Riccardo");
            dictionary.Add(pawn2, "Riccardo");

            Piece pawn3 = new Pawn(Color.White);
            pawn3.defaultMethod();
            pawn3.defaultAbstractMethodMustBeOverrided();
            pawn3.defaultMethodCanBeOverrided();




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
            /*
            IChessBoard chessboard = new ChessBoard();
            IEnumerable<IHouse> list = chessboard.Houses
                .WithPieces()
                .PiecesType<Pawn>();

            foreach (House house in list)
            {
                IPiece piece = house.PieceInLocation;
                Console.WriteLine($"{piece.Color} - {piece.GetType().ToString()}");
            }
            */




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
