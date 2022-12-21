using System;
using Entities;
namespace Entities
{
	public class JugadorService : Jugador
	{
		public JugadorService(string nickname)
		{
			this.Nickname = nickname;
			this.Jugados = 0;
			this.Victorias = 0;
			this.Empates = 0;
			this.Derrotas = 0;
			this.Elo = 0;
			this.CantRacha = 0;
			this.Resaca = false;
			this.GolesAFavor = 0;
			this.GolesEnContra = 0;
		}
	}
}
