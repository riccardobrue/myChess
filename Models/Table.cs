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
           
           var coordinates=movement.Split(' ');

        }

        public Dictionary<Color, IPlayer> Players { get; private set; }


    }
}