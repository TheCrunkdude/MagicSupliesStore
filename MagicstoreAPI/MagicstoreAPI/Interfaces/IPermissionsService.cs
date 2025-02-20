using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
	public interface IPermissionsService
	{
        Task<List<Permissions>> GetPermissions();
        Task<Permissions> GetSinglePermission(int? id, string? permission);
        Task<bool> CreateNewPermissionService(Permissions permission);
        Task<bool> UpdatePermissionService(Permissions permission);
        Task<bool> DeletePermissionService(int id);
    }
}

