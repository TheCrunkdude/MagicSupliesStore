using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
	public interface IUserRolesRepository
	{
       Task<List<UserRoles>> GetUserRolesRepo();
       Task<List<UserRoles>> GetUserRoleByName(string name);
       Task<UserRoles> CreateNewUserRoleRepo(UserRoles userRole);
       Task<bool> UpdateUserRoleRepo(List<UpdateEntity> userRoles);
       Task<UserRoles> DeleteUserRoleRepo(int id);

    }
}

