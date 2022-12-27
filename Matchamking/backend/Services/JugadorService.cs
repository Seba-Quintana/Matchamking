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

        public async Task<List<Jugador>> GetPlayers()
        {
            return await Context.Jugadores.ToListAsync();
        }
        public async Task<Jugador> GetPlayer(string name)
        {
            return await Context.Jugadores.FindAsync(name);
        }
/*
        public async Task<List<Jugador>> PostPlayer(Jugador jugador)
        {
            return await Context.Jugadores.AddAsync(jugador);
        }
*/
    }
}