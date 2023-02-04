using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Data.Models;
using System.Xml.Linq;

namespace backend.Services
{
	public interface IEquipoServices
	{
		public Task<Response<Equipo>> GetTeams();
		public Task<Response<Equipo>> GetTeam(int id);
		public Task<Response<Equipo>> PostTeam(int partidoId, List<string> nicknames);
        public Task<Response<Equipo>> DeleteTeam(int id);

		public Task<Response<Equipo>> PutGoals(int id, int goles);
        /*
		public Task<Response<Equipo>> PutEloboost(string id, float eloboost);
		public Task<Response<Equipo>> PutWinRate(string id, int winRate);*/
    }

	public class EquipoServices : IEquipoServices
    {

        private MatchamkingContext _context;

        public EquipoServices(MatchamkingContext context)
        {
            _context = context;
        }

        public async Task<Response<Equipo>> GetTeams()
        {
	        var res = new Response<Equipo>();
	        try
	        {
		        res.BodyResponseList = await _context.Equipos.ToListAsync()
		                               ?? throw new InvalidOperationException();
		        res.StsCod = "200";
		        res.StsMsg = "Equipo obtenido correctamente";
	        }
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Equipo no encontrado";
			}
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
			return res;
        }
        public async Task<Response<Equipo>> GetTeam(int id)
        {
	        var res = new Response<Equipo>();
	        try
	        {
				var equipo = await _context.Equipos.FindAsync(id)
										 ?? throw new InvalidOperationException();
				IEnumerable<EquipoJugador> jugadoresLista = await _context.EquipoJugadores.ToListAsync();
				IEnumerable<string> nicknameLista = jugadoresLista.Where(x => x.EquipoId == id).Select(b => b.Nickname);
				equipo.Jugadores = nicknameLista;
                res.BodyResponseList.Add(equipo);
		        res.StsCod = "200";
		        res.StsMsg = "Equipo obtenido correctamente";
			}
	        catch (InvalidOperationException e)
	        {
				res.StsCod = "500";
				res.StsMsg = "Equipo no encontrado";
			}
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
			return res;
        }

        public async Task<Response<Equipo>> PostTeam(int partidoId, List<string> nicknames)
        {
	        var res = new Response<Equipo>();
	        try
	        {
				var jugadores = new List<Jugador>();
                var equipo = new Equipo(partidoId);
                await _context.Equipos.AddAsync(equipo);
                foreach (var nickname in nicknames)
				{
					var jugador = await _context.Jugadores.FindAsync(nickname)
										?? throw new Exception();
					jugadores.Add(jugador);
					var relacion = new EquipoJugador();
					relacion.Equipo = equipo;
					relacion.EquipoId = equipo.Id;
					relacion.Nickname = nickname;
					relacion.Jugador = jugador;
                    await _context.EquipoJugadores.AddAsync(relacion);
                }
                res.StsCod = "200";
		        res.StsMsg = "Equipo creado correctamente";
		        await _context.SaveChangesAsync();
	        }
			catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
	        return res;
        }
        public async Task<Response<Equipo>> DeleteTeam(int id)
        {
	        var res = new Response<Equipo>();
	        try
	        {
		        var partido = await _context.Equipos.FindAsync(id)
		                      ?? throw new InvalidOperationException();
				_context.Equipos.Remove(partido);
				var equipojugadores = await _context.EquipoJugadores.ToListAsync();
				IEnumerable<EquipoJugador> deleterelaciones = 
					from equipojugador in equipojugadores
					where equipojugador.EquipoId == id
					select equipojugador;
				_context.EquipoJugadores.RemoveRange(deleterelaciones);
				res.StsCod = "200";
		        res.StsMsg = "Equipo eliminado correctamente";
		        await _context.SaveChangesAsync();
			}
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Equipo no encontrado";
	        }
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
	        return res;
        }
        public async Task<Response<Equipo>> PutGoals(int id, int goles)
		{

			var res = new Response<Equipo>();
			try
			{
                var equipo = await _context.Equipos.FindAsync(id)
							 ?? throw new InvalidOperationException();
                equipo.Goles = goles;
				await _context.SaveChangesAsync();
                res.StsCod = "200";
                res.StsMsg = "Equipo modificado correctamente";
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException e)
            {
                res.StsCod = "500";
                res.StsMsg = "Equipo no encontrado";
            }
            catch (Exception e)
            {
                res.StsCod = "500";
                res.StsMsg = "algo salio mal xd";
            }
            return res;

        }
        /*public async Task<Response<Equipo>> PutEloboost(string id, float eloboost)
        {
	        var res = new Response<Equipo>();
	        try
	        {
		        var partido = await Context.Equipos.FindAsync(id)
		                      ?? throw new InvalidOperationException();
		        partido.Eloboost = eloboost;
		        res.StsCod = "200";
		        res.StsMsg = "Equipo eloboosteado correctamente xdxdxd";
		        await Context.SaveChangesAsync();
	        }
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Equipo no encontrado";
	        }
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
	        return res;
        }

        public async Task<Response<Equipo>> PutWinRate(string id, int winRate)
        {
	        var res = new Response<Equipo>();
	        try
	        {
		        var partido = await Context.Equipos.FindAsync(id)
		                      ?? throw new InvalidOperationException();
		        partido.WinRate = winRate;
		        res.StsCod = "200";
		        res.StsMsg = "Equipo modificado correctamente";
		        await Context.SaveChangesAsync();
	        }
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Equipo no encontrado";
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
