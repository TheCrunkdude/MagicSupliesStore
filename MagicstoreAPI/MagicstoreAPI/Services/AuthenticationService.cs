﻿using System.Security.Cryptography;
using MagicstoreAPI.Helpers;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace MagicstoreAPI.Services
{
<<<<<<< HEAD
	public class AuthenticationService1
=======
	public class AuthenticationService : IAuthenticationService
>>>>>>> main
	{
        private IUserService _userService;
        private IConfiguration _configuration;
        private readonly ILogger<AuthenticationService> _logger;

        private UsersToken _token;
        private RolePermissionsService _rolePermissions;
        private UserRolesService _userRoles;
        private JwtSettings _jwtSettings;

<<<<<<< HEAD
        public AuthenticationService1(UserService userService, RolePermissionsService rolePermissions, UserRolesService userRoles, JwtSettings jwtSettings, IConfiguration configuration)
=======
        public AuthenticationService(ILogger<AuthenticationService> logger, IUserService userService, JwtSettings jwtSettings, IConfiguration configuration)
>>>>>>> main
		{
            _logger = logger;
            _userService = userService;
            _jwtSettings = jwtSettings;
            _configuration = configuration;
            _rolePermissions = rolePermissions;
        }
        public AuthenticationService1()
        {

        }

        public async Task<UsersToken> Authenticate(string Name, string Password)
        {
            try
            {
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
                }, _jwtSettings, _configuration/*, context*/);
                return Token;
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Permissions>> AccessPermissions(string Name)
        {
            var usuario = _userRoles.GetUserRolesByName( Name).Result;
            var permissions = new List<Permissions>();

            foreach (var item in usuario)
            {
                var rolePermissions = await _rolePermissions.GetPermissionsByRole(item.RoleID);
                permissions.AddRange((IEnumerable<Permissions>)rolePermissions);
            }
            return permissions;

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

