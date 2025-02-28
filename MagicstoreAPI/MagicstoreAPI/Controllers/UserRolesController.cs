using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MagicstoreAPI.Controllers
{
	public class UserRolesController
	{
        private IUserRolesService _userRoleService;
        public UserRolesController(IUserRolesService userRolesService)
        {
            _userRoleService = userRolesService;
        }
        [Route("/api/GetAllUserRoles")]
        [HttpGet]
        public async Task<List<UserRoles>> GetUserRoles()
        {
            List<UserRoles> result = _userRoleService.GetUserRolesService().Result;
            return (result);
        }

        [Route("/api/PostGetRolesByName")]
        [HttpPost]
        public async Task<List<UserRoles>> GetUserRoleByNameController([FromBody] string userName)
        {
            List<UserRoles> result = _userRoleService.GetUserRolesByName(userName).Result;
            return (result);
        }


        [Route("/api/PostAllUserRoles")]
        [HttpPost]
        public async Task<string> CreateUserRole([FromBody] UserRoles userRole) 
        {
            var result = _userRoleService.CreateNewUserRolesService(userRole).Result;
            var result2 = result == false ? "La Relacion User Role ya existe" : "Relacion creada";
            return result2;
        }
        [Route("/api/UpdateUserRoles")]
        [HttpPut]
        public async Task<string> UpdateUserRoles([FromBody] List<UpdateEntity> rolePermissions)
        {
            var result = _userRoleService.UpdateUserRolesService(rolePermissions).Result;
            var result2 = result == false ? "El Rol-Permiso no puede ser actualizado" : "User Roles actualizado";
            return result2;
        }

        [Route("/api/DeleteUserRoles")]
        [HttpDelete]
        public async Task<string> DeleteUserRoles([FromQuery] int id)
        {

            var result = _userRoleService.DeleteUserRoleService(id).Result;
            var result2 = result == false ? "Rol-Permiso no eliminado" : "Rol-Permiso eliminado";
            return result2;
        }





    }
}

