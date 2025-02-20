using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;

namespace MagicstoreAPI.Services
{
	public class RolesService : IRolesService
    {
        private IRolesRepository _irolesRepository;
        private readonly ILogger<RolesService> _logger;

        public RolesService(ILogger<RolesService> logger, IRolesRepository irolesRepository)
        {
            _logger = logger;
            _irolesRepository = irolesRepository;
        }

        public async Task<List<Roles>> GetRoles()
        {
            try
            {
                _logger.LogInformation("Get Roles is ok ");
                List<Roles> result = await _irolesRepository.GetRolesRepo();
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
                var result = await _irolesRepository.GetRoleValue(id);
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
                var result = await _irolesRepository.GetCheckRoleValue(role);
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

                var insertresult = await _irolesRepository.CreateNewRoleRepo(role);
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
                var insertresult = await _irolesRepository.UpdateRoleRepo(role);
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
                var deleteresult = await _irolesRepository.DeleteRoleRepo(ID);
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