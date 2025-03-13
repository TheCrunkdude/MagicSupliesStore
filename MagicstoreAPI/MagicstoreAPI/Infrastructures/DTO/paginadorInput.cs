using System;
namespace MagicstoreAPI.Infrastructures.DTO
{
	public class paginadorInput
	{
		public string Entity { get; set; }
		public int StartRow { get; set; }
		public int EndRow { get; set; }
	}
}

