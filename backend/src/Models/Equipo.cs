using System;
using System.Collections.Generic;
namespace Entities 
{
    public class Equipo
    {
        public int Goles { get; set; }
        public bool Suplentes { get; set; }
        public List<Jugador>   Jugadores { get; set; }
    }
}