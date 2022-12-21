using System;
using System.Collections.Generic;
namespace Entities 
{
    public class EquipoEntity
    {
        public int Goles { get; set; }
        public bool Suplentes { get; set; }
        public List<JugadorEntity> Jugadores { get; set; }
    }
}