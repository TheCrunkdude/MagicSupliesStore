using System;
namespace MagicstoreAPI.Infrastructures.Entities.SeedData
{
	public class UserRolesSeedData
	{
        public static List<UserRoles> userRolesSeed()
        {
            return new List<UserRoles>()
            {
                new UserRoles {ID =  1 , UserID = 1, User= "user" , RoleID= 1, Role = "Super Admin", Active= true },
                new UserRoles {ID =  2 , UserID = 2, User= "user2" , RoleID= 2, Role = "User", Active= true },
                new UserRoles {ID =  3 , UserID = 2, User= "user2" , RoleID= 3, Role = "Viewer", Active= true },
            };

        }
    }
}

