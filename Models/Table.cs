using System;
using System.Collections.Generic;
using myChess.Models;
namespace myChess.Models
{
    public class Table : ITable
    {

        public IChessBoard ChessBoard { get; private set; }

        public ITimer Timer { get; private set; }

        public Table(IChessBoard chessBoard, ITimer timer)
        {
            ChessBoard = chessBoard;
            Timer = timer;
        }

        public void ReceivePlayers(string nameWhitePlayer, string nameBlackPlayer)
        {
            Players = new Dictionary<Color, IPlayer>();
            Players.Add(Color.White, new Player(nameWhitePlayer));
            Players.Add(Color.Black, new Player(nameBlackPlayer));
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
            Coordinate startingHouse = HouseCoordinatesInterpreter(movement.Substring(0, 2));
            Coordinate destinationHouse = HouseCoordinatesInterpreter(movement.Substring(4, 2));
        }

        internal Coordinate HouseCoordinatesInterpreter(string house)
        {
            Enum.TryParse<Column>(house.Substring(0, 1), out Column column);
            int.TryParse(house.Substring(1, 1), out int rowInt);
            Row row = (Row)rowInt;
            return new Coordinate(column, row);

        }

        public Dictionary<Color, IPlayer> Players { get; private set; }


    }
}