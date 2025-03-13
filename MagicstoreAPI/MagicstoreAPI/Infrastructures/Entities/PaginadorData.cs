using System;
namespace MagicstoreAPI.Infrastructures.Entities
{
	public class PaginadorData<T>
	{
		public List<T> Rows { get; set; }
		public int TotalItems { get; set; }

	}
}

