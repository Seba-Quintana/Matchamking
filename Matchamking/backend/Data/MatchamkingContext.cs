using System.Diagnostics;
using backend.Data.Models;
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
            modelBuilder.Entity<Equipo_Jugador>()
                .HasOne(e => e.Equipo)
                .WithMany(ej => ej.Equipo_Jugadores)
                .HasForeignKey(ei => ei.EquipoId);
            modelBuilder.Entity<Equipo_Jugador>()
                .HasOne(j => j.Jugador)
                .WithMany(ej => ej.Equipo_Jugadores)
                .HasForeignKey(ji => ji.Nickname);
        }
        public DbSet<Jugador> Jugadores { get; set; }

        public DbSet<Equipo_Jugador> Equipo_Jugadores{ get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Partido> Partidos { get; set; }

    }
}
