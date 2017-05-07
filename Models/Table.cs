using System;
using System.Collections.Generic;
using myChess.Models;
namespace myChess.Models
{
    public class Table : ITable
    {
        public IPlayer Player1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPlayer Player2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IChessBoard ChessBoard { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public void ReceivePlayers()
        {
            Players=new Dictionary<Color, IPlayer>();
            Players.Add(Color.White,new Player());
            Players.Add(Color.Black,new Player());
        }

        public Dictionary<Color, IPlayer> Players{
            get;
            private set;
        }

    }
}