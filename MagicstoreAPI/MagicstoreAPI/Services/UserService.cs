using System;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Repositories;

namespace MagicstoreAPI.Services
{
	public class UserService
	{
		private UserRepository _userRepository;
		private readonly ILogger<UserService> _logger;

		public UserService(ILogger<UserService> logger,UserRepository userRepository)
		{
			_logger = logger;
			_userRepository = userRepository;
		}

        public async Task<List<Users>> GetUsers()
        {

            try
            {
                _logger.LogInformation("Get Users is ok ");
                List<Users> result = await _userRepository.GetUsersRepo();
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
                var result = await _userRepository.GetUserValue(id, name);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Get User Service Error" + ex.Message);

            }

        }

        public async Task<bool> CreateNewUserService(UsersDTO user)
        {
            try
            {
                _logger.LogInformation("Create New user service is ok ");

                var insertresult = await _userRepository.CreateNewUser (user);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUserService(UsersDTO user)
        {
            try
            {
                _logger.LogInformation("Update user service is ok ");
                var insertresult = await _userRepository.UpdateUser(user);
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
                var deleteresult = await _userRepository.DeleteUser(userID);
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

