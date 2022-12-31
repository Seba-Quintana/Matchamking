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
            modelBuilder.Entity<EquipoJugador>()
                .HasOne(e => e.Equipo)
                .WithMany(ej => ej.EquipoJugadores)
                .HasForeignKey(ei => ei.EquipoId);
            modelBuilder.Entity<EquipoJugador>()
                .HasOne(j => j.Jugador)
                .WithMany(ej => ej.EquipoJugadores)
                .HasForeignKey(ji => ji.Nickname);

            modelBuilder.Entity<Equipo>()
                .HasOne(p => p.Partido)
                .WithMany(e => e.Equipos)
                .HasForeignKey(pid => pid.PartidoId);
        }

        public DbSet<Jugador> Jugadores { get; set; }

        public DbSet<EquipoJugador> EquipoJugadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Partido> Partidos { get; set; }

    }
}
