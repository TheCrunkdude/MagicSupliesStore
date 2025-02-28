using System;
using MagicstoreAPI.Infrastructures.DTO;
using MagicstoreAPI.Infrastructures.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MagicstoreAPI.Helpers
{
	public static class JwtHelper
	{
        public enum Duration { Seconds = 1, Minutes = 2, Hours = 3, Days = 4 };
        public enum Roles
        {
            Admin = 1, SuperAdmin = 4, User = 5
        };
        public static List<Claim> GetClaims(this UsersToken userAccounts, Guid Id, IConfiguration configuration)
        {
            //var rol = TranslateRoles(configuration, userAccounts.PerfilId);

            List<Claim> claims = new List<Claim> {
                new Claim("ID", userAccounts.ID.ToString()),
                new Claim("ProfileID", userAccounts.ProfileID.ToString()),
            };

                return claims;
        }
        public static UsersToken GenTokenkey(UsersToken model, JwtSettings jwtSettings, IConfiguration configuration)
        {
            try
            {
                var UserToken = new UsersToken();

                if (model == null) throw new ArgumentException(nameof(model));

                // Get secret key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid Id = Guid.Empty;
                DateTime expireTime = DeterminarDuracion(configuration);

                var JWToken = new JwtSecurityToken
                    (
                        issuer: jwtSettings.ValidIssuer,
                        audience: jwtSettings.ValidAudience,
                        claims: GetClaims(model, Guid.NewGuid(), configuration),
                        notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                        //expires: DateTime.Now.AddDays(2),
                        expires: expireTime,//DeterminarDuracion(configuration),
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
                    );

                UserToken.Token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                UserToken.UserName = model.UserName;
                UserToken.ID = model.ID;
                UserToken.ProfileID = model.ProfileID;

                return UserToken;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private static DateTime DeterminarDuracion(IConfiguration configuration)
        {
            Duration DurationType = (Duration)configuration.GetValue<int>("Jwt:ConfiguracionExtra:TipoExpiracion");
            int DutarionTime = configuration.GetValue<int>("Jwt:ConfiguracionExtra:TiempoExpiracion");
            DateTime duration;
            duration = DurationType switch
            {
                Duration.Seconds => DateTime.Now.AddSeconds(DutarionTime),
                Duration.Minutes => DateTime.Now.AddMinutes(DutarionTime),
                Duration.Hours => DateTime.Now.AddHours(DutarionTime),
                Duration.Days => DateTime.Now.AddDays(DutarionTime),
            };
            return duration;
        }


    }
}

