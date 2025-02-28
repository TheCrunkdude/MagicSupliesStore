using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Repositories;

namespace MagicstoreAPI.Interfaces
{
	public interface IUserRolesService
	{

        Task<List<UserRoles>> GetUserRolesService();
        Task<List<UserRoles>> GetUserRolesByName(string name);
        Task<bool> CreateNewUserRolesService(UserRoles userRoles);
        Task<bool> UpdateUserRolesService(List<UpdateEntity> userRoles);
        Task<bool> DeleteUserRoleService(int id);
    }
}

