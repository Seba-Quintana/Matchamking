using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Data.Models;

namespace backend.Controllers
{
    [Route("api/players")]
	[ApiController]
	public class JugadorController : ControllerBase
	{
		private IJugadorServices _jugadorServices;

		public JugadorController(IJugadorServices jugadorServices)
		{
			this._jugadorServices = jugadorServices;
		}

		// GET api/<ValuesController>/5
		[HttpGet("{name}")]
		public Task<Response<Jugador>> GetPlayer([FromQuery(Name = "name")] string name)
		{
			return _jugadorServices.GetPlayer(name);
		}

		// GET api/<ValuesController>/5
		[HttpGet]
		public async Task<Response<Jugador>> GetPlayers()
		{
			return await _jugadorServices.GetPlayers();
		}

		// POST api/<ValuesController>
		[HttpPost]
		public Task<Response<Jugador>> PostPlayer([FromQuery(Name = "name")] string name)
		{
			return _jugadorServices.PostPlayer(name);
		}
		
		// DELETE api/<ValuesController>/5
		[HttpDelete]
		public Task<Response<Jugador>> DeletePlayer([FromQuery(Name = "name")] string name)
		{
			return _jugadorServices.DeletePlayer(name);
		}
		
		// PUT api/<ValuesController>/5
		[HttpPut]
		public Task<Response<Jugador>> PutEloboost([FromQuery] string name, [FromQuery] float eloboost)
		{
			return _jugadorServices.PutEloboost(name, eloboost);
		}

		[HttpPut("winRate")]
		public Task<Response<Jugador>> PutWinRate([FromQuery] string name, [FromQuery] int winRate)
		{
			return _jugadorServices.PutWinRate(name, winRate);
		}
	}
}
