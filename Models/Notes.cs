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

        public async void WriteMovement(string movementString)
        {
            Database db = new Database();
            Movement movement = new Movement();
            movement.MovementString = movementString;
            db.Movements.Add(movement);
            await db.SaveChangesAsync();
        }
    }
}