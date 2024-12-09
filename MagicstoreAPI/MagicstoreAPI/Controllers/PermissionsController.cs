using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MagicstoreAPI.Controllers
{
	public class PermissionsController: Controller
	{
		private PermissionsService _permissionsService;

        public PermissionsController(PermissionsService permissionsService)
		{
			_permissionsService = permissionsService;
		}
        // Metodo get all, para obtener los valores de nuestra tabla//
        
        [Route("/api/GetPermissions")]
        [HttpGet]
        public async Task<List<Permissions>> GetPermissions()
        {
            List<Permissions> result = _permissionsService.GetPermissions().Result;
            return (result);

        }
        // Metodo single get//
        [Route("/api/GetPermission")]
        [HttpGet]
        public async Task<Permissions> GetPermission([FromQuery] int? id , string? permission)
        {
            var result = _permissionsService.GetSinglePermission(id, permission).Result;
            return (result);

        }
        //Metodo post, para generar nuevo permiso//
        [Route("/api/PostNewPermission")]
        [HttpPost]
        public async Task<string> CreatePermission([FromBody]Permissions permission)
        {
            var result = _permissionsService.CreateNewPermissionService(permission).Result;
            var result2 = result == false ? "El permiso ya existe" : "Permiso creado";
            return result2;
        }
        [Route("/api/UpdatePermission")]
        [HttpPut]
        public async Task<string> UpdatePermission([FromBody]Permissions permission)
        {
            var result = _permissionsService.UpdatePermissionService(permission).Result;
            var result2 = result == false ? "El Permiso no puede ser actualizado" : "Permiso actualizado";
            return result2;
        }


        // Metodo put, para eliminar permiso//
        [Route("/api/DeletePermission")]
        [HttpDelete]
        public async Task<string> DeletePermission([FromQuery] int ID)
        {

            var result = _permissionsService.DeletePermissionService(ID).Result;
            var result2 = result == false ? "Permiso no eliminado" : "Permiso eliminado";
            return result2;
        }

    }
}

