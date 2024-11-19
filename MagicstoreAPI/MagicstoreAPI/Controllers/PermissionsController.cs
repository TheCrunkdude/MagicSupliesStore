using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace MagicstoreAPI.Controllers
{
	public class PermissionsController: Controller
	{
		private IPermissionsService _iPermissionsService;
		public PermissionsController( IPermissionsService ipermissionsService )
		{
			_iPermissionsService = ipermissionsService;
		}
		// Metodo get all, para obtener los valores de nuestra tabla//
		[Route("/api/GetPermissions")]
		[HttpGet]
		public async Task<List<Permissions>> GetPermissions()
		{
			List<Permissions> result = _iPermissionsService.GetPermissions().Result;
			return (result);

		}
		// Metodo single get//
		[Route("/api/GetPermission")]
		[HttpGet]
		public async Task<Permissions> GetPermission([FromQuery] int? id )
		{
			var result = _iPermissionsService.GetSinglePermission(id).Result;
			return (result);

		}
		//Metodo post, para generar nuevo permiso//
		[Route("/api/PostNewPermission")]
		[HttpPost]
		public async Task<string> CreatePermission(Permissions permissions)
		{
			var result = _iPermissionsService.CreateNewPermission(permissions).Result;
			var result2 = result == false ? "El permiso ya existe" : "Permiso creado";
			return result2;
		}
		[Route("/api/UpdatePermission")]
		[HttpPut]
		public async Task<string> UpdatePermission(Permissions permissions)
		{
			var result = _iPermissionsService.UpdatePermissionService(permissions).Result;
			var result2 = result == false ? "El Permiso no puede ser actualizado" : "Permiso actualizado";
			return result2;
		}


		// Metodo put, para eliminar permiso//
		[Route("/api/DeletePermission")]
		[HttpDelete]
		public async Task<string> DeletePermission([FromQuery] int ID)
		{

			var result = _iPermissionsService.DeletePermissionService(ID).Result;
			var result2 = result == false ? "Permiso no eliminado" : "Permiso eliminado";
			return result2;
		}

	}
}

