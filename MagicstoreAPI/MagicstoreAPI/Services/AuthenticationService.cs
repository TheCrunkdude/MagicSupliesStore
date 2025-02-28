using System.Security.Cryptography;
using MagicstoreAPI.Helpers;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace MagicstoreAPI.Services
{
	public class AuthenticationService1 : IAuthenticationService1
	{
        private IUserService _userService;
        private IConfiguration _configuration;
        private ILogger<AuthenticationService1> _logger;
        private UsersToken? _token;
        private IRolePermissionsService _rolePermissions;
        private IUserRolesService _userRolesService;
        private JwtSettings _jwtSettings;

        public AuthenticationService1(ILogger<AuthenticationService1> logger,
            IUserService userService,
            IRolePermissionsService rolePermissions,
            IUserRolesService userRoles,
            JwtSettings jwtSettings,
            IConfiguration configuration)

		{
            _logger = logger;
            _userService = userService;
            _jwtSettings = jwtSettings;
            _configuration = configuration;
            _rolePermissions = rolePermissions;
            _userRolesService = userRoles;
        }


        public async Task<UsersToken> Authenticate(string Name, string Password)
        {
            try
            {
                _logger.LogInformation("Authenticate is ok ");

                var usuario = _userService.GetSingleUser(null, Name).Result;
                var dbNombre = usuario.UserName;
                var dbSalt = usuario.PasswordSalt;
                var dbContraseña = usuario.PasswordHash;

                if (!VerifyPasswordHash(Password, dbContraseña, dbSalt))
                {
                    throw new UnauthorizedAccessException("Error en authenticate");
                }
                var Token = JwtHelper.GenTokenkey(new UsersToken()
                {
                    UserName = usuario.UserName,
                    ID = usuario.ID,
                },_jwtSettings, _configuration/*, context*/);
                return Token;
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<string>> AccessUserRoles(string Name)
        {
            var usuario = _userRolesService.GetUserRolesByName(Name).Result;
            var roles = usuario.Select(r => r.RoleID).ToList();
            List<string> permList = new List<string> ();

            foreach (var role in roles)
            {
                var permissionByRole = _rolePermissions.GetPermissionsByRole(role).Result;
                var permissions = permissionByRole.Select(r => r.Permission).ToList();
                permList.AddRange(permissions);

            }
            return permList.Distinct().OrderBy(x=>x).ToList();
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}

