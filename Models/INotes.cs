using System.Collections.Generic;
using myChess.Services;

namespace myChess.Models
{
    public interface INotes
    {
        void WriteMovement(Database db ,TableModel table, string movement);
        IEnumerable<string> GetMovements();

    }
}