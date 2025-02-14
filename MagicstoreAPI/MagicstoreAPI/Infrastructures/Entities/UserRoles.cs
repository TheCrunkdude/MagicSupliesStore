using System;
namespace MagicstoreAPI.Infrastructures.Entities
{
	public class UserRoles
	{
        public int ID { get; set; }
        public int UserID { get; set; }
        public string User { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }

    }
}

