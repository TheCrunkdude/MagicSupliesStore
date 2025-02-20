using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Repositories.Interfaces
{
    public interface IPermissionsRepository
    {
        Task<List<Permissions>> GetPermissionsRepo();
        Task<Permissions> GetPermissionValue(int? id, string? permission);
        Task<Permissions> CreateNewPermissionRepo(Permissions permissions);
        Task<Permissions> UpdatePermissionRepo(Permissions permission);
        Task<Permissions> DeletePermissionRepo(int id);
    }
}

