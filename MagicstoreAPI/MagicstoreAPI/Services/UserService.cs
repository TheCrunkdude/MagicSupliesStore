using System;
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
        public async Task<bool> CreateNewUserService(Users user)
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
    }
}

