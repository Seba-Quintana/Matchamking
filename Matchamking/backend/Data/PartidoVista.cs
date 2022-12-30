using backend.Data.Models;

namespace backend.Data
{
	public class PartidoVista
	{
		public virtual List<Equipo> Equipos { get; set; }

		public PartidoVista()
		{
		}
	}
}
