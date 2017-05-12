using System;
using System.Collections.Generic;
using myChess.Services;

namespace myChess.Models
{
    public class Notes : INotes
    {
        public IEnumerable<string> GetMovements()
        {
            return null;
        }

        public async void WriteMovement(Database db, TableModel table, string movementString)
        {
            Movement movement = new Movement();
            movement.MovementString = movementString;
            movement.Table = table;
            db.Movements.Add(movement);
            await db.SaveChangesAsync();
        }
    }
}