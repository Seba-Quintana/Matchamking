using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Data.Models;

namespace backend.Services
{
	public interface IJugadorServices
	{
		public Task<Response<Jugador>> GetPlayers();
		public Task<Response<Jugador>> GetPlayer(string name);
		public Task<Response<Jugador>> PostPlayer(string name);
		public Task<Response<Jugador>> DeletePlayer(string name);
		public Task<Response<Jugador>> PutEloboost(string name, float eloboost);
		public Task<Response<Jugador>> PutWinRate(string name, int winRate);
		public Task<Jugador> UpdatePlayer(string name, Jugador jugador);


    }

    public class JugadorServices : IJugadorServices
    {

        private MatchamkingContext _context;

        public JugadorServices(MatchamkingContext context)
        {
            _context = context;
        }

        public async Task<Response<Jugador>> GetPlayers()
        {
	        var res = new Response<Jugador>();
	        try
	        {
		        res.BodyResponseList = await _context.Jugadores.ToListAsync()
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
        public async Task<Response<Jugador>> GetPlayer(string name)
        {
	        var res = new Response<Jugador>();
	        try
	        {
		        res.BodyResponseList.Add(await _context.Jugadores.FindAsync(name)
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

        public async Task<Response<Jugador>> PostPlayer(string nombreJugador)
        {
	        var res = new Response<Jugador>();

		        var jugador = new Jugador(nombreJugador);
		        await _context.Jugadores.AddAsync(jugador);
				res.StsCod = "200";
		        res.StsMsg = "Jugador creado correctamente";
		        await _context.SaveChangesAsync();


	        return res;
        }

        public async Task<Response<Jugador>> DeletePlayer(string name)
        {
	        var res = new Response<Jugador>();
	        try
	        {
		        var jugador = await _context.Jugadores.FindAsync(name)
		                      ?? throw new InvalidOperationException();
				_context.Jugadores.Remove(jugador);
		        res.StsCod = "200";
		        res.StsMsg = "Jugador eliminado correctamente";
		        await _context.SaveChangesAsync();
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
        public async Task<Response<Jugador>> PutEloboost(string name, float eloboost)
        {
	        var res = new Response<Jugador>();
	        try
	        {
		        var jugador = await _context.Jugadores.FindAsync(name)
		                      ?? throw new InvalidOperationException();
		        jugador.Eloboost = eloboost;
		        res.StsCod = "200";
		        res.StsMsg = "Jugador eloboosteado correctamente xdxdxd";
		        await _context.SaveChangesAsync();
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

        public async Task<Response<Jugador>> PutWinRate(string name, int winRate)
        {
	        var res = new Response<Jugador>();
	        try
	        {
		        var jugador = await _context.Jugadores.FindAsync(name)
		                      ?? throw new InvalidOperationException();
		        jugador.WinRate = winRate;
		        res.StsCod = "200";
		        res.StsMsg = "Jugador modificado correctamente";
		        await _context.SaveChangesAsync();
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

        public async Task<Jugador> UpdatePlayer(string name, Jugador jugador)
        {
            var res = new Response<Jugador>();
            try
            {
                var jugadorACambiar = await _context.Jugadores.FindAsync(name)
                              ?? throw new InvalidOperationException();
				jugadorACambiar = jugador;
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException e)
            {
            }
            catch (Exception e)
            {
            }
            return jugador;
        }
    }
}