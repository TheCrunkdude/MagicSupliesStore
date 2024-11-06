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

        public async Task<Roles> GetRoleService(int? id)
        {

            try
            {
                var result = await _rolesRepository.GetRoleValue(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get role Service Error" + ex.Message);
            }
        }

        public async Task<Roles> GetCheckRoleService(string role)
        {

            try
            {
                var result = await _rolesRepository.GetCheckRoleValue(role);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Check role Service Error" + ex.Message);
            }
        }


        public async Task<bool> CreateNewRoleService(Roles role)
        {
            try
            {
                _logger.LogInformation("Create New role service is ok ");

                var insertresult = await _rolesRepository.CreateNewRoleRepo(role);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateRoleService(Roles role)
        {
            try
            {
                _logger.LogInformation("Update role service is ok ");
                var insertresult = await _rolesRepository.UpdateRoleRepo(role);
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
        public async Task<bool> DeleteRoleService(int ID)
        {
            try
            {
                var deleteresult = await _rolesRepository.DeleteRoleRepo(ID);
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