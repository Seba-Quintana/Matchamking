using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Models
{
    public class Jugador
    {
        [Key]
        public string Nickname { get; set; }
        public int Jugados { get; set; }
        public int WinRate { get; set; }
		public int Victorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public float Elo { get; set; }
        public int Racha { get; set; }
        public bool Resaca { get; set; }
        public int GolesAFavor { get; set; }
        public int GolesEnContra { get; set; }
        public float Eloboost { get; set; }

        public List<EquipoJugador> EquipoJugadores { get; set; }
       // public List<EquipoJugador> EquipoJugadores { get; set; }


        public Jugador()
        {
        }
        public Jugador(string nickname)
        {
            Nickname = nickname;
            Jugados = 0;
            WinRate = 0;
			Victorias = 0;
            Empates = 0;
            Derrotas = 0;
            Elo = 0;
            Racha = 0;
            Resaca = false;
            GolesAFavor = 0;
            GolesEnContra = 0;
            Eloboost = 0;
        }

    }
}
