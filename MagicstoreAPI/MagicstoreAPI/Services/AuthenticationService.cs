using System.Security.Cryptography;
using MagicstoreAPI.Helpers;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace MagicstoreAPI.Services
{
	public class AuthenticationService
	{
        private UserService _userService;
        private UsersToken _token;
        private JwtSettings _jwtSettings;
        private IConfiguration _configuration;

        public AuthenticationService(UserService userService, JwtSettings jwtSettings, IConfiguration configuration)
		{
            _userService = userService;
            _jwtSettings = jwtSettings;
            _configuration = configuration;
        }
        public AuthenticationService()
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
                    throw new Exception ("Error en authenticate");
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

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}

