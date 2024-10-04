using System;
using System.Text.Json;
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

    }
}

