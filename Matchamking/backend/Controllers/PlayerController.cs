using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
	[Route("api/[players]")]
	[ApiController]
	public class PlayerController : ControllerBase
	{
		private PlayerServices playerServices;

		public PlayerController(PlayerServices playerServices)
		{
			this.playerServices = playerServices;
		}

		// GET: api/<ValuesController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<ValuesController>/5
		[HttpGet]
		public HashSet<Player> GetPlayers()
		{
			return playerServices.GetPlayers();
		}

		// GET api/<ValuesController>/5
		[HttpGet("{name}")]
		public Player GetPlayer(string name)
		{
			return playerServices.GetPlayer(name);
		}

		// POST api/<ValuesController>
		[HttpPost("{id}")]
		public void PostPlayer([FromQuery] string name)
		{
			return playerServices.PostPlayer(name);
		}

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
