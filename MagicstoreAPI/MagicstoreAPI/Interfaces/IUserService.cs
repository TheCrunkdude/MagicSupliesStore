using System;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
	public interface IUserService
    {
        Task<List<Users>> GetUsers();
        Task<Users> GetSingleUser(int? id, string? name);
        Task<bool> CreateNewUserService(UsersDTO user);
        Task<bool> UpdateUserService(UsersDTO user);
        Task<bool> DeleteUserService(int userID);
    }
}

