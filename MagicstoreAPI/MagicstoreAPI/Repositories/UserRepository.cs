using System;
using System.Text.Json;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace MagicstoreAPI.Repositories
{
	public class UserRepository
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

