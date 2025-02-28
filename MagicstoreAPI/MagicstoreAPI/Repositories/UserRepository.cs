using System;
using System.Security.Cryptography;
using System.Text.Json;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace MagicstoreAPI.Repositories
{
	public class UserRepository: IUserRepository
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

        
        public async Task<Users> CreateNewUser(UsersDTO user)
        {
            //Insert a new user to the database//
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash( user.Password, out passwordHash, out passwordSalt);



            var user1 = new Users()
            {
                ID = user.ID,
                UserName = user.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Mail = user.Mail,
                CreationDate= DateTime.UtcNow
            }
                ;
            var QueryResult = _applicationDb.MSDB_Users.Add(user1).Entity;
            _applicationDb.SaveChanges();
            return QueryResult;

        }

        public async Task<Users> UpdateUser(UsersDTO user)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            //update user at the database//
            var UsersEntity = _applicationDb.MSDB_Users.Where(x => x.ID == user.ID).FirstOrDefault();
            if (UsersEntity !=null)
            {
                UsersEntity.UserName = user.UserName;
                UsersEntity.PasswordHash = passwordHash;
                UsersEntity.PasswordSalt = passwordSalt;
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


        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
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

