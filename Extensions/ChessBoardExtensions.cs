using System.Collections.Generic;
using System.Linq;
using myChess.Models;
using myChess.Models.Pieces;

namespace myChess.Extensions
{
    public static class ChessBoardExtensions
    {

        public static IEnumerable<IHouse> WithPieces(
            this IEnumerable<IHouse> housesList)
        {
            return housesList
            .Where(house => house.PieceInLocation != null);
        }

        public static IEnumerable<IHouse> WithPieces(
            this IEnumerable<IHouse> housesList,
            Color color)
        {
            /*
            return housesList
            .Where(house => house.PieceInLocation != null)
            .Where(house => house.PieceInLocation.Color == color);
            */
            return housesList
            .Where(house => house.PieceInLocation?.Color == color);
        }


        public static IEnumerable<IHouse> PiecesType<T>(
            this IEnumerable<IHouse> housesList) where T : IPiece
        {
            return housesList
            .Where(house => house.PieceInLocation?.GetType() == typeof(T));
        }

    }
}