using System;
using System.Collections.Generic;
using myChess.Models;
namespace myChess.Models
{
    public class Table : ITable
    {

        public IChessBoard ChessBoard { get; private set; }

        public ITimer Timer { get; private set; }
        public INotes Notes { get; private set; }
        public Table(IChessBoard chessBoard, ITimer timer, INotes notes)
        {
            ChessBoard = chessBoard;
            Timer = timer;
            Notes = notes;
        }

        public void ReceivePlayers(string nameWhitePlayer, string nameBlackPlayer)
        {
            Players = new Dictionary<Color, IPlayer>();
            Players.Add(Color.White, new Player(nameWhitePlayer));
            Players.Add(Color.Black, new Player(nameBlackPlayer));
        }

        public void EndMatch()
        {
            Timer.Reset();
            ChessBoard = new ChessBoard();
            Players = null;
        }

        public void StartMatch()
        {
            if (Players == null)
            {
                throw new InvalidOperationException("You must declare player names");
            }
            Timer.TurnOn();
            Timer.Start();


        }

        public void AddMovement(string movement)
        {
            Coordinate starting = HouseCoordinatesInterpreter(movement.Substring(0, 2));
            Coordinate destination = HouseCoordinatesInterpreter(movement.Substring(3, 2));

            IHouse startingHouse = ChessBoard[starting.Column, starting.Row];
            IHouse destinationHouse = ChessBoard[destination.Column, destination.Row];



            if (startingHouse.PieceInLocation == null ||
                startingHouse.PieceInLocation?.Color != Timer.CurrentPlayerTurn ||
                destinationHouse.PieceInLocation?.Color == Timer.CurrentPlayerTurn ||
                startingHouse.PieceInLocation?.CanMove(starting.Column, starting.Row,
                destination.Column, destination.Row, ChessBoard.Houses) == false
                )
            {
                throw new InvalidOperationException("Mossa non valida");
            }

            ChessBoard.MovePiece(startingHouse, destinationHouse);
            Notes.WriteMovement(movement);
            //Check King still alive
            Color checkDefeatedColor;
            if (Timer.CurrentPlayerTurn == Color.White)
            {
                checkDefeatedColor = Color.Black;
            }
            else
            {
                checkDefeatedColor = Color.White;
            }
            bool reInVita = ChessBoard.KingIsAlive(checkDefeatedColor);
            if (!reInVita)
            {
                Victory.Invoke(ChessBoard, Timer.CurrentPlayerTurn);
            }
            Timer.SwitchPlayerTurn();




        }

        public event EventHandler<Color> Victory;

        internal Coordinate HouseCoordinatesInterpreter(string house)
        {
            /*
            Enum.TryParse<Column>(house.Substring(0, 1), out Column column);
            int.TryParse(house.Substring(1, 1), out int rowInt);
            Row row = (Row)rowInt;
            return new Coordinate(column, row);*/

            bool ParseColumnResult = Enum.TryParse<Column>(house.Substring(0, 1), out Column column);
            bool ParseRowResult = Enum.TryParse<Row>(house.Substring(1, 1), out Row row);
            if(!ParseColumnResult || !ParseRowResult) {
                throw new InvalidOperationException("Input errato");
            }
            return new Coordinate(row, column);

        }


        public Dictionary<Color, IPlayer> Players { get; private set; }





    }
}