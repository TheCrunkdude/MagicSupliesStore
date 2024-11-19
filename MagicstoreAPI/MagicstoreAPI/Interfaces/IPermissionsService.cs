using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
	public interface IPermissionsService
	{
        Task<List<Permissions>> GetPermissions();
        Task<Permissions> GetSinglePermission(int? id);
        Task<bool> CreateNewPermission(Permissions permission);
        Task<bool> UpdatePermissionService(Permissions permission);
        Task<bool> DeletePermissionService(int id);
    }
}

