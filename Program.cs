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
            /*
            Console.ReadKey();

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
            //pawn3.defaultMethod();
            //pawn3.defaultAbstractMethodMustBeOverrided();
            //pawn3.defaultMethodCanBeOverrided();

            */


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




            //Console.ReadKey();

            PlayMatch();

        }

        /*
        private static void notifyDefeat(object sender, Color color)
        {
            Console.WriteLine($"{sender.ToString()} - TIME IS UP! Player with {color} color has been defeated!");
        }
        */

        private static void PlayMatch()
        {
            IChessBoard chessboard = new ChessBoard();
            ITimer timer = new Models.Timer();
            INotes notes = new Notes();
            ITable table = new Table(chessboard, timer, notes);

            bool matchInProgress = true;
            table.Victory += (sender, color) =>
            {
                Console.Clear();
                Console.WriteLine($"Wins {table.Players[color].Name} ({color})!");
                matchInProgress = false;
                table.EndMatch();
            };

            Console.Write("White player: ");
            string whitePlayer = Console.ReadLine();

            Console.Write("Black player: ");
            string blackPlayer = Console.ReadLine();

            table.ReceivePlayers(whitePlayer, blackPlayer);

            table.StartMatch();

            bool error = false;
            bool autoPlay = false;

            while (matchInProgress)
            {

                Console.Clear();
                Color currentPlayerTurn = timer.CurrentPlayerTurn;
                Console.WriteLine($"{table.Players[Color.White].Name} ({Color.White}) VS {table.Players[Color.Black].Name} ({Color.Black})");
                Console.WriteLine();

                Draw(chessboard);

                Console.WriteLine();
                if (error)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.Write($"Moves {table.Players[currentPlayerTurn].Name} ({currentPlayerTurn}): ");
                Console.ForegroundColor = ConsoleColor.White;
                string movement;

                if (autoPlay)
                {
                    movement = GenerateMovement(chessboard, timer.CurrentPlayerTurn);
                    Console.Write(movement);
                    Thread.Sleep(200);
                }
                else
                {
                    movement = Console.ReadLine();
                }
                if (movement.Equals("auto", StringComparison.OrdinalIgnoreCase))
                {
                    autoPlay = true;
                    movement = GenerateMovement(chessboard, timer.CurrentPlayerTurn);
                    Console.Write(movement);
                    Thread.Sleep(200);
                }

                try
                {
                    error = false;
                    table.AddMovement(movement);
                }
                catch (Exception)
                {
                    error = true;
                    autoPlay = false;
                }
            }
            Console.ReadLine();
        }



        private static string GenerateMovement(IChessBoard chessboard, Color color)
        {
            var playablePieces = chessboard.Houses.Where(house => house.PieceInLocation?.Color == color).OrderBy(house => Guid.NewGuid()).ToList();
            foreach (var playablePiece in playablePieces)
            {
                var choosenDestination = chessboard
                .Houses.ToList()
                .Where(house => house.PieceInLocation == null || house.PieceInLocation.Color != color)
                .OrderBy(house => Guid.NewGuid())
                .FirstOrDefault(house => playablePiece.PieceInLocation.CanMove(playablePiece.Column, playablePiece.Row, house.Column, house.Row, chessboard.Houses));
                if (choosenDestination == null)
                    continue;
                return $"{playablePiece.Column}{(int)playablePiece.Row} {choosenDestination.Column}{(int)choosenDestination.Row}";
            }
            return "";
        }


        private static void Draw(IChessBoard chessboard)
        {
            for (var i = 8; i >= 1; i--)
            {
                Console.Write(i);
                Console.Write(" ");

                for (var j = 1; j <= 8; j++)
                {
                    Console.BackgroundColor = (i + j) % 2 != 0 ? ConsoleColor.Black : ConsoleColor.DarkGray;
                    var piece = chessboard[(Column)j, (Row)i].PieceInLocation;
                    var character = piece != null ? piece.Character : ' ';
                    Console.Write($" {character} ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(" ");
            }
            Console.Write("  ");
            for (var i = 1; i <= 8; i++)
            {
                Console.Write($" {(Column)i} ");
            }
            Console.WriteLine();
        }
    }
}
