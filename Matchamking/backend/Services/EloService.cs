using backend.Services;

namespace backend.Data.Models
{
    public interface IEloServices
    {
        public float Calculate(Jugador jugador, int result, float eloMedioRival, float eloMedioAliado);

    }
    public class EloServices : IEloServices
    {
        private MatchamkingContext _context;
        private IJugadorServices _jugadorServices;

        public EloServices(MatchamkingContext context, IJugadorServices jugadorServices)
        {
            _context = context;
            _jugadorServices = jugadorServices;
        }

        public float Calculate(Jugador jugador, int diferencia, float eloMedioRival, float eloMedioAliado)
        {
            float diferenciaElo = 0;

            diferenciaElo += CalculateResult(diferenciaElo, diferencia);
            diferenciaElo += CalculateBuffOrDebuffs(diferencia,jugador, eloMedioRival);

            return diferenciaElo;
        }

        private float CalculateResult(float diferenciaElo, int diferencia)
        {
            if (diferencia > 0)
            {
                diferenciaElo += 4;
                if (diferencia > 3)
                {
                    diferenciaElo += 2;
                    if (diferencia > 4)
                    {
                        diferenciaElo += 2;
                        if (diferencia > 5)
                        {
                            diferenciaElo += 2;
                        }
                    }
                }
            }
            else if (diferencia < 0)
            {
                diferenciaElo -= 4;
            }
            return diferenciaElo;
        }

        private static float CalculateBuffOrDebuffs(int diferencia, Jugador jugador, float eloMedioRival)
        {
            float diferenciaElo = 0;

            var diferenciaGoles = jugador.GolesAFavor - jugador.GolesEnContra;
            var winrate = (jugador.Empates + jugador.Victorias) / (jugador.Victorias + jugador.Empates + jugador.Derrotas) * 100;

            // si el jugador tiene diferencia de goles positiva, influye en su elo
            if(diferenciaGoles > 4)
            {
                diferenciaElo += 1;
            }
            else if(diferenciaGoles < 6)
            {
                diferenciaElo += -1;
            }

            // si el jugador tiene mas de 70% de winrate, su elo se aumenta aún más

            if (winrate > 70)
            {
                diferenciaElo += (winrate - 50) * 0.08f;
            }

            // rachas
            
            if(jugador.Racha > 3) 
            {
                diferenciaElo += 2;
            }
            else if(jugador.Racha < 3)
            {
                diferenciaElo += -2;
            }

            // diferencia con el EloMedioRival

            if(jugador.Elo > eloMedioRival)
            {
                diferenciaElo += -3;
            }
            else
            {
                diferenciaElo += 4;
            }

            return diferenciaElo;
            
        }
    }
}
