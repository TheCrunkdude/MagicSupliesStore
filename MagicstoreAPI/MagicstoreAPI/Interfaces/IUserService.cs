using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
	public interface IUserService
    {
        Task<List<Users>> GetUsers();
        Task<Users> GetSingleUser(int? id, string? name);
        Task<bool> CreateNewUserService(Users user);
        Task<bool> UpdateUserService(Users user);
        Task<bool> DeleteUserService(int userID);
    }
}

