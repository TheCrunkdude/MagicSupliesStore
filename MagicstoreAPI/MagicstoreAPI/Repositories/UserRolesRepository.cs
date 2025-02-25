using System;
using MagicstoreAPI.Infrastructures.Entities;

namespace MagicstoreAPI.Repositories
{
	public class UserRolesRepository
	{
        private readonly ILogger<UserRolesRepository> _logger;
        private ApplicationDBContext _applicationDb;
        public UserRolesRepository(ILogger<UserRolesRepository> logger, ApplicationDBContext applicationDB)
        {
            _logger = logger;
            _applicationDb = applicationDB;
        }
        public async Task<List<UserRoles>> GetUserRolesRepo()
        {
            var QueryResult = _applicationDb.MSDB_UserRoles.ToList();

            return QueryResult;
        }

        public async Task<List<UserRoles>> GetUserRoleByName(string name)
        {

            var UsrRoles = _applicationDb.MSDB_UserRoles.Where(x => x.User == name).ToList();
            return UsrRoles;
        }

        public async Task<UserRoles> CreateNewUserRoleRepo(UserRoles userRole)
        {
            //rolePermission.CreationDate = DateTime.UtcNow;
            var QueryResult = _applicationDb.MSDB_UserRoles.Add(userRole).Entity;
            _applicationDb.SaveChanges();
            return QueryResult;

        }
        public async Task<bool> UpdateUserRoleRepo(List<UpdateEntity> userRoles)
        {
            //update Rolem Permission at the database//
            foreach (var userRole in userRoles)
            {
                var userRolesEntity = _applicationDb.MSDB_UserRoles.Where(x => x.UserID == userRole.property1 && x.RoleID == userRole.property3).FirstOrDefault();

                var newEntity = new UserRoles();

                newEntity.UserID = userRole.property1;
                newEntity.User = userRole.property2;
                newEntity.RoleID = userRole.property3;
                newEntity.Role = userRole.property4;
                newEntity.Active = userRole.active;

                switch (userRole.active)
                {
                    case true:
                        if (userRolesEntity == null)
                        {
                            var QueryResult = _applicationDb.MSDB_UserRoles.Add(newEntity).Entity;
                        }
                        break;
                    case false:
                        _applicationDb.MSDB_UserRoles.Remove(userRolesEntity);
                        break;
                }
                _applicationDb.SaveChanges();
            }
            return true;
        }

        public async Task<UserRoles> DeleteUserRoleRepo(int id)
        {
            var rolePEntity = _applicationDb.MSDB_UserRoles.Where(x => x.ID == id).FirstOrDefault();
            var QueryResult = _applicationDb.MSDB_UserRoles.Remove(rolePEntity).Entity;
            _applicationDb.SaveChanges();
            return QueryResult;
        }

    }
}

