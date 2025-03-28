using System;
using System.Security;

namespace MagicstoreAPI.Infrastructures.Entities.SeedData
{
	public class PermissionsSeedData
	{
        public static List<Permissions> permissionsSeed()
        {
            return new List<Permissions>()
            {
                new Permissions { ID = 1, Permission = "Permiso1", Description = "All access" },
                new Permissions { ID = 2, Permission = "perm 2", Description = "descripcionpermiso" },
                new Permissions { ID = 3, Permission = "perm 3", Description = "tres" },
                new Permissions { ID = 4, Permission = "perm4", Description = "just view" },
                new Permissions { ID = 5, Permission = "perm 5", Description = "mantenimiento" }
            };
        }
	}
}

