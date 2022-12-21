using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Services
{
    public class PlayerServices
    {
        private int a;

        public PlayerServices()
        {

        }

        public HashSet<Player> GetPlayers()
        {
            return new HashSet<Player>();
        }

		public Player GetPlayer(string name)
		{
			return new Player(5,"");
		}

		public Player PostPlayer(string name)
		{
			return new Player(5, "");
		}
	}
}
