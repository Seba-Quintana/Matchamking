using System;
using System.Collections.Generic;
namespace Entities
{
	public class Jugador
	{
		public string Nickname { get; set; }
		public int Jugados { get; set; }
		public int Victorias { get; set; }
		public int Empates { get; set; }
		public int Derrotas { get; set; }
		public float Elo { get; set; }
		public int CantRacha { get; set; }
		public bool Resaca { get; set; }
		public int GolesAFavor { get; set; }
		public int GolesEnContra { get; set; }
		public Dictionary<string, Partido> Partidos { get; set; }
	}
}
