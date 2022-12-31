using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Data.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        public int Goles { get; set; }

        public virtual int PartidoId { get; set; }
        public virtual Partido Partido { get; set; }

        public List<EquipoJugador> EquipoJugadores { get; set; }

        public Equipo() { }
        public Equipo(int partidoId)
        {
            PartidoId = partidoId;
        }
	}
}