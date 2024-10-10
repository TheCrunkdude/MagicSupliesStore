using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Repositories;

namespace MagicstoreAPI.Services
{
	public class RolesService
	{
		private RolesRepository _rolesRepository;
		private readonly ILogger<RolesService> _logger;

        public RolesService(ILogger<RolesService> logger, RolesRepository rolesRepository)
        {
            _logger = logger;
            _rolesRepository = rolesRepository;
        }



        public async Task<List<Roles>> GetRoles()
        {

            try
            {
                _logger.LogInformation("Get Roles is ok ");
                List<Roles> result = await _rolesRepository.GetRolesRepo();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get Roles Service Error" + ex.Message);
            }

        }
    }
}

