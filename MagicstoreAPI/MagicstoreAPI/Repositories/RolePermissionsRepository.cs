using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Repositories
{
	public class RolePermissionsRepository
	{
		private readonly ILogger<RolePermissionsRepository> _logger;
		private ApplicationDBContext _applicationDb;
		public RolePermissionsRepository(ILogger<RolePermissionsRepository> logger, ApplicationDBContext applicationDB)
		{
			_logger = logger;
			_applicationDb = applicationDB;
        }

        public async Task<List<RolePermissions>> GetRolePermissionsRepo()
        {
            var QueryResult = _applicationDb.MSDB_RolesPermissions.ToList();

            return QueryResult;
        }
        public async Task<List<RolePermissions>> GetRolePermissionsByIDRepo( int id)
        {
            var Perms = _applicationDb.MSDB_RolesPermissions.Where(x => x.ID == id).ToList();
            return Perms;
        }

        public async Task<List<RolePermissions>> GetPermissionsByRole(int roleID)
        {
            var Perms = _applicationDb.MSDB_RolesPermissions.Where(x => x.RoleID == roleID).ToList();
            return Perms;
        }

        public async Task<RolePermissions> CreateNewRolePermissionRepo(RolePermissions rolePermission)
        {
            //rolePermission.CreationDate = DateTime.UtcNow;
            var QueryResult = _applicationDb.MSDB_RolesPermissions.Add(rolePermission).Entity;
            _applicationDb.SaveChanges();
            return QueryResult;

        }
        public async Task<bool> UpdateRolePermissionRepo(List<UpdateEntity> rolePermissions)
        {
            //update Rolem Permission at the database//
            foreach (var rolePermission in rolePermissions)
            {
                var rolePEntity = _applicationDb.MSDB_RolesPermissions.Where(x => x.RoleID == rolePermission.property1 && x.PermissionID == rolePermission.property3).FirstOrDefault();

                var newEntity = new RolePermissions();

                newEntity.RoleID = rolePermission.property1;
                newEntity.Role = rolePermission.property2;
                newEntity.PermissionID = rolePermission.property3;
                newEntity.Permission = rolePermission.property4;
                newEntity.Active = rolePermission.active;

                switch (rolePermission.active)
                {
                    case true:
                        if (rolePEntity==null)
                        {
                            var QueryResult = _applicationDb.MSDB_RolesPermissions.Add(newEntity).Entity;
                        }
                        break;
                    case false:
                        _applicationDb.MSDB_RolesPermissions.Remove(rolePEntity);
                        break;
                }
                _applicationDb.SaveChanges();
            }
            return true;
        }

        public async Task<RolePermissions> DeleteRolePermissionRepo(int id)
        {
            var rolePEntity = _applicationDb.MSDB_RolesPermissions.Where(x => x.ID == id).FirstOrDefault();
            var QueryResult = _applicationDb.MSDB_RolesPermissions.Remove(rolePEntity).Entity;
            _applicationDb.SaveChanges();
            return QueryResult;
        }

    }
}

