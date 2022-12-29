using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Data.Models
{
    public class Partido : PartidoVista
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cancha { get; set; }

        public Partido(DateTime fecha, string Cancha)
        {
            this.Fecha = fecha;
            this.Cancha = Cancha;
        }
    }
}
