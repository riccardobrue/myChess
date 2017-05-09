using Microsoft.EntityFrameworkCore;
using myChess.Models;

namespace myChess.Services
{
    public class Database : DbContext
    {
        public Database() : base()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Movement> Movements { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=..\..\..\ChessDB.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movement>().ToTable("Movements").HasKey(m => m.ID);
        }

    }
}