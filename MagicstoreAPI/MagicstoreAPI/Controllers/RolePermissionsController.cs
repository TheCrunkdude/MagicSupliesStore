using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MagicstoreAPI.Controllers
{
	public class RolePermissionsController: Controller
	{
		private IRolePermissionsService _rolePermissionService;
        public RolePermissionsController(IRolePermissionsService rolePermissionsService)
		{
			_rolePermissionService = rolePermissionsService;
		}
        [Route("/api/GetAllRolePermissions")]
        [HttpGet]
        public async Task<List<RolePermissions>> GetRolePermissions()
        {
            List<RolePermissions> result = _rolePermissionService.GetRolePermissions().Result;
            return (result);
        }
        [Route("/api/GetRolePermissionsByID")]
        [HttpGet]
        public async Task<List<RolePermissions>> GetSingleRolePermissions([FromBody]int id)
        {
            List<RolePermissions> result = _rolePermissionService.GetPermissionsByID(id).Result;
            return (result);
        }
        [Route("/api/GetRolePermissionsByRole")]
        [HttpGet]
        public async Task<List<RolePermissions>> GetSingleRolePermissionsByRole([FromBody]int role)
        {
            List<RolePermissions> result = _rolePermissionService.GetPermissionsByRole(role).Result;
            return (result);
        }
        [Route("/api/PostNewRolePermission")]
        [HttpPost]
        public async Task<string> CreatePermission([FromBody]RolePermissions rolePermissions )
        {
            var result = _rolePermissionService.CreateNewRolePermissionService(rolePermissions).Result;
            var result2 = result == false ? "La Relacion Rol-Permiso ya existe" : "Relacion creada";
            return result2;
        }
        [Authorize]
        [Route("/api/UpdateRolePermission")]
        [HttpPut]
        public async Task<string> UpdateRolePermission([FromBody] List<UpdateEntity> rolePermissions)
        {
            var result = _rolePermissionService.UpdateRolePermissionsService(rolePermissions).Result;
            var result2 = result == false ? "El Rol-Permiso no puede ser actualizado" : "Permiso actualizado";
            return result2;
        }


        // Metodo put, para eliminar permiso//
        [Route("/api/DeleteRolePermission")]
        [HttpDelete]
        public async Task<string> DeleteRolePermission([FromQuery] int ID)
        {

            var result = _rolePermissionService.DeleteRolePermissionService(ID).Result;
            var result2 = result == false ? "Rol-Permiso no eliminado" : "Rol-Permiso eliminado";
            return result2;
        }


    }
}

