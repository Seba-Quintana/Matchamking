using System;
namespace Entities
{
    public class Partido
    {
        public DateTime Fecha { get; set; }
        public string Cancha { get; set; }
        public Equipo Ganador { get; set; }
        public Equipo Perdedor { get; set; }
    }
}