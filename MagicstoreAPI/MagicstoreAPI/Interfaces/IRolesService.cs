using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
	public interface IRolesService
    {
        Task<List<Roles>> GetRoles();
        Task<Roles> GetRoleService(int? id);
        Task<Roles> GetCheckRoleService(string role);
        Task<bool> CreateNewRoleService(Roles role);
        Task<bool> UpdateRoleService(Roles role);
        Task<bool> DeleteRoleService(int ID);
    }
}

