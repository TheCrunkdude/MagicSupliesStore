using System;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Interfaces
{
	public interface IUserRepository
	{
        Task<List<Users>> GetUsersRepo();
        Task<Users> GetUserValue(int? id, string? name);
        Task<Users> CreateNewUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<Users> DeleteUser(int userID);
        GenericResponse AzureRequest(int configurationID, string json);
    }
}

