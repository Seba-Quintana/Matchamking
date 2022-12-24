using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Data.Models;

namespace backend.Services
{
    public class JugadorServices
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
		        var a = await Context.Jugadores.ToListAsync() ?? throw new InvalidOperationException();
		        foreach (var jugador in a)
		        {
			        res.BodyResponseList.Add(jugador);
		        }

		        res.StsCod = "200";
		        res.StsMsg = "Jugador obtenido correctamente";
	        }
	        catch (InvalidOperationException e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "Jugador no existente";
			}
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal";
	        }
			return res;
        }
        public async Task<JugadorResponse<Jugador>> GetPlayer(string name)
        {
	        var res = new JugadorResponse<Jugador>();
	        try
	        {
		        res.BodyResponseList.Add(await Context.Jugadores.FindAsync(name) ?? throw new InvalidOperationException());
		        res.StsCod = "200";
		        res.StsMsg = "Jugador obtenido correctamente";
			}
	        catch (InvalidOperationException e)
	        {
				res.StsCod = "500";
				res.StsMsg = "Jugador no existente";
			}
	        catch (Exception e)
	        {
		        res.StsCod = "500";
		        res.StsMsg = "algo salio mal";
	        }
			return res;
        }
/*
        public async Task<List<Jugador>> PostPlayer(Jugador jugador)
        {
            return await Context.Jugadores.AddAsync(jugador);
        }
*/
    }
}