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
        public async Task<Roles> GetCheckRoleValue(string role)
        {
            var QueryResult = _applicationDb.MSDB_Roles.Where(x => x.Role == role).FirstOrDefault();
            return QueryResult;
        }
        public async Task<Roles> GetRoleValue(int? id)
        {
            var QueryResult = _applicationDb.MSDB_Roles.Where(x => x.ID == id).FirstOrDefault();
            return QueryResult;
        }
        public async Task<Roles> CreateNewRoleRepo(Roles role)
        {
            var QueryResult = _applicationDb.MSDB_Roles.Add(role).Entity;
            _applicationDb.SaveChanges();
            return QueryResult;

        }
        public async Task<Roles> UpdateRoleRepo(Roles role)
        {
            //update role at the database//
            var roleEntity = _applicationDb.MSDB_Roles.Where(x => x.ID == role.ID).FirstOrDefault();
            if (roleEntity != null)
            {
                roleEntity.ID = role.ID;
                roleEntity.PermissionsID = role.PermissionsID;
                roleEntity.Role = role.Role;

                var QueryResult = _applicationDb.MSDB_Roles.Update(roleEntity);
                _applicationDb.SaveChanges();
                return QueryResult.Entity;
            }
            return null;
        }
        public async Task<Roles> DeleteRoleRepo(int id)
        {
            var roleEntity = _applicationDb.MSDB_Roles.Where(x => x.ID == id).FirstOrDefault();
            var QueryResult = _applicationDb.MSDB_Roles.Remove(roleEntity).Entity;
            _applicationDb.SaveChanges();
            return QueryResult;
        }
    }
}

