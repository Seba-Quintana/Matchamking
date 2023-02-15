using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Data.Models;

namespace backend.Services
{
	public interface IPartidoServices
	{
		public Task<Response<Partido>> GetMatches();
		public Task<Response<Partido>> GetMatch(int id);
		public Task<Response<Partido>> PostMatch(DateTime fecha, string cancha);
		public Task<Response<Partido>> DeleteMatch(int id);
		public Task<Response<Partido>> EndMatch(int id, int goles1, int goles2);
		/*
		public Task<Response<Partido>> PutGoals(string id, float eloboost);
		public Task<Response<Partido>> PutWinRate(string id, int winRate);*/
	}

	public class PartidoServices : IPartidoServices
    {
		private IEquipoServices _equipoServices;
		private IEloServices _eloServices;
		private IJugadorServices _jugadorServices;
        private MatchamkingContext _context;

        public PartidoServices(
			IEquipoServices equipoServices, IEloServices eloServices,
			IJugadorServices jugadorServices, MatchamkingContext context)
        {
			_equipoServices = equipoServices;
			_eloServices = eloServices;
			_jugadorServices = jugadorServices;
            _context = context;
        }

        public async Task<Response<Partido>> GetMatches()
        {
	        var res = new Response<Partido>();
	        try
	        {
		        res.BodyResponseList = await _context.Partidos.ToListAsync()
		                               ?? throw new InvalidOperationException();
		        res.StsCod = "200";
		        res.StsMsg = "Partido obtenido correctamente";
	        }
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Partido no encontrado";
			}
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
			return res;
        }
        public async Task<Response<Partido>> GetMatch(int id)
        {
	        var res = new Response<Partido>();
	        try
	        {
		        res.BodyResponseList.Add(await _context.Partidos.FindAsync(id)
		                                 ?? throw new InvalidOperationException());
		        res.StsCod = "200";
		        res.StsMsg = "Partido obtenido correctamente";
			}
	        catch (InvalidOperationException e)
	        {
				res.StsCod = "500";
				res.StsMsg = "Partido no encontrado";
			}
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
			return res;
        }
              
        public async Task<Response<Partido>> PostMatch(DateTime fecha, string cancha)
        {
	        var res = new Response<Partido>();
	        try
	        {
		        var partido = new Partido(fecha, cancha);
		        await _context.Partidos.AddAsync(partido);
				res.StsCod = "200";
		        res.StsMsg = "Partido creado correctamente";
		        await _context.SaveChangesAsync();
	        }
			catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
	        return res;
        }

