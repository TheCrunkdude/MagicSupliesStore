using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
    public interface IRolePermissionsRepository
    {

        Task<List<RolePermissions>> GetRolePermissionsRepo();
        Task<List<RolePermissions>> GetRolePermissionsByIDRepo(int id);
        Task<List<RolePermissions>> GetPermissionsByRole(int roleID);
        Task<RolePermissions> CreateNewRolePermissionRepo(RolePermissions rolePermission);
        Task<bool> UpdateRolePermissionRepo(List<UpdateEntity> rolePermissions);
        Task<RolePermissions> DeleteRolePermissionRepo(int id);



    }
}

