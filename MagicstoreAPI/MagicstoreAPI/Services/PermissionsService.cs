using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Repositories;

namespace MagicstoreAPI.Services
{
    public class PermissionsService
    {
        private PermissionsRepository _permissionsRepository;
        private readonly ILogger<PermissionsService> _logger;

        public PermissionsService(ILogger<PermissionsService> logger, PermissionsRepository rolesRepository)
        {
            _logger = logger;
            _permissionsRepository = rolesRepository;
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
    }
}

