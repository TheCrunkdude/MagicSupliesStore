using System;
namespace MagicstoreAPI.Infrastructures.Entities
{
	public class RolePermissions
	{
		public int ID { get; set; }
		public int Role { get; set; }
		public int Permission { get; set; }
		public bool Active { get; set; }
		//public DateTime CreationDate { get; set; }
	}
}