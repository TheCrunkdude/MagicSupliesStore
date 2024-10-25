using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Repositories;

namespace MagicstoreAPI.Services
{
    public class PermissionsService
    {
        private PermissionsRepository _permissionsRepository;
        private readonly ILogger<PermissionsService> _logger;

        public PermissionsService(ILogger<PermissionsService> logger, PermissionsRepository permissionsRepository)
        {
            _logger = logger;
            _permissionsRepository = permissionsRepository;
        }
        public async Task<List<Permissions>> GetPermissions()
        {

            try
            {
                _logger.LogInformation("Get Permissions is ok ");
                List<Permissions> result = await _permissionsRepository.GetPermissionsRepo();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get Permissions Service Error" + ex.Message);
            }
        }
        public async Task<Permissions> GetSinglePermission(int? id)
        {

            try
            {
                var result = await _permissionsRepository.GetPermissionValue(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get SPermission Service Error" + ex.Message);
            }
        }

        public async Task<bool> CreateNewPermissionService(Permissions permission)
        {
            try
            {
                _logger.LogInformation("Create New Permission service is ok ");

                var insertresult = await _permissionsRepository.CreateNewPermissionRepo(permission);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdatePermissionService(Permissions permission)
        {
            try
            {
                _logger.LogInformation("Update Permission service is ok ");
                var insertresult = await _permissionsRepository.UpdatePermissionRepo(permission);
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
        public async Task<bool> DeletePermissionService(int id)
        {
            try
            {
                var deleteresult = await _permissionsRepository.DeletePermissionRepo(id);
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

