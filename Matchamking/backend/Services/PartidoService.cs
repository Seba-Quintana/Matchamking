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
		public Task<Response<Partido>> EndMatch(int id1, int id2, int goles1, int goles2);
		/*
		public Task<Response<Partido>> PutGoals(string id, float eloboost);
		public Task<Response<Partido>> PutWinRate(string id, int winRate);*/
	}

	public class PartidoServices : IPartidoServices
    {
		private IEquipoServices _equipoServices;
        private MatchamkingContext _context;

        public PartidoServices(IEquipoServices equipoServices, MatchamkingContext context)
        {
			_equipoServices = equipoServices;
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

        public async Task<Response<Partido>> EndMatch(int id1, int id2, int goles1, int goles2)
		{
			var res = new Response<Partido>();

			// insertar goles en ambos equipos

			var equipo1 = await _equipoServices.PutGoals(id1, goles1);
			var equipo2 = await _equipoServices.PutGoals(id2, goles2);
			
			if(goles1 > goles2)
			{
				
			}
			//


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
