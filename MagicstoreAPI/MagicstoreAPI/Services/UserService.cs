using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Repositories;

namespace MagicstoreAPI.Services
{
	public class UserService : IUserService
	{
        private IUserRepository _iUserRepository;
        private readonly ILogger<UserService> _logger;

		public UserService(ILogger<UserService> logger,
            IUserRepository iuserRepository)
		{
			_logger = logger;
            _iUserRepository = iuserRepository;

        }

        public async Task<List<Users>> GetUsers()
        {

            try
            {
                _logger.LogInformation("Get Users is ok ");
                List<Users> result = await _iUserRepository.GetUsersRepo();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get User Service Error" + ex.Message);
            }
        }

        public async Task<Users> GetSingleUser(int? id, string? name)
        {
            try
            {
                var result = await _iUserRepository.GetUserValue(id, name);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get User Service Error" + ex.Message);

            }

        }

        public async Task<bool> CreateNewUserService(Users user)
        {
            try
            {
                _logger.LogInformation("Create New user service is ok ");

                var insertresult = await _iUserRepository.CreateNewUser (user);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUserService(Users user)
        {
            try
            {
                _logger.LogInformation("Update user service is ok ");
                var insertresult = await _iUserRepository.UpdateUser(user);
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

        public async Task<bool> DeleteUserService (int userID)
        {
            try
            {
                var deleteresult = await _iUserRepository.DeleteUser(userID);
                if (deleteresult !=null)
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

