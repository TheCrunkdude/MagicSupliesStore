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

        public async Task<Permissions> GetPermissionValue(int? id, string? permission)
        {
            var QueryResult = _applicationDb.MSDB_Permissions.Where(x=> x.ID ==id || x.Permission == permission).FirstOrDefault();
            return QueryResult;
        }

        public async Task<Permissions> CreateNewPermissionRepo(Permissions permission)
        {
            var QueryResult = _applicationDb.MSDB_Permissions.Add(permission).Entity;
            _applicationDb.SaveChanges();
            return QueryResult;

        }

        public async Task<Permissions> UpdatePermissionRepo(Permissions permission)
        {
            //update user at the database//
            var permEntity = _applicationDb.MSDB_Permissions.Where(x => x.ID == permission.ID).FirstOrDefault();
            if (permEntity != null)
            {
                permEntity.ID = permission.ID;
                permEntity.Permission = permission.Permission;
                permEntity.Description = permission.Description;

                var QueryResult = _applicationDb.MSDB_Permissions.Update(permEntity);
                _applicationDb.SaveChanges();
                return QueryResult.Entity;
            }
            return null;
        }


            public async Task<Permissions> DeletePermissionRepo(int id)
        {
            var PermsEntity = _applicationDb.MSDB_Permissions.Where(x => x.ID == id).FirstOrDefault();
            var QueryResult = _applicationDb.MSDB_Permissions.Remove(PermsEntity).Entity;
            _applicationDb.SaveChanges();
            return QueryResult;
        }
    }
}

