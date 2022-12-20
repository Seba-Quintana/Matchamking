using System;

namespace Matchamking.Models
{
	public class Example
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public Example(int id, string name)
		{
			this.Id = id;
			this.Name = name;
		}
	}
}
