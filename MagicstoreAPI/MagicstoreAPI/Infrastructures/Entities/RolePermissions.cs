using System;
namespace MagicstoreAPI.Infrastructures.Entities
{
	public class RolePermissions
	{
		public int ID { get; set; }
		public string Role { get; set; }
        public int RoleID { get; set; }
        public string Permission { get; set; }
        public int PermissionID { get; set; }
        public bool Active { get; set; }
		//public DateTime CreationDate { get; set; }
	}
}