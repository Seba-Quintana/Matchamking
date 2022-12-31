using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Data.Models;

namespace backend.Controllers
{
	[Route("api/teams")]
	[ApiController]
	public class EquipoController : ControllerBase
	{
		private IEquipoServices _equipoServices;

		public EquipoController(IEquipoServices equipoServices)
		{
			this._equipoServices = equipoServices;
		}

		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public Task<Response<Equipo>> GetMatch([FromQuery] int id)
		{
			return _equipoServices.GetTeam(id);
		}

		// GET api/<ValuesController>/5
		[HttpGet]
		public async Task<Response<Equipo>> GetTeams()
		{
			return await _equipoServices.GetTeams();
		}

		// POST api/<ValuesController>
		[HttpPost]
		public Task<Response<Equipo>> PostTeam([FromQuery] int partidoId, [FromBody] List<string> nicknames)
		{
			return _equipoServices.PostTeam(partidoId, nicknames);
		}

		// DELETE api/<ValuesController>/5
		/*
		// PUT api/<ValuesController>/5
		[HttpPut]
		public Task<Response<Equipo>> PutMatch([FromQuery] string id, [FromQuery] float eloboost)
		{
			return _equipoServices.PutEloboost(id, eloboost);
		}
		*/
	}
}