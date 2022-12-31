using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Data.Models;

namespace backend.Services
{
	public interface IEquipoServices
	{
		public Task<Response<Equipo>> GetTeams();
		public Task<Response<Equipo>> GetTeam(int id);
		public Task<Response<Equipo>> PostTeam(int partidoId, List<string> nicknames);
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
				var jugadoresLista = await _context.EquipoJugadores.ToListAsync();
				jugadoresLista = jugadoresLista.Where(x => x.EquipoId == id);
				var jugadores = new List<string>();
		        res.BodyResponseList.Add(await _context.Equipos.FindAsync(id)
		                                 ?? throw new InvalidOperationException());
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
				foreach(var nickname in nicknames)
				{
					var jugador = await _context.Jugadores.FindAsync(nickname)
										?? throw new Exception();
					jugadores.Add(jugador);
				}
		        var equipo = new Equipo(partidoId);
				await _context.Equipos.AddAsync(equipo);
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
