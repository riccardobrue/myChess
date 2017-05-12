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
        public DbSet<TableModel> Tables {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=..\..\..\ChessDB.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //entity mapping
            modelBuilder.Entity<Movement>().ToTable("Movements").HasKey(m => m.ID);
            modelBuilder.Entity<TableModel>().ToTable("Tables").HasKey(t => t.ID);

            //relationship mapping
            modelBuilder
                .Entity<TableModel>()
                .HasMany(t => t.Movements)
                .WithOne(m => m.Table)
                .IsRequired();
        }

    }
}