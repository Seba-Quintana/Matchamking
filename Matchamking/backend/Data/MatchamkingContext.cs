using System.Diagnostics;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class MatchamkingContext : DbContext
    {
        public MatchamkingContext(DbContextOptions<MatchamkingContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Jugador>()
                .HasMany(p => p.Partidos)
                .WithMany(p => p.Jugadores);
        }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Partido> Partidos { get; set; }

    }
}
