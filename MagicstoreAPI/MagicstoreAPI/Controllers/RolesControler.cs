using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace MagicstoreAPI.Controllers
{
	public class RolesControler: Controller
	{
		private RolesService _rolesService;
		public RolesControler(RolesService rolesService)
		{
			_rolesService = rolesService;
		}
        // Metodo get, para obtener el valor de nuestra tabla//
        [Route("/api/GetRoles")]
        [HttpGet]
        public async Task<List<Roles>> GetRoles()
        {
            List<Roles> result = _rolesService.GetRoles().Result;
            return (result);

        }
        // Metodo single get//
        [Route("/api/GetRole")]
        [HttpGet]
        public async Task<Roles> GetRole([FromQuery] int? id)
        {
            var result = _rolesService.GetRoleService(id).Result;
            return (result);

        }
        [Route("/api/GetCheckRole")]
        [HttpGet]
        public async Task<Roles> GetCheckRole([FromQuery] string role)
        {
            var result = _rolesService.GetCheckRoleService(role).Result;
            return (result);

        }


        //Metodo post, para generar nuevo Rol//
        [Route("/api/PostNewRole")]
        [HttpPost]
        public async Task<string> CreateRole(Roles role1)
        {
            var result = _rolesService.CreateNewRoleService(role1).Result;
            var result2 = result == false ? "El rol ya existe" : "rol creado";
            return result2;
        }
        [Route("/api/UpdateRole")]
        [HttpPut]
        public async Task<string> UpdateRole(Roles role)
        {
            var result = _rolesService.UpdateRoleService(role).Result;
            var result2 = result == false ? "El Usuario no puede ser actualizado" : "Usuario actualizado";
            return result2;
        }
        // Metodo put, para eliminar Rol//
        [Route("/api/DeleteRole")]
        [HttpDelete]
        public async Task<string> DeleteRole([FromQuery] int ID)
        {

            var result = _rolesService.DeleteRoleService(ID).Result;
            var result2 = result == false ? "Permiso no eliminado" : "Permiso eliminado";
            return result2;
        }

    }
}

