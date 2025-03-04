using System;
namespace MagicstoreAPI.Infrastructures.Entities
{
	public class PaginadorData
	{
		public List<Beers> Rows { get; set; }
		public int TotalItems { get; set; }

	}
}

