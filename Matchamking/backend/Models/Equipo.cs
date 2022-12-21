using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace backend.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        public int Goles { get; set; }
        public bool Suplentes { get; set; }
        public List<Jugador> Jugadores { get; set; }

        public Equipo() { }

        public Equipo(int goles, bool suplentes, List<Jugador> jugadores) 
        {
            Goles = goles;
            Suplentes = suplentes;
            Jugadores = jugadores;
        }
    }
}