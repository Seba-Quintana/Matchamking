namespace backend.Data.Models
{
    public class EquipoJugador
    {
        public int Id { get; set; }

        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }

        public string Nickname { get; set; }
        public Jugador Jugador { get; set; }
    }
}