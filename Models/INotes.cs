using System.Collections.Generic;

namespace myChess.Models
{
    public interface INotes
    {
        void WriteMovement(string movement);
        IEnumerable<string> GetMovements();

    }
}