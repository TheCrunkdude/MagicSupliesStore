using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Repositories;

namespace MagicstoreAPI.Interfaces
{
    public interface IRolePermissionsService
    {

        Task<List<RolePermissions>> GetRolePermissions();
        Task<List<RolePermissions>> GetPermissionsByID(int id);
        Task<List<RolePermissions>> GetPermissionsByRole(int role);
        Task<bool> CreateNewRolePermissionService(RolePermissions rolePermissions);
        Task<bool> UpdateRolePermissionsService(List<UpdateEntity> rolePermissions);
        Task<bool> DeleteRolePermissionService(int id);

    }
}

