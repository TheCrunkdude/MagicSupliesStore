using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Services;
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
        // Metodo get, para obtener el valor de nuestra tabla//
        [Route("GetPermissions")]
        [HttpGet]
        public async Task<List<Permissions>> GetPermissions()
        {
            List<Permissions> result = _permissionsService.GetPermissions().Result;
            return (result);

        }

    }
}

