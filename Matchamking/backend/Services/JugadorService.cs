using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Data.Models;

namespace backend.Services
{
	public interface IJugadorServices
	{
		public Task<JugadorResponse<Jugador>> GetPlayers();
		public Task<JugadorResponse<Jugador>> GetPlayer(string name);
		public Task<JugadorResponse<Jugador>> PostPlayer(string name);
		public Task<JugadorResponse<Jugador>> DeletePlayer(string name);
		public Task<JugadorResponse<Jugador>> PutEloboost(string name, float eloboost);
		public Task<JugadorResponse<Jugador>> PutWinRate(string name, int winRate);
	}

	public class JugadorServices : IJugadorServices
    {

        private MatchamkingContext Context;

        public JugadorServices(MatchamkingContext context)
        {
            Context = context;
        }

        public async Task<JugadorResponse<Jugador>> GetPlayers()
        {
	        var res = new JugadorResponse<Jugador>();
	        try
	        {
		        res.BodyResponseList = await Context.Jugadores.ToListAsync()
		                               ?? throw new InvalidOperationException();
		        res.StsCod = "200";
		        res.StsMsg = "Jugador obtenido correctamente";
	        }
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Jugador no encontrado";
			}
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
			return res;
        }
        public async Task<JugadorResponse<Jugador>> GetPlayer(string name)
        {
	        var res = new JugadorResponse<Jugador>();
	        try
	        {
		        res.BodyResponseList.Add(await Context.Jugadores.FindAsync(name)
		                                 ?? throw new InvalidOperationException());
		        res.StsCod = "200";
		        res.StsMsg = "Jugador obtenido correctamente";
			}
	        catch (InvalidOperationException e)
	        {
				res.StsCod = "500";
				res.StsMsg = "Jugador no encontrado";
			}
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
			return res;
        }

        public async Task<JugadorResponse<Jugador>> PostPlayer(string nombreJugador)
        {
	        var res = new JugadorResponse<Jugador>();
	        try
	        {
		        var jugador = new Jugador(nombreJugador);
		        await Context.Jugadores.AddAsync(jugador);
				res.StsCod = "200";
		        res.StsMsg = "Jugador creado correctamente";
		        await Context.SaveChangesAsync();
	        }
			catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
	        return res;
        }

        public async Task<JugadorResponse<Jugador>> DeletePlayer(string name)
        {
	        var res = new JugadorResponse<Jugador>();
	        try
	        {
		        var jugador = await Context.Jugadores.FindAsync(name)
		                      ?? throw new InvalidOperationException();
				Context.Jugadores.Remove(jugador);
		        res.StsCod = "200";
		        res.StsMsg = "Jugador eliminado correctamente";
		        await Context.SaveChangesAsync();
			}
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Jugador no encontrado";
	        }
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
	        return res;
        }
        public async Task<JugadorResponse<Jugador>> PutEloboost(string name, float eloboost)
        {
	        var res = new JugadorResponse<Jugador>();
	        try
	        {
		        var jugador = await Context.Jugadores.FindAsync(name)
		                      ?? throw new InvalidOperationException();
		        jugador.Eloboost = eloboost;
		        res.StsCod = "200";
		        res.StsMsg = "Jugador eloboosteado correctamente xdxdxd";
		        await Context.SaveChangesAsync();
	        }
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Jugador no encontrado";
	        }
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
	        return res;
        }

        public async Task<JugadorResponse<Jugador>> PutWinRate(string name, int winRate)
        {
	        var res = new JugadorResponse<Jugador>();
	        try
	        {
		        var jugador = await Context.Jugadores.FindAsync(name)
		                      ?? throw new InvalidOperationException();
		        jugador.WinRate = winRate;
		        res.StsCod = "200";
		        res.StsMsg = "Jugador modificado correctamente";
		        await Context.SaveChangesAsync();
	        }
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Jugador no encontrado";
	        }
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal xd";
	        }
	        return res;
        }
	}
}