        public async Task<Response<Partido>> DeleteMatch(int id)
        {
	        var res = new Response<Partido>();
	        try
	        {
		        var partido = await _context.Partidos.FindAsync(id)
		                      ?? throw new InvalidOperationException();
				_context.Partidos.Remove(partido);
		        res.StsCod = "200";
		        res.StsMsg = "Partido eliminado correctamente";
		        await _context.SaveChangesAsync();
			}
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Partido no encontrado";
	        }
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
	        return res;

        }

        public async Task<Response<Partido>> EndMatch(int id, int goles1, int goles2)
		{
			var res = new Response<Partido>();

			try
			{
				// insertar goles en ambos equipos
				var getpartido = GetMatch(id);
				var partido = await _context.Partidos.FindAsync(id) 
							  ?? throw new InvalidOperationException();
				await _equipoServices.PutGoals(partido.Equipos[0].Id, goles1);
				await _equipoServices.PutGoals(partido.Equipos[1].Id, goles2);

				// obtener equipos y jugadores
				var get1 = await _equipoServices.GetTeam(partido.Equipos[0].Id);
				var get2 = await _equipoServices.GetTeam(partido.Equipos[1].Id);
				var equipo1 = get1.BodyResponseList[0];
				var equipo2 = get2.BodyResponseList[0];
				var jugadores = new List<Jugador>();
				float eloMedioEquipo2 = 0f;
				float eloMedioEquipo1 = 0f;
				var jugadoreseq1 = new List<Jugador>();
				var jugadoreseq2 = new List<Jugador>();

				foreach (var jugadorequipo1 in equipo1.Jugadores)
				{
					var jugadorins = new Response<Jugador>();
					foreach (var jugadorequipo2 in equipo2.Jugadores)
					{
						jugadorins = await _jugadorServices.GetPlayer(jugadorequipo2);
						jugadoreseq2.Add(jugadorins.BodyResponseList[0]);
						jugadores.Add(jugadorins.BodyResponseList[0]);
					}
					jugadorins = await _jugadorServices.GetPlayer(jugadorequipo1);
					jugadoreseq1.Add(jugadorins.BodyResponseList[0]);
					jugadores.Add(jugadorins.BodyResponseList[0]);
				}

				eloMedioEquipo1 = jugadoreseq1.Average(j => j.Elo);
				eloMedioEquipo2 = jugadoreseq2.Average(j => j.Elo);

				var diferenciaGoles = 0;
				foreach (var jugador in jugadores)
				{
					// primero se calcula el elo en base a las estadisticas anteriores
					if (equipo1.Jugadores.Contains(jugador.Nickname))
					{
						jugador.Elo += _eloServices.Calculate(jugador, (equipo1.Goles - equipo2.Goles), eloMedioEquipo2, eloMedioEquipo1);
						jugador.GolesAFavor += equipo1.Goles;
						jugador.GolesEnContra += equipo2.Goles;
					}
					else
					{
						jugador.Elo += _eloServices.Calculate(jugador, (equipo2.Goles - equipo1.Goles), eloMedioEquipo1, eloMedioEquipo2);
						jugador.GolesAFavor += equipo2.Goles;
						jugador.GolesEnContra += equipo1.Goles;
					}

					// se agregan las nuevas estadísticas a los jugadores
					jugador.Jugados += 1;

					diferenciaGoles = equipo1.Goles - equipo2.Goles;

					if (diferenciaGoles == 0)
					{
						jugador.Empates += 1;
					}
					else if (diferenciaGoles > 0)
					{
						jugador.Victorias += 1;
					}
					else
					{
						jugador.Derrotas += 1;
					}

					if (jugador.Racha > 0 && diferenciaGoles > 0)
					{
						jugador.Racha += 1;
					}
					else if (jugador.Racha > 0 && diferenciaGoles < 0)
					{
						jugador.Racha = -1;
					}
					else if (jugador.Racha < 0 && diferenciaGoles > 0)
					{
						jugador.Racha = 1;
					}
					else if (jugador.Racha < 0 && diferenciaGoles < 0)
					{
						jugador.Racha -= 1;
					}

					jugador.WinRate = jugador.Victorias / jugador.Jugados * 100;

					await _jugadorServices.UpdatePlayer(jugador.Nickname, jugador);
				}

                res.BodyResponseList.Add(partido);
                res.StsCod = "200";
                res.StsMsg = "Partido finalizado con éxito";
            }
			catch (InvalidOperationException ex)
			{
				res.StsCod = "500";
				res.StsMsg = ex.Message;
			}
			catch(Exception ex) 
			{
				res.StsCod = "500";
				res.StsMsg = ex.Message;
			}
			// agregar las nuevas estadisticas a los jugadores
			// guardar cambios

            return res;
		}

        /*public async Task<Response<Partido>> PutEloboost(string id, float eloboost)
        {
	        var res = new Response<Partido>();
	        try
	        {
		        var partido = await Context.Partidos.FindAsync(id)
		                      ?? throw new InvalidOperationException();
		        partido.Eloboost = eloboost;
		        res.StsCod = "200";
		        res.StsMsg = "Partido eloboosteado correctamente xdxdxd";
		        await Context.SaveChangesAsync();
	        }
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Partido no encontrado";
	        }
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
	        return res;
        }

        public async Task<Response<Partido>> PutWinRate(string id, int winRate)
        {
	        var res = new Response<Partido>();
	        try
	        {
		        var partido = await Context.Partidos.FindAsync(id)
		                      ?? throw new InvalidOperationException();
		        partido.WinRate = winRate;
		        res.StsCod = "200";
		        res.StsMsg = "Partido modificado correctamente";
		        await Context.SaveChangesAsync();
	        }
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Partido no encontrado";
	        }
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
	        return res;
        }*/
    }
}
