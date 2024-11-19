using System;
using System.Text.Json;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace MagicstoreAPI.Repositories
{
	public class UserRepository : IUserRepository

	{
        //propiedades//
        private readonly ILogger<UserRepository> _logger;
        private ApplicationDBContext _applicationDb;
        //Constructor Adentro creas OBJETOS!!!//
        public UserRepository(ILogger<UserRepository>logger, ApplicationDBContext applicationDB)
		{
            _logger = logger;
            _applicationDb = applicationDB;
        }
        //Metodos (Ojo, van AFUERA del constructor!!)//
        public async Task<List<Users>> GetUsersRepo()
        {
            var QueryResult = _applicationDb.MSDB_Users.ToList();

            return QueryResult;
        }

        public async Task<Users> GetUserValue(int? id, string? name)
        {
            var QueryResult = _applicationDb.MSDB_Users.Where(x => x.UserName == name || x.ID == id).FirstOrDefault();
            return QueryResult;

        }

        
        public async Task<Users> CreateNewUser(Users user)
        {
            //Insert a new user to the database//
            var QueryResult = _applicationDb.MSDB_Users.Add(user).Entity;
            _applicationDb.SaveChanges();
            return QueryResult;

        }
        public async Task<Users> UpdateUser(Users user)
        {
            //update user at the database//
            var UsersEntity = _applicationDb.MSDB_Users.Where(x => x.ID == user.ID).FirstOrDefault();
            if (UsersEntity !=null)
            {
                UsersEntity.UserName = user.UserName;
                UsersEntity.Password = user.Password;
                UsersEntity.RoleID = user.RoleID;
                UsersEntity.Mail = user.Mail;
                UsersEntity.CreationDate = user.CreationDate;

                var QueryResult = _applicationDb.MSDB_Users.Update(UsersEntity);
                _applicationDb.SaveChanges();
                return QueryResult.Entity;
            }
            return null;
        }
        //Delete user from DB
        public async Task<Users> DeleteUser(int userID)
        {
            var UsersEntity = _applicationDb.MSDB_Users.Where(x => x.ID == userID).FirstOrDefault();
            var QueryResult = _applicationDb.MSDB_Users.Remove(UsersEntity).Entity;
            _applicationDb.SaveChanges();
            return QueryResult;
        }


        public GenericResponse AzureRequest(int configurationID, string json)
        {
            try
            {
                var Result = new GenericResponse() { Response = json, ConfigurationId = configurationID, Success = true };
                return Result;
            }

            catch (Exception ex)
            {
                throw new Exception("AzureRequest Error" + ex.Message);
            }
        }
    }
}

