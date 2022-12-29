using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Data.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public int Goles { get; set; }
        public bool Suplentes { get; set; }


        public virtual int PartidoId { get; set; }
        public virtual Partido Partido { get; set; }

        public Equipo EquipoA { get; set; }
        public Equipo EquipoB { get; set; }

		//public Equipo() { }
		//public Equipo(int goles, bool suplentes, List<Jugador> jugadores)
		//{
		//    Goles = goles;
		//    Suplentes = suplentes;
		//}
	}
}