using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MagicstoreAPI.Controllers
{
	public class RolesControler: Controller
	{
		private IRolesService _rolesService;
		public RolesControler(IRolesService rolesService)
		{
			_rolesService = rolesService;
		}
        // Metodo get, para obtener el valor de nuestra tabla//
        [Authorize]

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
        public async Task<string> CreateRole([FromBody]Roles role1)
        {
            var result = _rolesService.CreateNewRoleService(role1).Result;
            var result2 = result == false ? "El Rol ya existe" : "Rol creado";
            return result2;
        }
        [Route("/api/UpdateRole")]
        [HttpPut]
        public async Task<string> UpdateRole([FromBody]Roles role1)
        {
            var result = _rolesService.UpdateRoleService(role1).Result;
            var result2 = result == false ? "El Rol no puede ser actualizado" : "Rol actualizado";
            return result2;
        }
        // Metodo put, para eliminar Rol//
        [Route("/api/DeleteRole")]
        [HttpDelete]
        public async Task<string> DeleteRole([FromQuery] int ID)
        {

            var result = _rolesService.DeleteRoleService(ID).Result;
            var result2 = result == false ? "Rol no eliminado" : "Rol eliminado";
            return result2;
        }

    }
}

