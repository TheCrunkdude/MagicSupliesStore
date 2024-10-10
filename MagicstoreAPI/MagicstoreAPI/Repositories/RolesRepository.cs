using System;
using System.Text.Json;
using MagicstoreAPI.Infrastructures.Entities;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace MagicstoreAPI.Repositories
{
	public class RolesRepository
	{
        //propiedades//
        private readonly ILogger<RolesRepository> _logger;
        private ApplicationDBContext _applicationDb;
        //Constructor Adentro creas OBJETOS!!!//
        public RolesRepository(ILogger<RolesRepository> logger, ApplicationDBContext applicationDB)
        {
            _logger = logger;
            _applicationDb = applicationDB;
        }
        //Metodos (Ojo, van AFUERA del constructor!!)//
        public async Task<List<Roles>> GetRolesRepo()
        {
            var QueryResult = _applicationDb.MSDB_Roles.ToList();

            return QueryResult;
        }
    }
}

