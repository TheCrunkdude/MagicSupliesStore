
namespace MagicstoreAPI.Infrastructures.Entities
{
	public class JwtSettings
	{
        public bool ValidateIssuer { get; set; } = true;
        public bool ValidateAudience { get; set; } = true;
        public bool ValidateLifetime { get; set; } = true;
        public bool ValidateIssuerSigningKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string IssuerSigningKey { get; set; }

        public bool RequireExpirationTime { get; set; }
    }
}

