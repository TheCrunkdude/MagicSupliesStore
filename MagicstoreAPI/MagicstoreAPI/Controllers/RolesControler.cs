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
        [Route("GetRoles")]
        [HttpGet]
        public async Task<List<Roles>> GetRoles()
        {
            List<Roles> result = _rolesService.GetRoles().Result;
            return (result);

        }
    }
}

