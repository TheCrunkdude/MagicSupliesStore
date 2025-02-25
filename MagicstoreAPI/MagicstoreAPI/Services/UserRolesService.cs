using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Repositories;

namespace MagicstoreAPI.Services
{
	public class UserRolesService
	{
        private UserRolesRepository _userRolesRepository;
        private readonly ILogger<UserRolesService> _logger;

        public UserRolesService(ILogger<UserRolesService> logger, UserRolesRepository userRolesRepository)
        {
            _logger = logger;
            _userRolesRepository = userRolesRepository;
        }

        public async Task<List<UserRoles>> GetUserRolesService()
        {
            try
            {
                _logger.LogInformation("Get User Roles is ok ");
                List<UserRoles> result = await _userRolesRepository.GetUserRolesRepo();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get  User Roles Service Error" + ex.Message);
            }
        }
        public async Task<List<UserRoles>> GetUserRolesByName(string name)
        {
            try
            {
                _logger.LogInformation("Get User Roles is ok ");
                List<UserRoles> result = await _userRolesRepository.GetUserRoleByName(name);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get  User Roles Service Error" + ex.Message);
            }
        }


        public async Task<bool> CreateNewUserRolesService(UserRoles userRoles)
        {
            try
            {
                var insertresult = await _userRolesRepository.CreateNewUserRoleRepo(userRoles);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Create  User Roles Service Error" + ex.Message);
            }
        }
        public async Task<bool> UpdateUserRolesService(List<UpdateEntity> userRoles)
        {
            try
            {
                _logger.LogInformation("Update Permission service is ok ");
                var insertresult = await _userRolesRepository.UpdateUserRoleRepo(userRoles);
                if (insertresult != null)
                {
                    return true;
                }
                return false;
            }

            catch (Exception ex)
            {
                throw new Exception("Update  User Roles Service Error" + ex.Message);
            }
        }
        public async Task<bool> DeleteUserRoleService(int id)
        {
            try
            {
                var deleteresult = await _userRolesRepository.DeleteUserRoleRepo(id);
                if (deleteresult != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Delete  User Roles Service Error" + ex.Message);
            }
        }


    }
}

