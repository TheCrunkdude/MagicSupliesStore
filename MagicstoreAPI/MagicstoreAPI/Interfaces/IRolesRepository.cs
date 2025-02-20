using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
	public interface IRolesRepository
	{
        Task<List<Roles>> GetRolesRepo();
        Task<Roles> GetCheckRoleValue(string role);
        Task<Roles> GetRoleValue(int? id);
        Task<Roles> CreateNewRoleRepo(Roles role);
        Task<Roles> UpdateRoleRepo(Roles role);
        Task<Roles> DeleteRoleRepo(int id);
    }
}

