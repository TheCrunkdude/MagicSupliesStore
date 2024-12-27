using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Repositories;

namespace MagicstoreAPI.Services
{
	public class RolePermissionsService
    {
        private RolePermissionsRepository _rolePermissionsRepository;
        private readonly ILogger<RolePermissionsService> _logger;

        public RolePermissionsService(ILogger<RolePermissionsService> logger, RolePermissionsRepository rolepermissionsRepository)
        {
            _logger = logger;
            _rolePermissionsRepository = rolepermissionsRepository;
        }
        public async Task<List<RolePermissions>> GetRolePermissions()
        {
            try
            {
                _logger.LogInformation("Get Permissions is ok ");
                List<RolePermissions> result = await _rolePermissionsRepository.GetRolePermissionsRepo();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get RolePermissions Service Error" + ex.Message);
            }
        }
        public async Task<List<RolePermissions>> GetPermissionsByID(int id )
        {
            try
            {
                List<RolePermissions> result = await _rolePermissionsRepository.GetRolePermissionsByIDRepo(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get RolePermissions Service Error" + ex.Message);
            }
        }
        public async Task<List<RolePermissions>> GetPermissionsByRole(int role)
        {
            try
            {
                List<RolePermissions> result = await _rolePermissionsRepository.GetPermissionsByRole(role);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get RolePermissions Service Error" + ex.Message);
            }
        }

        public async Task<bool> CreateNewRolePermissionService(RolePermissions rolePermissions)
        {
            try
            {
                var insertresult = await _rolePermissionsRepository.CreateNewRolePermissionRepo(rolePermissions);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateRolePermissionsService(List<UpdateEntity> rolePermissions)
        {
            try
            {
                _logger.LogInformation("Update Permission service is ok ");
                var insertresult = await _rolePermissionsRepository.UpdateRolePermissionRepo(rolePermissions);
                if (insertresult != null)
                {
                    return true;
                }
                return false;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteRolePermissionService(int id)
        {
            try
            {
                var deleteresult = await _rolePermissionsRepository.DeleteRolePermissionRepo(id);
                if (deleteresult != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}

