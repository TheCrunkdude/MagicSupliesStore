using System;
namespace MagicstoreAPI.Infrastructures.Entities.SeedData
{
	public class RolePermissionsSeedData
	{
        public static List<RolePermissions> rolesPermissionsSeed()
        {
            return new List<RolePermissions>()
            {
                new RolePermissions {ID =  1 ,RoleID= 1, Role = "Super Admin", PermissionID = 1, Permission = "Permiso 1" },
                new RolePermissions {ID =  2 ,RoleID= 1, Role = "Super Admin", PermissionID = 2, Permission = "Permiso 2" },
                new RolePermissions {ID =  3 ,RoleID= 2, Role = "User ", PermissionID = 3, Permission = "Permiso 3" },
            };

        }
    }
}

