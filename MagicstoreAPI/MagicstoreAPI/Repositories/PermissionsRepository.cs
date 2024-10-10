using System;
using System.Text.Json;
using MagicstoreAPI.Infrastructures.Entities;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace MagicstoreAPI.Repositories
{
	public class PermissionsRepository
	{

        private readonly ILogger<PermissionsRepository> _logger;
        private ApplicationDBContext _applicationDb;
        public PermissionsRepository(ILogger<PermissionsRepository> logger, ApplicationDBContext applicationDB)
        {
            _logger = logger;
            _applicationDb = applicationDB;   
		}
        public async Task<List<Permissions>> GetPermissionsRepo()
        {
            var QueryResult = _applicationDb.MSDB_Permissions.ToList();

            return QueryResult;
        }
    }
}

