using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using MagicstoreAPI.Repositories.Interfaces;

namespace MagicstoreAPI.Services
{
	public class PermissionsService : IPermissionsService
	{
		private IPermissionsRepository _iPermissionRepository;
		private readonly ILogger<PermissionsService> _logger;

		public PermissionsService(ILogger<PermissionsService> logger,
			IPermissionsRepository ipermissionsRepository)
		{
			_logger = logger;
			_iPermissionRepository = ipermissionsRepository;
		}

		public async Task<List<Permissions>> GetPermissions()
		{

			try
			{
				_logger.LogInformation("Get Permissions is ok ");
				List<Permissions> result = await _iPermissionRepository.GetPermissionsRepo();
				return result;
			}
			catch (Exception ex)
			{
				throw new Exception("Get Permissions Service Error" + ex.Message);
			}
		}
		public async Task<Permissions> GetSinglePermission(int? id)
		{

			try
			{
				var result = await _iPermissionRepository.GetPermissionValue(id);
				return result;
			}
			catch (Exception ex)
			{
				throw new Exception("Get SPermission Service Error" + ex.Message);
			}
		}

		public async Task<bool> CreateNewPermission(Permissions permission)
		{
			try
			{
				_logger.LogInformation("Create New Permission service is ok ");

				var insertresult = await _iPermissionRepository.CreateNewPermissionRepo(permission);
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public async Task<bool> UpdatePermissionService(Permissions permission)
		{
			try
			{
				var insertresult = await _iPermissionRepository.UpdatePermissionRepo(permission);
				if (insertresult != null)
				{
					return true;
				}
				return false;
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}
		public async Task<bool> DeletePermissionService(int id)
		{
			try
			{
				var deleteresult = await _iPermissionRepository.DeletePermissionRepo(id);
				if (deleteresult != null)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

