using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/players")]
	[ApiController]
	public class JugadorController : ControllerBase
	{
        private readonly ILogger<WeatherForecastController> _logger;
        private IJugadorServices _jugadorServices;

		public JugadorController(IJugadorServices _jugadorServices,
			ILogger<WeatherForecastController> logger)
		{
			this._logger = logger;
			this._jugadorServices = _jugadorServices;
		}

		// GET api/<ValuesController>/5
		[HttpGet("{name}")]
		public Task<JugadorResponse<Jugador>> GetPlayer([FromQuery(Name = "name")] string name)
		{
			return _jugadorServices.GetPlayer(name);
		}

		// GET api/<ValuesController>/5
		[HttpGet]
		public async Task<JugadorResponse<Jugador>> GetPlayers()
		{
			return await _jugadorServices.GetPlayers();
		}

		// POST api/<ValuesController>
		[HttpPost]
		public Task<JugadorResponse<Jugador>> PostPlayer([FromQuery(Name = "name")] string name)
		{
			return _jugadorServices.PostPlayer(name);
		}
		
		// DELETE api/<ValuesController>/5
		[HttpDelete]
		public Task<JugadorResponse<Jugador>> DeletePlayer([FromQuery(Name = "name")] string name)
		{
			return _jugadorServices.DeletePlayer(name);
		}
		
		// PUT api/<ValuesController>/5
		[HttpPut]
		public Task<JugadorResponse<Jugador>> PutEloboost([FromQuery] string name, [FromQuery] float eloboost)
		{
			return _jugadorServices.PutEloboost(name, eloboost);
		}

		[HttpPut("winRate")]
		public Task<JugadorResponse<Jugador>> PutWinRate([FromQuery] string name, int winRate)
		{
			return _jugadorServices.PutWinRate(name, winRate);
		}
	}
}
