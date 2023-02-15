using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Data.Models;

namespace backend.Controllers
{
	[Route("api/matches")]
	[ApiController]
	public class PartidoController : ControllerBase
	{
		private IPartidoServices _partidoServices;

		public PartidoController(IPartidoServices partidoServices)
		{
			this._partidoServices = partidoServices;
		}

		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public Task<Response<Partido>> GetMatch([FromQuery] int id)
		{
			return _partidoServices.GetMatch(id);
		}

		// GET api/<ValuesController>/5
		[HttpGet]
		public async Task<Response<Partido>> GetMatches()
		{
			return await _partidoServices.GetMatches();
		}

		// POST api/<ValuesController>
		[HttpPost]
		public Task<Response<Partido>> PostMatch([FromBody] DateTime fecha, [FromQuery] string cancha)
		{
			return _partidoServices.PostMatch(fecha, cancha);
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete]
		public Task<Response<Partido>> DeleteMatch([FromQuery] int id)
		{
			return _partidoServices.DeleteMatch(id);
		}

		[HttpPost("{id}")]
		public Task<Response<Partido>> EndMatch([FromQuery]int id, [FromQuery] int goles1, [FromQuery] int goles2)
		{
			return _partidoServices.EndMatch(id, goles1, goles2);
		}
		/*
		// PUT api/<ValuesController>/5
		[HttpPut]
		public Task<Response<Partido>> PutMatch([FromQuery] string id, [FromQuery] float eloboost)
		{
			return _partidoServices.PutEloboost(id, eloboost);
		}
		*/
	}
}