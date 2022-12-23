using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Data.Models
{
    public class Partido
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cancha { get; set; }

        //public Equipo Ganador { get; set; }
        //public Equipo Perdedor { get; set; }

        public virtual List<Equipo> Equipos { get; set; }

        //public Partido() { }

        //public Partido(DateTime fecha, string cancha, Equipo ganador, Equipo perdedor)
        //{
        //    Fecha = fecha;
        //    Cancha = cancha;
        //    Ganador = ganador;
        //    Perdedor = perdedor;
        //}
    }
}