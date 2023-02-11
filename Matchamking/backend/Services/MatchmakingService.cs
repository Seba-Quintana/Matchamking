using backend.Data;
using backend.Data.Models;

namespace backend.Services
{
    public interface IMatchmakingService
    {
        public Response<List<Equipo>> CreateMatchmaking(List<string> jugadores);
    }
    public class MatchmakingService: IMatchmakingService
    {
        private MatchamkingContext _context;

        public MatchmakingServices(MatchamkingContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Equipo>>> CreateMatchmaking(List<string> nicknames)
        {
            List<Jugador> jugadores = new List<Jugador>();
            var res = new Response<List<Equipo>>();
            foreach(var nick in nicknames)
            {
                try
                {
                    var jugador = await _context.Jugadores.FindAsync(nick)
                              ?? throw new InvalidOperationException();
                    jugadores.Add(jugador);
                }
                catch(InvalidOperationException)
                {
                    res.StsCod = "500";
                    res.StsMsg = "Jugador no encontrado";
                }
            }

            Equipo equipo1= new Equipo();
            Equipo equipo2= new Equipo();
            List<Jugador> players1 = new List<Jugador>();
            List<Jugador> players2 = new List<Jugador>();
            List<Equipo> Equipos = new List<Equipo>();

            return res;
        }
    }
}
