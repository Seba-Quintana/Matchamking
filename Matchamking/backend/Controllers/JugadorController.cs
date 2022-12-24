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
        private JugadorServices _jugadorServices;

		public JugadorController(JugadorServices _jugadorServices,
			ILogger<WeatherForecastController> logger)
		{
			this._logger = logger;
			this._jugadorServices = _jugadorServices;
		}

		// GET api/<ValuesController>/5
		[HttpGet("")]
		public async Task<JugadorResponse<Jugador>> GetPlayers()
		{
			return await _jugadorServices.GetPlayers();
		}

		// GET api/<ValuesController>/5
		[HttpGet("{name}")]
		public Task<JugadorResponse<Jugador>> GetPlayer(string name)
		{
			return _jugadorServices.GetPlayer(name);
		}

		/*
		// POST api/<ValuesController>
		[HttpPost("{id}")]
		public void PostPlayer([FromQuery] string name)
		{
			return _jugadorServices.PostPlayer(name);
		}
		*/
		/*// DELETE api/<ValuesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}

		// PUT api/<ValuesController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}*/
	}
}
