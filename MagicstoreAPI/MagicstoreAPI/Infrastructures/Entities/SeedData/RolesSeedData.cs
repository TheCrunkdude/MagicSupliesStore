using System;
namespace MagicstoreAPI.Infrastructures.Entities.SeedData
{
	public static class RolesSeedData
	{
		public static List<Roles> rolesSeed()
		{
			return new List<Roles>()
			{
			   new Roles {ID =  1 , Role = "Super Admin" },
			   new Roles {ID =  2 , Role = "User" },
			   new Roles {ID =  3 , Role = "Viewer" },
			   new Roles {ID =  4 , Role = "Administrator" },
			   new Roles {ID =  5 , Role = "Developer" }
			};
		}

	}
}

